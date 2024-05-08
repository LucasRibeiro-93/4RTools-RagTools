using System;
using System.Windows.Forms;
using _4RTools.Model;
using _4RTools.Overlay;
using _4RTools.Utils;

namespace _4RTools.Forms
{
    public partial class OverlayEditorForm : Form, IObserver
    {
        private OverlayCanvas _overlayCanvas;
        
        public OverlayEditorForm(Subject subject)
        {
            InitializeComponent();
            
            subject.Attach(this);
        }

        private void PlaceholderSave_Click(object sender, EventArgs e)
        {
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().OverlayCanvas);
        }

        public void Update(ISubject subject)
        {
            switch ((subject as Subject).Message.code)
            {
                case MessageCode.TURN_ON:
                    _overlayCanvas.Start();
                    break;
                case MessageCode.TURN_OFF:
                    _overlayCanvas.Stop();
                    break;
                case MessageCode.PROFILE_CHANGED:
                    _overlayCanvas = ProfileSingleton.GetCurrent().OverlayCanvas;
                    break;
            }
        }
    }
}