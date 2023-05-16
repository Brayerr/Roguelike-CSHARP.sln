using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj
{
    class Lever
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string LeverMarker;
        private ConsoleColor LeverColor;

        public Lever(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            LeverMarker = "L";
            LeverColor = ConsoleColor.Cyan;
        }

        public void Print()
        {
            Console.ForegroundColor = LeverColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(LeverMarker);
            Console.ResetColor();
        }
    }
}
