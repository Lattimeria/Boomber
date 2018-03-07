using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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

        public bool CheckCoordinate(int x, int Y)
        {
            return x == BlockCoordX && Y == BlockCoordY;
        }
        public abstract void Draw(Graphics graphics, int S, Pen blackPen);
        
        protected void Draw(Graphics graphics, int S, Pen blackPen, Brush style)
        {
            var drawRectangle = new Rectangle(BlockCoordX * S, BlockCoordY * S, S, S);

            graphics.FillRectangle(style, drawRectangle);
            graphics.DrawRectangle(blackPen, drawRectangle);
        }
    }
}

