using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boomber
{
    class Block
    {
        public List<BlockCoordinate> BlockCoordinate;
        public int blockCount = 0;
        Random rnd = new Random();

        public Block(int coordX, int coordY)
        {
            AddBlock(coordX, coordY);
            
        }
        void AddBlock(int x, int y)
        {
            int t = 1;
            BlockCoordinate = new List<BlockCoordinate>();

            for (int i = 0; i < y; i++)
            {
                BlockCoordinate.Add(new BlockCoordinate(0, i, t));
                BlockCoordinate.Add(new BlockCoordinate(x, i, t));
            }
            for (int i = 0; i < x + 1; i++)
            {
                BlockCoordinate.Add(new BlockCoordinate(i, 0, t));
                BlockCoordinate.Add(new BlockCoordinate(i, y, t));
            }
            for (int i = 1; i < y; i++)
            {
                for (int j = 1; j < x; j++)
                {
                    if (i % 2 == 0 && j % 2 == 0)
                        BlockCoordinate.Add(new BlockCoordinate(j, i, t));

                    blockCount++;
                }
            }

            for (int k = 0; k < blockCount / 3; k++)
            {
                bool notCoinc = true;
                int Y = rnd.Next(1, y);
                int X = rnd.Next(1, x);
                for (int i = 0; i < BlockCoordinate.Count; i++)
                {
                    if (Y == BlockCoordinate[i].BlockCoordY && X == BlockCoordinate[i].BlockCoordX)
                    { notCoinc = false; k--; break; }

                }
                if (notCoinc == true)
                    BlockCoordinate.Add(new BlockCoordinate(X, Y, 2));

            }
        }
        public void AddBomb(int X,int Y)
        {
            bool notCoinc = true;
            int t = 0;
            for (int i = 0; i < BlockCoordinate.Count; i++)
            {
                if (Y == BlockCoordinate[i].BlockCoordY && X == BlockCoordinate[i].BlockCoordX)
                { notCoinc = false; break; }

            }
            if (notCoinc == true)
                BlockCoordinate.Add(new BlockCoordinate(X, Y, t));

        }
       
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

    }
}
class BlockCoordinate
{
    public int BlockCoordX;
    public int BlockCoordY;
    public int Type; // 1 - уничтожается - розовый, 2 - не уничтожается - серый, 0 - бомба - черный

    public BlockCoordinate(int x, int y, int t)
    {
        BlockCoordX = x;
        BlockCoordY = y;
        Type = t;
    }
}

