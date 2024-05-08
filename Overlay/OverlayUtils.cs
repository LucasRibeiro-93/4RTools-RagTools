using System;
using System.Drawing;
using System.IO;

namespace _4RTools.Overlay
{
    public static class OverlayUtils
    {
        [NonSerialized]
        public static readonly Image ProhibitedImage = Image.FromFile(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Assets", "Images", "prohibited.png"));
    }
}