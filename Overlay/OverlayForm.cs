using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using _4RTools.Model;
using _4RTools.Resources._4RTools;
using _4RTools.Utils;

namespace OverlayWindowExample
{
    public partial class OverlayForm : Form
    {
        private const int WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;

        private Point _middleOfScreen = new Point(0, 0);
        private Pen borderPen = new Pen(Color.Red, 2); // Define a red pen for drawing the border

        private Client _roClient;
        private List<Buff> _elementalsBuffs;
        private readonly Image _prohibitedImage;
        private class OverlayBuff
        {
	        public EffectStatusIDs StatusIDs;
	        public Image Icon;
	        public bool ShowActive;

	        public OverlayBuff(EffectStatusIDs statusIDs, string iconName, bool showActive)
	        {
		        var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
		        var imagePath = Path.Combine(path, "Assets", "Images", iconName);
		        
		        StatusIDs = statusIDs;
		        Icon = Image.FromFile(imagePath);
		        ShowActive = showActive;
	        }
	        
	        public OverlayBuff(EffectStatusIDs statusIDs, Image icon, bool showActive)
	        {
		        StatusIDs = statusIDs;
		        Icon = icon;
		        ShowActive = showActive;
	        }
        }
        private List<OverlayBuff> _trackedBuffs;

        // Hardcoded bullshit
        private void SetupDefaultBuffList()
        {
	        _trackedBuffs = new List<OverlayBuff>();
	        _trackedBuffs.Add(new OverlayBuff(EffectStatusIDs.KAUPE, "kaupe.png", true));
	        _trackedBuffs.Add(new OverlayBuff(EffectStatusIDs.PROVOKE, "provoke.png", true));
	        _trackedBuffs.Add(new OverlayBuff(EffectStatusIDs.SPRINT, "sprint.png", true));
	        _trackedBuffs.Add(new OverlayBuff(EffectStatusIDs.MADNESSCANCEL, Icons.madnesscancel, true));
	        _trackedBuffs.Add(new OverlayBuff(EffectStatusIDs.ACCURACY, Icons.increase_accuracy, true));
	        _trackedBuffs.Add(new OverlayBuff(EffectStatusIDs.E_CHAIN, Icons.e_chain, true));
	        
	        _trackedBuffs.Add(new OverlayBuff(EffectStatusIDs.PROPERTYGROUND, Icons.tk_mild_earth, true));
	        _trackedBuffs.Add(new OverlayBuff(EffectStatusIDs.PROPERTYFIRE, Icons.tk_mild_fire, true));
	        _trackedBuffs.Add(new OverlayBuff(EffectStatusIDs.PROPERTYWATER, Icons.tk_mild_water, true));
	        _trackedBuffs.Add(new OverlayBuff(EffectStatusIDs.PROPERTYWIND, Icons.tk_mild_wind, true));
	        _trackedBuffs.Add(new OverlayBuff(EffectStatusIDs.PROPERTYTELEKINESIS, Icons.tk_mild_ghost, true));
	        _trackedBuffs.Add(new OverlayBuff(EffectStatusIDs.ASPERSIO, Icons.tk_mild_holy, true));
	        _trackedBuffs.Add(new OverlayBuff(EffectStatusIDs.PROPERTYDARK, Icons.tk_mild_shadow, true));
        }

