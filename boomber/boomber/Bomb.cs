using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boomber
{
    class Bomb
    {
        //бомба
        public int bombX;
        public int bombY;

        public Bomb(int mouseX, int mouseY,int S)
        {
            bombX = mouseX / S;
            bombY = mouseY / S;
            Coordinate bomb = new Coordinate(bombX, bombY);
            
        }
        

    }
}
