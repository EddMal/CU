using static CU.Logic.Grapics.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CU.Logic.InputKeys;

namespace CU.Logic.Graphics
{
    internal class User
    {
        private Canvas _canvas { get; init; }
        public User(Canvas canvas) 
        {
            _canvas = canvas;
        }

        /* Method MoveCursor inside of class User, enables
           * the user to move the cursor over the canvas.*/
        public (int X, int Y) MoveCursor(int X, int Y,int SelectedPixelColor, int[] CanvasPixelData)
        {
            //Evaluate to find a more optimized way to handle assigning of Program.Pixel
            // this metod is about to be overloaded with code.
            _canvas.Pixel[(Y * _canvas._width) + X] = (int)Console.BackgroundColor;
            _canvas.Pixel[(Y * _canvas._width) + (X + 1)] = (int)Console.BackgroundColor;
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.CursorVisible = false;
                Console.BackgroundColor = (ConsoleColor)SelectedPixelColor;
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (Y > 0)
                            Y--;

                        break;
                    case ConsoleKey.DownArrow:
                        if (Y < _canvas._height - 1)
                            Y++;

                        break;
                    case ConsoleKey.LeftArrow:
                        if (X > 0)
                            X--;

                        break;
                    case ConsoleKey.RightArrow:
                        if (X < _canvas._width - 2 && ((Y * _canvas._width) + (X + 1)) < (_canvas._width * _canvas._height - 1))
                            X++;
                        break;

                    default:
                        break;
                }
                // Due to a pixels nature on canvas occupies 2 chars in width 2x store background
                // color of pixel element. Move to other/new method.(ev. in DisplayPixel)
                CanvasPixelData[(Y * _canvas._width) + X] = (int)Console.BackgroundColor;
                CanvasPixelData[(Y * _canvas._width) + (X + 1)] = (int)Console.BackgroundColor;
                DisplayPixel(X, Y);
            } while (keyInfo.Key != (ConsoleKey)InputKeys.Action.Paint);

            return (X, Y);
        }
        
    }
}
