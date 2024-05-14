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
	public partial class OverlayForm : Form
    {
        private const int WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;
        
        private Client _roClient;

        public OverlayCanvas Canvas;

        private bool _isConfigWindowFocused;

        public OverlayForm(OverlayCanvas canvas)
        {
            InitializeComponent();

            Canvas = canvas;
            
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
        }

        private void TimerUpdate(object sender, EventArgs e)
        {
	        // Resize and reposition the overlay window based on the target window rectangle
	        _roClient = ClientSingleton.GetClient();
	        if (_roClient == null)
	        {
		        Bounds = new Rectangle(0, 0, 0, 0);
		        return;
	        }

	        // Get the handle of the foreground window
	        var foregroundWindowHandle = GetForegroundWindow();
	        
	        const int nChars = 256;
	        var windowTitle = new string(' ', nChars);
	        GetWindowText(foregroundWindowHandle, windowTitle, nChars);
	        windowTitle = windowTitle.Trim();
	        
	        // Check if either the roClient window or the main window of the application is focused
	        var isClientFocused = foregroundWindowHandle == _roClient.process.MainWindowHandle;
	        _isConfigWindowFocused = windowTitle.Contains(AppConfig.Name + " - " + AppConfig.Version);
	        
	        if (!isClientFocused && !_isConfigWindowFocused)
	        {
		        Bounds = new Rectangle(0, 0, 0, 0); // Set rectangle size to 0 if unfocused
		        return;
	        }

	        GetWindowRect(_roClient.process.MainWindowHandle, out var windowRect);
	        Bounds = new Rectangle(windowRect.Left, windowRect.Top, windowRect.Right - windowRect.Left, windowRect.Bottom - windowRect.Top);
	        
	        if(!Canvas.IsEnabled) return;
	        
	        Canvas.Update(_roClient);
	        
	        if (Canvas.IsDirty)
	        {
		        Invalidate();
	        }
	        
	        Invalidate();
        }

        private int[] _addresses = new[]
        {
	        15252972,
	        15252996,

	        15253420,
	        15253444,

	        15253644,
	        15253668,

	        15254316,
	        15254340,

	        15254540,
	        15254564,

	        15254764,
	        15254788,

	        15254988,
	        15255012,
        };
        
        // Override the OnPaint method to draw a border around the form
        protected override void OnPaint(PaintEventArgs e)
        {
	        base.OnPaint(e);

	        Canvas.Draw(e, ClientRectangle);

	        if (_roClient ==  null) return;
	        // Calculate position for drawing text
	        var x = 10; // x-coordinate
	        var y = 600; // y-coordinate
	        var backgroundRect = new Rectangle(x, y, 16, _addresses.Length * 16);
	        using (SolidBrush semiTransparentBlackBrush = new SolidBrush(Color.FromArgb(128, Color.Black)))
	        {
		        e.Graphics.FillRectangle(semiTransparentBlackBrush, backgroundRect);
	        }

	        // Define font and brush for drawing text
	        var font = new Font("Arial", 12);
	        var brush = Brushes.White;

	        for (int i = 0; i < _addresses.Length; i++)
	        {
		        var curAddress = _addresses[i];
		        e.Graphics.DrawString(_roClient.ReadMemory(curAddress).ToString(), font, brush, x, y);
		        y += 16;
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
        
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, string lpString, int nMaxCount);
        
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
