using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using _4RTools.Model;
using _4RTools.Resources._4RTools;
using _4RTools.Utils;

namespace _4RTools.Overlay
{
	public partial class OverlayForm : Form, IObserver
    {
        private const int WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;
        
        private Pen borderPen = new Pen(Color.Red, 2); // Define a red pen for drawing the border
        
        private Client _roClient;
        private OverlayGroup _testGroup;
        private bool isEnabled;

        // Hardcoded bullshit
        private void SetupDefaultBuffList()
        {
	        _testGroup = new OverlayGroup();
	        _testGroup.Position = new Point(36, 0);
	        
	        _testGroup.AddBuff(new OverlayBuff(EffectStatusIDs.KAUPE, "kaupe.png", false));
	        _testGroup.AddBuff(new OverlayBuff(EffectStatusIDs.PROVOKE, "provoke.png", false));
	        _testGroup.AddBuff(new OverlayBuff(EffectStatusIDs.SPRINT, "sprint.png", false));
	        
	        _testGroup.AddBuff(new OverlayBuff(EffectStatusIDs.PROPERTYGROUND, Icons.tk_mild_earth, true));
	        _testGroup.AddBuff(new OverlayBuff(EffectStatusIDs.PROPERTYFIRE, Icons.tk_mild_fire, true));
	        _testGroup.AddBuff(new OverlayBuff(EffectStatusIDs.PROPERTYWATER, Icons.tk_mild_water, true));
	        _testGroup.AddBuff(new OverlayBuff(EffectStatusIDs.PROPERTYWIND, Icons.tk_mild_wind, true));
	        _testGroup.AddBuff(new OverlayBuff(EffectStatusIDs.PROPERTYTELEKINESIS, Icons.tk_mild_ghost, true));
	        _testGroup.AddBuff(new OverlayBuff(EffectStatusIDs.ASPERSIO, Icons.tk_mild_holy, true));
	        _testGroup.AddBuff(new OverlayBuff(EffectStatusIDs.PROPERTYDARK, Icons.tk_mild_shadow, true));
        }

        public OverlayForm(Subject subject)
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
            
            // Start a timer to continuously monitor the target window size and position
            var timer = new Timer();
            timer.Interval = 100; // Adjust the interval as needed
            timer.Tick += Timer_Tick;
            timer.Start();
            
            subject.Attach(this);
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
	        var windowRect = new RECT();
	        GetWindowRect(targetWindowHandle, out windowRect);
	        Bounds = new Rectangle(windowRect.Left, windowRect.Top, windowRect.Right - windowRect.Left, windowRect.Bottom - windowRect.Top);
	        
	        _testGroup.Reset();
	        _testGroup.Update(_roClient);
	        if (_testGroup.IsDirty)
	        {
		        Invalidate();
	        }
        }
        
        public void Update(ISubject subject)
        {
	        switch ((subject as Subject).Message.code)
	        {
		        case MessageCode.TURN_ON:
			        isEnabled = true;
			        Invalidate();
			        break;
		        case MessageCode.TURN_OFF:
			        isEnabled = false;
			        Invalidate();
			        break;
	        }
        }
        
        // Override the OnPaint method to draw a border around the form
        protected override void OnPaint(PaintEventArgs e)
        {
	        base.OnPaint(e);
	        
	        if(!isEnabled) return;
	        if (_roClient == null) return; //Skip drawing if there is no client

	        _testGroup.Draw(e, ClientRectangle);
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
