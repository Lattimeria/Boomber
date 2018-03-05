using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boomber
{
    public class GreyBlock : BlockBase
    {
        // неразрушаемый блок
        public GreyBlock(int x,int y) : base(x, y) { }
        public override void Draw(Graphics graphics, int S, Pen blackPen)
        {
            Brush style = Brushes.Gray;

            var drawRectangle = new Rectangle(BlockCoordX * S, BlockCoordY * S, S, S);

            graphics.FillRectangle(style, drawRectangle);
            graphics.DrawRectangle(blackPen, drawRectangle);
        }
    }
    public class PinkBlock : BlockBase
    {
        // разрушаемый блок
        public PinkBlock(int x, int y) : base(x, y) { }
        public override void Draw(Graphics graphics, int S, Pen blackPen)
        {
            Brush style = Brushes.Pink;

            var drawRectangle = new Rectangle(BlockCoordX * S, BlockCoordY * S, S, S);

            graphics.FillRectangle(style, drawRectangle);
            graphics.DrawRectangle(blackPen, drawRectangle);
        }
    }
    public class Bomb : BlockBase
    {
        //бомба
        public Bomb(int x, int y) : base(x, y) { }
        public override void Draw(Graphics graphics, int S, Pen blackPen)
        {
            Brush style = Brushes.Black;

            var drawRectangle = new Rectangle(BlockCoordX * S, BlockCoordY * S, S, S);

            graphics.FillRectangle(style, drawRectangle);
            graphics.DrawRectangle(blackPen, drawRectangle);
        }
    }
}
