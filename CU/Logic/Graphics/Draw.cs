using CU.Logic.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CU.Logic.Grapics
{
    public class Draw
    {
        //private int _width { get; init; } /* = 90;*/
        //private int _height { get; init; }  /*_height = 30;*/
        //private int _pixelElements { get; init; }  // Height*Width.

        //// Canvas pixel elements with color data.
        //public int[] Pixel { get; set; }
        private static int SelectedPixelColor;

        private Canvas _canvas { get; init; }

        //investigate if obselete
        public int X { get; set; }
        public int Y { get; set; }


        public Draw(Canvas canvas)
        {
            _canvas = canvas;
        }

        //Handle SelectedPixelColor
        public void DisplayCursor(int X, int Y)
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = (ConsoleColor)SelectedPixelColor;
            const string PixelCursor = "[]";
            Console.SetCursorPosition(X, Y);
            Console.Write("{0}", PixelCursor);
            // Test if needed?
            Console.SetCursorPosition(X, Y);
            Console.BackgroundColor = ConsoleColor.Black;

        }

        public void DisplayCanvas(int[] PixelArray)
        {
            // Remove Pixels can be used instead because of it is possible to reach "global".
            int[] Pixel = new int[_canvas._pixelElements];
            Pixel = PixelArray;
            for (int y = 0; y < _canvas._height; y++)
            {
                for (int x = 0; x < _canvas._width - 1; x = x + 1)
                {
                    Console.BackgroundColor = (ConsoleColor)Pixel[(y * _canvas._width) + x];
                    DisplayPixel(x, y);
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

            public static void PaintPixel(int X, int Y)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("  ");
            }

            public static void DisplayPixel(int X, int Y)
            {
                Console.CursorVisible = false;
                const string Pixel = "  ";
                Console.SetCursorPosition(X, Y);
                Console.Write("{0}", Pixel);
                Console.SetCursorPosition(X, Y);

            }

          
    }

}



