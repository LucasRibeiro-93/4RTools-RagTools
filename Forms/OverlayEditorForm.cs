using System;
using System.Windows.Forms;
using _4RTools.Model;
using _4RTools.Utils;

namespace _4RTools.Forms
{
    public partial class OverlayEditorForm : Form
    {
        public OverlayEditorForm(Subject subject)
        {
            InitializeComponent();
        }

        private void PlaceholderSave_Click(object sender, EventArgs e)
        {
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().OverlayCanvas);
        }
    }
}