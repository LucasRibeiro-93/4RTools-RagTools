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

        private OverlayForm _overlay;
        
        public OverlayCanvas()
        {
            _overlay = new OverlayForm(this);
            _overlay.Show();
        }

        public bool IsDirty { get; private set; }

        public void Update(Client ROClient)
        {
            IsDirty = false;
            foreach (var group in Groups)
            {
                group.Update(ROClient);

                IsDirty |= group.IsDirty;
            }
        }

        public void Draw(PaintEventArgs e, Rectangle clientRect)
        {
            if(!IsEnabled) return;
            
            foreach (var group in Groups)
            {
                group.Draw(e, clientRect);
            }

            IsDirty = false;
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
    }
}