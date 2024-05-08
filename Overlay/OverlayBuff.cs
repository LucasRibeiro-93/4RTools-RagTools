using System.Collections.Generic;
using System.Drawing;
using System.IO;
using _4RTools.Resources._4RTools;
using _4RTools.Utils;

namespace _4RTools.Overlay
{
    public class OverlayBuff
    {
        public uint BuffID;
        public bool ShowActive;
        public string IconId;

        internal bool IsActive;
        internal bool WasActiveLastDraw;
        internal Image Icon;

        public OverlayBuff(uint buffId, string iconName, bool showActive)
        {
            BuffID = buffId;
            ShowActive = showActive;
            IconId = iconName;

            try
            {
                Icon = (Image) Icons.ResourceManager.GetObject(iconName);
            }
            catch
            {
                var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                var imagePath = Path.Combine(path, "Assets", "Images", iconName);
                Icon = Image.FromFile(imagePath);
            }
        }
        
        public OverlayBuff(EffectStatusIDs buffId, string iconName, bool showActive) : this((uint) buffId, iconName, showActive)
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