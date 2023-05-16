using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj
{
    class Vendor
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string VendorMarker;
        private ConsoleColor VendorColor;

        public Vendor(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            VendorMarker = "V";
            VendorColor = ConsoleColor.Magenta;
        }

        public void Print()
        {
            Console.ForegroundColor = VendorColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(VendorMarker);
            Console.ResetColor();
        }
    }
}
