using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj
{
    class CashDrop
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string CashMarker;
        private ConsoleColor CashColor;

        public CashDrop(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            CashMarker = "G";
            CashColor = ConsoleColor.Yellow;
        }

        public void Print()
        {
            Console.ForegroundColor = CashColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(CashMarker);
            Console.ResetColor();
        }

        public int GetCashDrop()
        {
            Random r = new Random();
            return r.Next(5, 10);
        }
    }
}

