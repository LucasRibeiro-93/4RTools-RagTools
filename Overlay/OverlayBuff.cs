using System.Collections.Generic;
using System.Drawing;
using System.IO;
using _4RTools.Utils;

namespace _4RTools.Overlay
{
    public class OverlayBuff
    {
        public uint BuffID;
        public Image Icon;
        public bool ShowActive;

        internal bool IsActive;
        internal bool WasActiveLastDraw;

        public OverlayBuff(uint buffId, string iconName, bool showActive)
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            var imagePath = Path.Combine(path, "Assets", "Images", iconName);
		        
            BuffID = buffId;
            Icon = Image.FromFile(imagePath);
            ShowActive = showActive;
        }
	        
        public OverlayBuff(uint buffId, Image icon, bool showActive)
        {
            BuffID = buffId;
            Icon = icon;
            ShowActive = showActive;
        }
        
        public OverlayBuff(EffectStatusIDs buffId, string iconName, bool showActive) : this((uint) buffId, iconName, showActive)
        {
        }
	        
        public OverlayBuff(EffectStatusIDs buffId, Image icon, bool showActive) : this((uint) buffId, icon, showActive)
        {
        }

        public void Update(HashSet<uint> activeBuffs)
        {
            WasActiveLastDraw = IsActive;
            
            if (activeBuffs.Contains(BuffID))
            {
                IsActive = ShowActive;
            }
            else
            {
                IsActive = !ShowActive;
            }
        }
    }
}