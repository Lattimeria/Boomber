using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boomber
{
    public abstract class BlockBase
    {
        public int BlockCoordX;
        public int BlockCoordY;

        protected BlockBase(int x, int y)
        {
            BlockCoordX = x;
            BlockCoordY = y;

        }

        public bool CheckCoordinate(int X, int Y)
        {
            if (X == BlockCoordX && Y == BlockCoordY)
                return true;
            else
                return false;
        }
        public abstract void Draw(System.Drawing.Graphics graphics, int S, System.Drawing.Pen blackPen);
        /*
                public void Draw(System.Drawing.Graphics graphics, int S, System.Drawing.Pen blackPen)
                {
                    DrawBlock(graphics, S, blackPen);
                }
                void DrawBlock(System.Drawing.Graphics graphics, int S, System.Drawing.Pen blackPen)
                {

                    for (int i = 0; i < BlockCoordinate.Count; i++)
                    {
                        System.Drawing.Brush style = System.Drawing.Brushes.Gray;
                        if (BlockCoordinate[i].Type == 1)
                            style = System.Drawing.Brushes.Gray;

                        if (BlockCoordinate[i].Type == 2)
                            style = System.Drawing.Brushes.Pink;

                        if (BlockCoordinate[i].Type == 0)
                            style = System.Drawing.Brushes.Black;

                        var drawRectangle = new System.Drawing.Rectangle(BlockCoordinate[i].BlockCoordX * S, BlockCoordinate[i].BlockCoordY * S, S, S);

                        graphics.FillRectangle(style, drawRectangle);
                        graphics.DrawRectangle(blackPen, drawRectangle);

                    }
                }

            }*/
    }
}

