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
        
        private Image _icon;

        public Image Icon
        {
            get
            {
                if (_icon == null)
                {
                    try
                    {
                        _icon = (Image) Icons.ResourceManager.GetObject(IconId);
                    }
                    catch
                    {
                        var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                        var imagePath = Path.Combine(path, "Assets", "Images", IconId);
                        _icon = Image.FromFile(imagePath);
                    }
                }

                return _icon;
            }
        }

        public OverlayBuff()
        {
            BuffID = uint.MaxValue;
            ShowActive = true;
            IconId = "";
        }
        
        public OverlayBuff(uint buffId, string iconName, bool showActive)
        {
            BuffID = buffId;
            ShowActive = showActive;
            IconId = iconName;


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