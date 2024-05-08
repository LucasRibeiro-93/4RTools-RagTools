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
        
        private Pen _borderPen = new Pen(Color.Red, 2); // Define a red pen for drawing the border
        
        private Client _roClient;

        private OverlayCanvas _canvas = new OverlayCanvas();

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
            
            // Start a timer to continuously monitor the target window size and position
            var timer = new Timer();
            timer.Interval = 100; // Adjust the interval as needed
            timer.Tick += TimerUpdate;
            timer.Start();
            
            subject.Attach(this);
        }

        private void TimerUpdate(object sender, EventArgs e)
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

	        _canvas.Update(_roClient);
	        
	        if (_canvas.IsDirty)
	        {
		        Invalidate();
	        }
        }
        
        public void Update(ISubject subject)
        {
	        switch ((subject as Subject).Message.code)
	        {
		        case MessageCode.TURN_ON:
			        _canvas.IsEnabled = true;
			        Invalidate();
			        break;
		        case MessageCode.TURN_OFF:
			        _canvas.IsEnabled = false;
			        Invalidate();
			        break;
		        case MessageCode.PROFILE_CHANGED:
			        _canvas = ProfileSingleton.GetCurrent().OverlayCanvas;
			        break;
	        }
        }
        
        // Override the OnPaint method to draw a border around the form
        protected override void OnPaint(PaintEventArgs e)
        {
	        base.OnPaint(e);

	        _canvas.Draw(e, ClientRectangle);
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
