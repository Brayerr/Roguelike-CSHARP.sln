using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj
{
    class NextLevelPortal
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string PortalMarker;
        private ConsoleColor PortalColor;

        public NextLevelPortal(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            PortalMarker = "X";
            PortalColor = ConsoleColor.Blue;
        }

        public void Print()
        {
            Console.ForegroundColor = PortalColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(PortalMarker);
            Console.ResetColor();
        }
    }
}