        public OverlayForm()
        {
            InitializeComponent();
            
            // Set window styles for layered and transparent behavior
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.Magenta; // Set a transparent color
            TransparencyKey = Color.Magenta;
            TopMost = true;
            ShowInTaskbar = false;

            // Set layered window attributes to make the window transparent and click-through
            SetWindowLong(Handle, GWL_EXSTYLE, GetWindowLong(Handle, GWL_EXSTYLE) | WS_EX_LAYERED | WS_EX_TRANSPARENT);
            
            SetupDefaultBuffList();
            _prohibitedImage = Image.FromFile(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Assets", "Images", "prohibited.png"));
            
            // Start a timer to continuously monitor the target window size and position
            var timer = new Timer();
            timer.Interval = 100; // Adjust the interval as needed
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
	        // Resize and reposition the overlay window based on the target window rectangle
	        _roClient = ClientSingleton.GetClient();
	        if (_roClient == null)
	        {
		        Bounds = new Rectangle(512, 512, 512, 512);
		        return;
	        }

	        // Get the handle of the foreground window
	        IntPtr foregroundWindowHandle = GetForegroundWindow();

	        // Check if the roClient window is unfocused
	        if (foregroundWindowHandle != _roClient.process.MainWindowHandle)
	        {
		        Bounds = new Rectangle(0, 0, 0, 0); // Set rectangle size to 0 if unfocused
		        return;
	        }
	        
	        var targetWindowHandle = _roClient.process.MainWindowHandle;
	        var rect = new RECT();
	        GetWindowRect(targetWindowHandle, out rect);
	        Bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
	        
	        var middleX = ClientRectangle.Left + (ClientRectangle.Width / 2);
	        var middleY = ClientRectangle.Top + (ClientRectangle.Height / 2);
	        _middleOfScreen = new Point(middleX, middleY);
	        
	        if (_activeBuffs == null) return;
	        for (int i = 0; i < Constants.MAX_BUFF_LIST_INDEX_SIZE - 1; i++)
	        {
		        if (_roClient.CurrentBuffStatusCode(i) != _activeBuffs[i]) Invalidate();
	        }
        }

        private uint[] _activeBuffs;
        
        // Override the OnPaint method to draw a border around the form
        protected override void OnPaint(PaintEventArgs e)
        {
	        base.OnPaint(e);

	        _elementalsBuffs = Buff.GetElementalsBuffs();

	        _activeBuffs = new uint[Constants.MAX_BUFF_LIST_INDEX_SIZE];
	        Console.WriteLine("Listing Buffs...");

	        for (int i = 0; i < Constants.MAX_BUFF_LIST_INDEX_SIZE - 1; i++)
	        {
		        if (_roClient == null) return;
		        var activeBuff = _roClient.CurrentBuffStatusCode(i);
    
		        if (activeBuff != uint.MaxValue)
		        {
			        bool found = false;
			        foreach (EffectStatusIDs statusID in Enum.GetValues(typeof(EffectStatusIDs)))
			        {
				        if ((uint)statusID == activeBuff)
				        {
					        Console.WriteLine("Active Buff: " + statusID);
					        found = true;
					        break;
				        }
			        }
			        if (!found)
			        {
				        Console.WriteLine("Active Buff: " + activeBuff);
			        }
		        }
    
		        _activeBuffs[i] = activeBuff;
	        }
	        
	        var iconPoint = _middleOfScreen;
	        var paddingActive = 0;
	        var paddingInactive = 0;

	        foreach (var trackedBuff in _trackedBuffs)
	        {
		        var isBuffPresent = false;
		        for (int i = 0; i < Constants.MAX_BUFF_LIST_INDEX_SIZE - 1; i++)
		        {
			        var curBuff = _roClient.CurrentBuffStatusCode(i);
			        if (curBuff == (uint)trackedBuff.StatusIDs)
			        {
				        // Buff is present in the list
				        isBuffPresent = true;
				        if (trackedBuff.ShowActive)
				        {
					        // Display the icon if it's set to be shown when active
					        iconPoint = new Point(_middleOfScreen.X - 64, _middleOfScreen.Y + paddingActive);
					        e.Graphics.DrawImage(trackedBuff.Icon, iconPoint);
					        paddingActive -= 26;
				        }
				        break; // No need to continue searching if the buff is found
			        }
		        }
    
		        // If the buff is not present and it's set to be shown when not active
		        if (!isBuffPresent && !trackedBuff.ShowActive)
		        {
			        iconPoint = new Point(_middleOfScreen.X + 64, _middleOfScreen.Y + paddingInactive);
			        e.Graphics.DrawImage(trackedBuff.Icon, iconPoint);
			        e.Graphics.DrawImage(_prohibitedImage, iconPoint); // Draw prohibited image
			        paddingInactive -= 26;
		        }
	        }
        }

        // P/Invoke declarations for Win32 functions
        private const int GWL_EXSTYLE = -20;

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
    }
}
