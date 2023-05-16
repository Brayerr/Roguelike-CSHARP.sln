using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;


namespace FinalProj
{
    class Traps
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Traps(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;            
        }

        public int PoisonTrap(int playerHP)
        {
            playerHP -= 3;
            return playerHP;
        }

   
    }
}
