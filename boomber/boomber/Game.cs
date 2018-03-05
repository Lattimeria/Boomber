using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boomber
{
    class Game
    {
        public List<BlockBase> Blocks = new List<BlockBase>();
        Random rnd = new Random();

        public void Start(int width, int height, int sizeCell)
        {
            int blockX = width-1, blockY = height-1;
            AddBlock(blockX, blockY);
            

        }
        void AddBlock(int x, int y)
        {
            int blockCount = 0;
            for (int i = 0; i < y; i++)
            {
                Blocks.Add(new GreyBlock(0, i));
                Blocks.Add(new GreyBlock(x, i));
            }
            for (int i = 0; i < x + 1; i++)
            {
                Blocks.Add(new GreyBlock(i, 0));
                Blocks.Add(new GreyBlock(i, y));
            }
            for (int i = 1; i < y; i++)
            {
                for (int j = 1; j < x; j++)
                {
                    if (i % 2 == 0 && j % 2 == 0)
                        Blocks.Add(new GreyBlock(j, i));

                    blockCount++;
                }
            }

            for (int k = 0; k < blockCount / 3; k++)
            {
                int X = rnd.Next(1, x);
                int Y = rnd.Next(1, y);

                for (int i = 0; i < Blocks.Count; i++)
                {
                    if (Blocks[i].CheckCoordinate(X, Y) == false)
                        Blocks.Add(new PinkBlock(X, Y));
                    else
                        k--;
                }
            }
        }
        public void AddBomb(int X, int Y)
        {
            bool notCoinc = true;

            for (int i = 0; i < Blocks.Count; i++)
            {
                if (Blocks[i].CheckCoordinate(X,Y)==true)
                { notCoinc = false; break; }

            }
            if (notCoinc == true)
                Blocks.Add(new Bomb(X, Y));
        }
        public Coordinate CheckConjunction(int X, int Y, List<BlockBase> L)
        {
            Coordinate coord = new Coordinate(X,Y);
            for (int i = 0; i < L.Count; i++)
            {
                if (X == L[i].BlockCoordX && Y == L[i].BlockCoordY)
                    return coord;

            }
            return coord;
        }
        public void Draw(System.Drawing.Graphics graphics,int S, System.Drawing.Pen pen)
        {
            for(int i=0;i<Blocks.Count;i++)
            {
                Blocks[i].Draw(graphics, S, pen);
            }
        }
    }
    class Coordinate
    {
        public int X;
        public int Y;
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    
}
