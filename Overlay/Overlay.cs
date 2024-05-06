using System;
using System.Drawing;
using System.Windows.Forms;

namespace OverlayWindowExample
{
	public partial class OverlayForm : Form
	{
		public OverlayForm()
		{
			InitializeComponent();
            
			// Set the window to be transparent
			this.BackColor = Color.Magenta; // You can change the color to transparent, but for demonstration purposes, I set it to magenta
			this.TransparencyKey = Color.Magenta;
			this.FormBorderStyle = FormBorderStyle.None;
			this.StartPosition = FormStartPosition.Manual;
			this.TopMost = true;
			this.Bounds = Screen.PrimaryScreen.Bounds;
		}
	}
}