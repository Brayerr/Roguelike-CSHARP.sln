using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj
{
    class TreasureBox
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string TBMarker;
        private ConsoleColor TBColor;
        private bool OpenAble = true;

        public TreasureBox(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            TBMarker = "B";
            TBColor = ConsoleColor.Yellow;
        }

        public void Print()
        {
            Console.ForegroundColor = TBColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(TBMarker);
            Console.ResetColor();
        }

        public int OpenChest()
        {
            if (OpenAble == true)
            {
                OpenAble = false;
                Random r = new Random();
                return r.Next(10, 20);
            }
            else
            {
                return 0;
            }
        }
    }
}
