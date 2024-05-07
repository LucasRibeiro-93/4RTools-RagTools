using System.Drawing;
using System.IO;
using _4RTools.Utils;

namespace _4RTools.Overlay
{
    public class OverlayBuff
    {
        public EffectStatusIDs StatusIDs;
        public Image Icon;
        public bool ShowActive;

        internal bool IsActive;
        internal bool WasActiveLastDraw;

        public OverlayBuff(EffectStatusIDs statusIDs, string iconName, bool showActive)
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            var imagePath = Path.Combine(path, "Assets", "Images", iconName);
		        
            StatusIDs = statusIDs;
            Icon = Image.FromFile(imagePath);
            ShowActive = showActive;
        }
	        
        public OverlayBuff(EffectStatusIDs statusIDs, Image icon, bool showActive)
        {
            StatusIDs = statusIDs;
            Icon = icon;
            ShowActive = showActive;
        }
    }
}