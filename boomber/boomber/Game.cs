using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boomber
{
    class Game
    {
        Block startBlock;
        Random rand = new Random();
        public void Start(int width, int height, int sizeCell)
        {
            // отрисовка границ
            int blockX = width-1, blockY = height-1;
            startBlock = new Block(blockX, blockY);
            

        }

        
        public void Draw(System.Drawing.Graphics graphics,int S, System.Drawing.Pen pen)
        {
            startBlock.Draw(graphics, S,pen);

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
