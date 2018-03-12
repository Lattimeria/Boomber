using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace boomber
{
    public partial class Form1 : Form
    {
        //форма - создание игры, отрисовка
        //игра - генерирование уровней, создание игрока, бомб, ИИ, столкновения
        //игрок - параметры (координаты), движение, отрисовка
        //бомба - координаты, отрисовка
        //нпс - координаты, движение (поведение), отрисовка
        public int W = 21, H = 15, S=30;
        public float deltaT;
        Game game;
        public Form1()
        {
            InitializeComponent();
            InitializeForm();
            
        }

        void InitializeForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.DoubleBuffered = true;

            this.ClientSize = new Size (W*S,H*S);

            this.Paint += new PaintEventHandler(Program_Paint); // обработчик прорисовки формы
            this.KeyDown += new KeyEventHandler(Program_KeyDown); // обработчик нажатий на кнопки
            this.MouseClick += new MouseEventHandler(Program_MouseClick);
        }

        private void Program_MouseClick(object sender, MouseEventArgs e)
        {
            if (game.CurrentCountBomb < game.MaxCountBomb)
                game.AddBomb(e.X / S, e.Y / S);
            
        }

        void StartGame()
        {
            game = new Game();
            game.Start(W,H,S);
            
            timer2.Tick += new EventHandler(Timer2_Tick);
            timer2.Start();
        }
                
        private void Program_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartGame();
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            deltaT = timer2.Interval / 1000f;
            Refresh();
        }
        
        private void Program_Paint(object sender, PaintEventArgs e)
        {
            if (game != null)
            {
                Graphics g = e.Graphics;
                g.FillRectangle(Brushes.White, 0, 0, this.Width, this.Height);
                
                game.Draw(g, S, deltaT);
            }
            
        }
        
    }
}
