using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using _4RTools.Resources._4RTools;
using _4RTools.Utils;

namespace _4RTools.Overlay
{
    public class OverlayBuff
    {
        public uint BuffID = 0;
        public bool ShowActive = false;
        public string IconId = "";

        internal bool IsActive;
        internal bool WasActiveLastDraw;
        
        private Image _icon;

        public string DisplayName
        {
            get
            {
                if (Enum.IsDefined(typeof(EffectStatusIDs), BuffID))
                {
                    return Enum.GetName(typeof(EffectStatusIDs), BuffID);
                }
                else
                {
                    return BuffID.ToString();
                }
            }
        }

        public Image Icon
        {
            get
            {
                if (_icon == null)
                {
                    _icon = (Image) Icons.ResourceManager.GetObject(IconId);
                    
                    if(_icon == null)
                    {
                        try
                        {
                            var path = Directory.GetCurrentDirectory();
                            var imagePath = Path.Combine(path, "CustomIcons", IconId);
                            _icon = Image.FromFile(imagePath);
                        }
                        catch
                        {
                            _icon = Icons.prohibited;
                        }
                    }
                }

                return _icon;
            }
        }

        public OverlayBuff()
        {
            BuffID = 0;
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

        public void InvalidateIcon()
        {
            _icon = null;
        }
    }
}