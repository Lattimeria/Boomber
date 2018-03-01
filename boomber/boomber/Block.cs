using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boomber
{
    class Block
    {
        public List<Coordinate> BlockCoordinateIndest;
        public List<Coordinate> BlockCoordinateDest;
        Random rnd = new Random();
        public int countBlock = 0;
        // 1 - уничтожается, 2 - не уничтожается, 0 - портал
        public Block(int sizeX, int sizeY) // 2
        {

            IndestructibleBlock(sizeX, sizeY);
            DestructibleBlock(sizeX, sizeY);
        }
        void IndestructibleBlock(int sizeX, int sizeY)
        {
            BlockCoordinateIndest = new List<Coordinate>();
            BlockCoordinateDest = new List<Coordinate>();

            for (int i = 0; i < sizeY; i++)
            {
                BlockCoordinateIndest.Add(new Coordinate(0, i));
                BlockCoordinateIndest.Add(new Coordinate(sizeX, i));
            }
            for (int i = 0; i < sizeX + 1; i++)
            {
                BlockCoordinateIndest.Add(new Coordinate(i, 0));
                BlockCoordinateIndest.Add(new Coordinate(i, sizeY));
            }
            for (int i = 1; i < sizeY - 1; i++)
            {
                for (int j = 1; j < sizeX; j++)
                {
                    if (i % 2 == 0 && j % 2 == 0)
                        BlockCoordinateIndest.Add(new Coordinate(j, i));
                    countBlock++;
                }
            }
        }

        void DestructibleBlock(int sizeX, int sizeY)
        {
            for (int i = 0; i < countBlock / 3; i++)
            {
                int X = rnd.Next(1, sizeX);
                int Y = rnd.Next(1, sizeY - 1);
                
                
                if ((X == BlockCoordinateIndest[i].X) && (Y = BlockCoordinateIndest[i].Y))
                    //else { BlockCoordinateDest.Add(new Coordinate(j, i)); countBlock++; }
                
                }
            }
        }
        public void Draw(System.Drawing.Graphics graphics, int S, System.Drawing.Pen blackPen)
        {
            DrawIndestructibleBlock(graphics, S, blackPen);
            DrawDestructibleBlock(graphics, S, blackPen);
        }
        void DrawIndestructibleBlock(System.Drawing.Graphics graphics, int S, System.Drawing.Pen blackPen)
        {
            for (int i = 0; i < BlockCoordinateIndest.Count; i++)
            {
                var drawRectangle = new System.Drawing.Rectangle(BlockCoordinateIndest[i].X * S, BlockCoordinateIndest[i].Y * S, S, S);

                graphics.FillRectangle(System.Drawing.Brushes.Gray, drawRectangle);
                graphics.DrawRectangle(blackPen, drawRectangle);
            }
        }
        void DrawDestructibleBlock(System.Drawing.Graphics graphics, int S, System.Drawing.Pen blackPen)
        {
            for (int i = 0; i < BlockCoordinateDest.Count; i++)
            {
                var drawRectangle = new System.Drawing.Rectangle(BlockCoordinateDest[i].X * S, BlockCoordinateDest[i].Y * S, S, S);

                graphics.FillRectangle(System.Drawing.Brushes.Pink, drawRectangle);
                graphics.DrawRectangle(blackPen, drawRectangle);
            }
        }
    }
}
