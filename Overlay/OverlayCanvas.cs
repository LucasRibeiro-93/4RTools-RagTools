using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using _4RTools.Model;
using Newtonsoft.Json;
using Action = _4RTools.Model.Action;

namespace _4RTools.Overlay
{
    public class OverlayCanvas : Action
    {
        private static OverlayForm _overlay;
        
        [NonSerialized]
        public bool IsEnabled;
        
        public readonly List<OverlayGroup> Groups = new List<OverlayGroup>();

        private readonly ClientContext _clientContext = new ClientContext();
        
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

        [JsonIgnore]
        public bool IsDirty { get; private set; }

        public void Update(Client ROClient)
        {
            _clientContext.ROClient = ROClient;
            _clientContext.FetchAllClientData();
            
            foreach (var group in Groups)
            {
                group.Update(_clientContext);

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

        public void MarkDirty()
        {
            IsDirty = true;
        }
    }
}