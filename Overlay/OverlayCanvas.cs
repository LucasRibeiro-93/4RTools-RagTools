using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using _4RTools.Model;
using _4RTools.Resources._4RTools;
using _4RTools.Utils;

namespace _4RTools.Overlay
{
    public class OverlayCanvas
    {
        public bool IsEnabled;
        
        public readonly Image ProhibitedImage = Image.FromFile(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Assets", "Images", "prohibited.png"));

        private List<OverlayGroup> _groups = new List<OverlayGroup>();

        public OverlayCanvas()
        {
            var buffsGroup = new OverlayGroup(this)
            {
                Position = new Point(36, 0),
                GrowUp = true,
                VerticalFirst = true
            };

            //buffsGroup.AddBuff(new OverlayBuff(EffectStatusIDs.KAUPE, "kaupe.png", false));
            buffsGroup.AddBuff(new OverlayBuff(EffectStatusIDs.PROVOKE, "provoke.png", false));
            buffsGroup.AddBuff(new OverlayBuff(EffectStatusIDs.OVERTHRUST, Icons.bs_overthrust, false));
            buffsGroup.AddBuff(new OverlayBuff(EffectStatusIDs.SPRINT, "sprint.png", false));
	        
            _groups.Add(buffsGroup);

            var elementGroup = new OverlayGroup(this)
            {
                Position = new Point(0, 36)
            };

            elementGroup.AddBuff(new OverlayBuff(EffectStatusIDs.PROPERTYGROUND, Icons.tk_mild_earth, true));
            elementGroup.AddBuff(new OverlayBuff(EffectStatusIDs.PROPERTYFIRE, Icons.tk_mild_fire, true));
            elementGroup.AddBuff(new OverlayBuff(EffectStatusIDs.PROPERTYWATER, Icons.tk_mild_water, true));
            elementGroup.AddBuff(new OverlayBuff(EffectStatusIDs.PROPERTYWIND, Icons.tk_mild_wind, true));
            elementGroup.AddBuff(new OverlayBuff(EffectStatusIDs.PROPERTYTELEKINESIS, Icons.tk_mild_ghost, true));
            elementGroup.AddBuff(new OverlayBuff(EffectStatusIDs.ASPERSIO, Icons.tk_mild_holy, true));
            elementGroup.AddBuff(new OverlayBuff(EffectStatusIDs.PROPERTYDARK, Icons.tk_mild_shadow, true));
	        
            _groups.Add(elementGroup);
        }

        public bool IsDirty { get; private set; }

        public void Update(Client ROClient)
        {
            IsDirty = false;
            foreach (var group in _groups)
            {
                group.Update(ROClient);

                IsDirty |= group.IsDirty;
            }
        }

        public void Draw(PaintEventArgs e, Rectangle clientRect)
        {
            if(!IsEnabled) return;
            
            foreach (var group in _groups)
            {
                group.Draw(e, clientRect);
            }

            IsDirty = false;
        }
    }
}