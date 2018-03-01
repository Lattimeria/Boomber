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
        Game game;
        public Form1()
        {
            InitializeComponent();
            InitializeForm();

            StartGame();
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
        }

        void StartGame()
        {
            game = new Game();
            game.Start(W,H,S);

            timer1.Interval = 200;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void Program_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Program_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.White, 0, 0, this.Width, this.Height);
            Pen blackPen = new Pen(Color.Black, 1);
            blackPen.Alignment = PenAlignment.Inset;
            game.Draw(g,S,blackPen);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
