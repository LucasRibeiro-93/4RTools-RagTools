﻿using System;
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
        public Point Position = new Point(); //TODO: Encapsulate this

        public int Size = 24;
        public int Spacing = 2;
        
        public bool GrowUp;
        public bool GrowLeft;
        public bool VerticalFirst = true;
        
        public int MaxElementsX = 3;
        public int MaxElementsY = 5;

        internal bool IsDirty;

        private OverlayCanvas _canvas;
        private Dictionary<uint, OverlayBuff> _trackedBuffs = new Dictionary<uint, OverlayBuff>();

        public OverlayGroup(OverlayCanvas canvas)
        {
            this._canvas = canvas;
        }

        public void AddBuff(OverlayBuff buff)
        {
            _trackedBuffs.Add((uint) buff.StatusIDs, buff); //TODO: Change buff.StatusIDs to uint
        }

        internal void Reset()
        {
            foreach (var buff in _trackedBuffs.Values)
            {
                buff.WasActiveLastDraw = buff.IsActive;
                buff.IsActive = !buff.ShowActive;
            }
        }

        internal void Update(Client roClient)
        {
            for (var i = 0; i < Constants.MAX_BUFF_LIST_INDEX_SIZE - 1; i++)
            {
                var activeBuff = roClient.CurrentBuffStatusCode(i);
                if (activeBuff == uint.MaxValue) continue; //Ignore invalid buffs
                
                if (_trackedBuffs.TryGetValue(activeBuff, out var trackedBuff))
                {
                    trackedBuff.IsActive = trackedBuff.ShowActive;
                }
            }

            foreach (var buff in _trackedBuffs.Values)
            {
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

            foreach (var buff in _trackedBuffs.Values)
            {
                if (!buff.IsActive) continue;

                var posX = GrowLeft ? -countX * padding : countX * padding;
                var posY = GrowUp ? -countY * padding : countY * padding;
                
                var buffPosition = new Rectangle(startPosition.X + posX, startPosition.Y + posY, Size, Size);
                
                e.Graphics.DrawImage(buff.Icon, buffPosition);
                if (!buff.ShowActive)
                {
                    e.Graphics.DrawImage(_canvas.ProhibitedImage, buffPosition);
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