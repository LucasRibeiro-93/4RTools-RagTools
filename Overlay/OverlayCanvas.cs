using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using _4RTools.Model;
using _4RTools.Resources._4RTools;
using _4RTools.Utils;
using Newtonsoft.Json;
using Action = _4RTools.Model.Action;

namespace _4RTools.Overlay
{
    public class OverlayCanvas : Action
    {
        [NonSerialized]
        public bool IsEnabled;
        
        public List<OverlayGroup> Groups = new List<OverlayGroup>();

        private static OverlayForm _overlay;
        private bool _isDirty;
        
        public OverlayCanvas()
        {
            if (_overlay == null)
            {
                _overlay = new OverlayForm(this);
                _overlay.Show();
            }
            else
            {
                _overlay.Canvas = this;
            }
        }

        public bool IsDirty => _isDirty;

        public void Update(Client ROClient)
        {
            _isDirty = false;
            foreach (var group in Groups)
            {
                group.Update(ROClient);

                _isDirty |= group.IsDirty;
            }
        }

        public void Draw(PaintEventArgs e, Rectangle clientRect)
        {
            if(!IsEnabled) return;
            
            foreach (var group in Groups)
            {
                group.Draw(e, clientRect);
            }

            _isDirty = false;
        }

        public void Start()
        {
            IsEnabled = true;
            _overlay.Invalidate();
        }

        public void Stop()
        {
            IsEnabled = false;
            _overlay.Invalidate();
        }

        public string GetConfiguration()
        {
            return JsonConvert.SerializeObject(this);
        }

        public string GetActionName()
        {
            return "OverlayCanvas";
        }

        public void MarkDirty()
        {
            _isDirty = true;
        }
    }
}