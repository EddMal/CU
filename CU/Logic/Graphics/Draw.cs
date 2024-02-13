using PixelDraw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CU.Logic.Grapics
{
    public class Draw
    {
        private int _width { get; init; } /* = 90;*/
        private int _height { get; init; }  /*_height = 30;*/
        private int _pixelElements { get; init; }  // Height*Width.

        // Canvas pixel elements with color data.
        public int[] Pixel { get; set; }

        //replace with Canvas from canvas class..
        public Draw(int Height, int Width)
        {

            if (Width! > 0 || Height! > 0)
            {
                _height = 30;
                _width = 90;
            }
            else 
            {
                _height = Height;
                _width = Width;
                
            }

            _pixelElements = _height * _width;
            Pixel = new int[_pixelElements];

        }

        public void DisplayCursor(int X, int Y)
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = (ConsoleColor)PixelDrawProgram.SelectedPixelColor;
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
            int[] Pixel = new int[_pixelElements];
            Pixel = PixelArray;
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width - 1; x = x + 1)
                {
                    Console.BackgroundColor = (ConsoleColor)Pixel[(y * _width) + x];
                    User.DisplayPixel(x, y);
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        class User
        { 
            public bool Quit { get; set; }
            public int X { get; set; }
            public int Y { get; set; }

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

            /* Method MoveCursor inside of class User, enables
             * the user to move the cursor over the canvas.*/
            public (int X, int Y) MoveCursor(int X, int Y)
            {
                //Evaluate to find a more optimized way to handle assigning of Program.Pixel
                // this metod is about to be overloaded with code.
                PixelDrawProgram.Pixels[(Y * Canvas.Width) + X] = (int)Console.BackgroundColor;
                PixelDrawProgram.Pixels[(Y * Canvas.Width) + (X + 1)] = (int)Console.BackgroundColor;
                ConsoleKeyInfo keyInfo;
                do
                {
                    Console.CursorVisible = false;
                    Console.BackgroundColor = (ConsoleColor)PixelDrawProgram.SelectedPixelColor;
                    keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (Y > 0)
                                Y--;

                            break;
                        case ConsoleKey.DownArrow:
                            if (Y < Canvas.Height - 1)
                                Y++;

                            break;
                        case ConsoleKey.LeftArrow:
                            if (X > 0)
                                X--;

                            break;
                        case ConsoleKey.RightArrow:
                            if (X < Canvas.Width - 2 && ((Y * Canvas.Width) + (X + 1)) < (Canvas.Width * Canvas.Height - 1))
                                X++;

                            break;

                        default:
                            break;
                    }
                    // Due to a pixels nature on canvas occupies 2 chars in width 2x store background
                    // color of pixel element. Move to other/new method.(ev. in DisplayPixel)
                    PixelDrawProgram.Pixels[(Y * Canvas.Width) + X] = (int)Console.BackgroundColor;
                    PixelDrawProgram.Pixels[(Y * Canvas.Width) + (X + 1)] = (int)Console.BackgroundColor;
                    DisplayPixel(X, Y);
                } while (keyInfo.Key != (ConsoleKey)Action.Paint);

                return (X, Y);
            }

        }
    }

}



