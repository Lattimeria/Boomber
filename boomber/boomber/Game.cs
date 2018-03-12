using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace boomber
{
    class Game
    {
        public List<BlockBase> Blocks = new List<BlockBase>();
        Random rnd = new Random();
        public int MaxCountBomb = 1; // число возможных бомб
        public void Start(int width, int height, int sizeCell)
        {
            int blockX = width - 1, blockY = height - 1;
            GenerateBlocks(blockX, blockY);


        }
        void GenerateBlocks(int fieldWidth, int fieldHeight)
        {

            for (int i = 0; i < fieldHeight; i++)
            {
                Blocks.Add(new GreyBlock(0, i));
                Blocks.Add(new GreyBlock(fieldWidth, i));
            }
            for (int i = 0; i < fieldWidth + 1; i++)
            {
                Blocks.Add(new GreyBlock(i, 0));
                Blocks.Add(new GreyBlock(i, fieldHeight));
            }


            for (int i = 1; i < fieldHeight; i++)
            {
                for (int j = 1; j < fieldWidth; j++)
                {
                    if (i % 2 == 0 && j % 2 == 0)
                        Blocks.Add(new GreyBlock(j, i));
                }
            }

            int innerBlockCount = fieldWidth * fieldHeight;

            var destructibleBlockCount = innerBlockCount / 3;
            for (int k = 0; k < destructibleBlockCount; k++)
            {
                int X = rnd.Next(1, fieldWidth);
                int Y = rnd.Next(1, fieldHeight);

                if (GetBlock(X, Y) == null)
                    Blocks.Add(new PinkBlock(X, Y));
                else
                    k--;
            }
        }

        public int CurrentCountBomb = 0; // текущее количество бомб
        public void AddBomb(int x, int y)
        {
            bool isCellFree = true;

            for (int i = 0; i < Blocks.Count; i++)
            {
                if (Blocks[i].CheckCoordinate(x, y) == true)
                {
                    isCellFree = false;
                    break;
                }
            }
            if (isCellFree == true)
            {
                var bomb = new Bomb(x, y);
                bomb.OnExplode += this.BombExplode;

                Blocks.Add(bomb);
                CurrentCountBomb++;
            }

        }
        void BombExplode(Bomb bomb)
        {
            int x = bomb.BlockCoordX;
            int y = bomb.BlockCoordY;
            Blocks.Remove(bomb);

            AddBoom(x + 1, y);
            AddBoom(x - 1, y);
            AddBoom(x, y + 1);
            AddBoom(x, y - 1);

            
            CurrentCountBomb--;
        }
        void AddBoom(int x, int y)//nazvanie
        {
            var boom = new BombBoom(x, y);
            boom.OnExplode += this.BoomExplore;

            if (GetBlock(x, y) == null)
            {
                Blocks.Add(boom);
            }

            if (GetBlock(x, y) is PinkBlock)
            {
                Blocks.Remove(GetBlock(x, y));
                Blocks.Add(boom);
            }
            
        }
        void BoomExplore(BombBoom boom) // ExplosionEffectDecay
        {
            Blocks.Remove(boom);
        }

        public BlockBase GetBlock(int x, int y)
        {
            for (int i = 0; i < Blocks.Count; i++)
            {
                if (x == Blocks[i].BlockCoordX && y == Blocks[i].BlockCoordY)
                    return Blocks[i];
            }
            return null;
        }

        public void Draw(System.Drawing.Graphics graphics, int cellSize, float deltaT)
        {
            //for (int i = 0; i < Blocks.Count; i++)
            //{
            //     Blocks[i].Draw(graphics, cellSize, deltaT);
            // }
            var initialBlocks = new List<BlockBase>(Blocks);
            foreach(var block in initialBlocks)
            {
                if (Blocks.Contains(block))
                    block.Draw(graphics, cellSize, deltaT);
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
