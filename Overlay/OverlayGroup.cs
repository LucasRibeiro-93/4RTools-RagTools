using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using _4RTools.Model;
using _4RTools.Utils;

namespace _4RTools.Overlay
{
    public class OverlayGroup
    {
        public Point Position = new Point();

        public int Size = 24;
        public int Spacing = 2;
        
        public bool GrowUp;
        public bool GrowLeft;
        public bool VerticalFirst = true;
        
        public int MaxElementsX = 3;
        public int MaxElementsY = 5;
        
        public List<OverlayBuff> _trackedBuffs = new List<OverlayBuff>();

        internal bool IsDirty;
        private HashSet<uint> _activeBuffs = new HashSet<uint>();

        public void AddBuff(OverlayBuff buff)
        {
            _trackedBuffs.Add(buff);
        }

        internal void Update(Client roClient)
        {
            _activeBuffs.Clear();
            
            for (var i = 0; i < Constants.MAX_BUFF_LIST_INDEX_SIZE - 1; i++)
            {
                var activeBuff = roClient.CurrentBuffStatusCode(i);
                if (activeBuff == uint.MaxValue) continue; //Ignore invalid buffs

                _activeBuffs.Add(activeBuff);
            }

            foreach (var buff in _trackedBuffs)
            {
                buff.Update(_activeBuffs);
                
                if (buff.IsActive != buff.WasActiveLastDraw)
                {
                    IsDirty = true;
                }
            }
        }

        internal void Draw(PaintEventArgs e, Rectangle clientRect)
        {
            var middleX = clientRect.Left + (clientRect.Width / 2);
            var middleY = clientRect.Top + (clientRect.Height / 2);
            var startPosition = new Point(middleX + Position.X, middleY + Position.Y); //TODO: actual anchoring
            var padding = Size + Spacing;
            
            var countX = 0;
            var countY = 0;

            foreach (var buff in _trackedBuffs)
            {
                if (!buff.IsActive) continue;

                var posX = GrowLeft ? -countX * padding : countX * padding;
                var posY = GrowUp ? -countY * padding : countY * padding;
                
                var buffPosition = new Rectangle(startPosition.X + posX, startPosition.Y + posY, Size, Size);
                
                e.Graphics.DrawImage(buff.Icon, buffPosition);
                if (!buff.ShowActive)
                {
                    e.Graphics.DrawImage(OverlayUtils.ProhibitedImage, buffPosition);
                }

                if (VerticalFirst)
                {
                    countY++;
                    if (countY >= MaxElementsY)
                    {
                        countY = 0;
                        countX++;
                        if(countX >= MaxElementsX)
                            break;
                    }
                }
                else
                {
                    countX++;
                    if (countX >= MaxElementsX)
                    {
                        countX = 0;
                        countY++;
                        if(countY >= MaxElementsY)
                            break;
                    }
                }
            }

            IsDirty = false;
        }
    }
}