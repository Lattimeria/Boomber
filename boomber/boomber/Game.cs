using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boomber
{
    class Game
    {
        Block block;
        Random rand = new Random();
        public void Start(int width, int height, int sizeCell)
        {
            int blockX = width-1, blockY = height-1;
            block = new Block(blockX, blockY);
            

        }
        public void PlaseBomb(int X, int Y,int S)
        {
           block.AddBomb(X, Y);
        }
        
        public void Draw(System.Drawing.Graphics graphics,int S, System.Drawing.Pen pen)
        {
            block.Draw(graphics, S,pen);

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
