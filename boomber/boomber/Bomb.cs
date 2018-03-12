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
        public GreyBlock(int x, int y) : base(x, y) { }
        public override void Draw(Graphics graphics, int S, float dt)
        {
            Draw(graphics, S, Brushes.Gray);
        }
    }
    public class PinkBlock : BlockBase
    {
        // разрушаемый блок
        public PinkBlock(int x, int y) : base(x, y) { }
        public override void Draw(Graphics graphics, int S, float dt)
        {
            Draw(graphics, S, Brushes.Pink);
        }
    }

    // ExplosionEffect
    public class BombBoom : BlockBase
    {
        public const float BoomTime = 1.0f;
        float boomTime; //decayTime

        public delegate void BoomExplodeDelegate(BombBoom boom);
        public event BoomExplodeDelegate OnExplode; // OnDecay
        public BombBoom(int x, int y) : base(x, y) { }

        public override void Draw(Graphics graphics, int S, float deltaT)
        {
            boomTime += deltaT;
            if (boomTime >= BoomTime)
                OnExplode(this);
            Draw(graphics, S, Brushes.Yellow);
        }
    }
    public class Bomb : BlockBase
    {
        //бомба
        float Time;
        public const float FrameTime = 1.5f;
        public const int BigDiameter = 29;
        public const int SmallDiameter = 25;

        public const float BombTime = 5.0f; // время жизни бомбы
        float bombTime;

        public delegate void BombExplodeDelegate(Bomb bomb);
        public event BombExplodeDelegate OnExplode;

        private int CurrentDiameter = BigDiameter;
        public Bomb(int x, int y) : base(x, y) { }
        public override void Draw(Graphics graphics, int CellSize, float dt)
        {
            Time += dt;
            bombTime += dt;
            if (Time > FrameTime)
            {
                if (CurrentDiameter == BigDiameter)
                    CurrentDiameter = SmallDiameter;
                else
                    CurrentDiameter = BigDiameter;
                Time = 0;
            }
            //int r = CurrentDiameter / 2;

            int r = (int)((BigDiameter - SmallDiameter) * Math.Sin(Time * Math.PI) / 2.0f + SmallDiameter) / 2;

            Brush style = Brushes.Black;

            var drawRectangle = new Rectangle(BlockCoordX * CellSize + CellSize / 2 - r, BlockCoordY * CellSize + CellSize / 2 - r, r * 2, r * 2);

            graphics.FillEllipse(style, drawRectangle);
            graphics.DrawEllipse(Pens.Black, drawRectangle);

            if (bombTime >= BombTime)
                OnExplode(this);
        }
    }
    
}
