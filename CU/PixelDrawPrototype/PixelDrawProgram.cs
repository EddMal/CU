using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Reflection.Metadata;
using System.Text;

namespace PixelDraw // V.2.9.1
{
    internal class PixelDrawProgram
    {
        // Availible to all the members of the class (in namespace?),
        // array with color data for the canvas pixels.
        public static int[] Pixels = new int[Canvas.PixelElements];

        // Integer used to store last selected backgroundcolor.
        public static int SelectedPixelColor;

        // Save file in filepath implement method for user to set filepath and file when saving/loading file.
        public static string FilePath;

        //
        //public static string Pixel = "  ";

        public static string PixelCursor = "[]";

        static void Main(string[] args)
        {


            Console.Title = "PixelDraw: Change Color = Tab, Paint = Spacebar, Save to file = S, Load file = L";
            // Evaluate.
            User MyUser = new User();
            // Initate vaules for UserActions parameters Quit, and position (x*y).
            MyUser.Quit = false;
            MyUser.X = 45;
            MyUser.Y = 25;

            FilePath = @"C:\Users\eddie\Desktop\PixelPixelCanvas.txt";

            // Hide Cursor.
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            ConsoleKeyInfo keyInfo;
            // Initiate Cursor position.
            Console.SetCursorPosition(MyUser.X, MyUser.Y);
            Console.Write("  ");

            /*while (true)
            {
                for (int y = 0; y < 30; y++)
                {
                    for (int x = 0; x < 90; x=x+2)
                    {
                        if (Console.BackgroundColor < ConsoleColor.White)
                            Console.BackgroundColor += 1;
                        else if (Console.BackgroundColor > ConsoleColor.Black)
                            Console.BackgroundColor -= 1;

                        Console.CursorVisible = false;
                        //Console.SetCursorPosition(x, y);
                        //Console.Write("  ");
                        Canvas.SavePixel(x, y, (int)Console.BackgroundColor);
                    }
                    
                }
                Console.ReadLine();
            }*/

            //Test fill the canvas pixeldata with color.
            /*for (int y = 0; y < 30; y++)
            {
                for (int x = 0; x < 90; x = x + 2)
                {
                    if (Console.BackgroundColor < ConsoleColor.White)
                    {
                        Console.BackgroundColor += 1;
                    }
                    else if (Console.BackgroundColor > ConsoleColor.Black)
                    {
                        Console.BackgroundColor -= 1;
                    }

                    Pixels[(y * Canvas.Width) + x] = (int)Console.BackgroundColor;
                    //Console.CursorVisible = false;
                    //Console.SetCursorPosition(x, y);
                    //Console.Write("  ");
                    //Canvas.SavePixel(x, y, (int)Console.BackgroundColor);
                }

            }
            // Test write saved pixel data stored in array to console.
            while (true)
            {
                Canvas.DisplayCanvas(Pixels);
                
            }*/


            do
            {
                // Evaluate the handling and declaration of Console.title.
                Console.Title = "PixelDraw: Change Color = Tab, Paint = Spacebar, Save to file = S, Load file = L";
                Canvas.DisplayCanvas(PixelDrawProgram.Pixels);
                Canvas.DisplayCursor(MyUser.X, MyUser.Y);

                // Retrieve information for actions based on user input(Keys).
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case (ConsoleKey)Action.ChangeColor:
                        Console.Title = "Change Color by using left or right arrow, select color = Spacebar.";
                        //Manualdebug : Console.WriteLine(" Paint: X: {0} Y: {1}", MyUser.X, MyUser.Y);
                        Change.Color(MyUser.X, MyUser.Y);
                        break;
                    case (ConsoleKey)Action.MoveCursor:
                        (MyUser.X, MyUser.Y) = MyUser.MoveCursor(MyUser.X, MyUser.Y);
                        Canvas.DisplayCanvas(PixelDrawProgram.Pixels);
                        break;
                    case (ConsoleKey)Action.Paint:
                        Console.Title = "Use arrow keys to paint, press space when done.";
                        (MyUser.X, MyUser.Y) = MyUser.MoveCursor(MyUser.X, MyUser.Y);
                        Canvas.DisplayCanvas(PixelDrawProgram.Pixels);
                        break;
                    //Manualdebug : Console.WriteLine(" Paint: X: {0} Y: {1}", MyUser.X, MyUser.Y);
                    /*foreach (int element in Pixels)
                    {
                        Console.BackgroundColor = (ConsoleColor)Pixels[element];
                        Console.WriteLine("{0}", element);
                    }
                    */
                    case (ConsoleKey)Action.SaveFile:
                        Canvas.SaveToFile();
                        Canvas.DisplayCanvas(PixelDrawProgram.Pixels);
                        break;
                    case (ConsoleKey)Action.LoadFile:
                        Canvas.LoadFromFile();
                        Canvas.DisplayCanvas(PixelDrawProgram.Pixels);
                        break;
                    case (ConsoleKey)Action.ExitProgram:
                        //Add confirmation "Do you want to exit program Ok/cancel"
                        MyUser.Quit = true;
                        break;
                    default:
                        Canvas.DisplayCanvas(PixelDrawProgram.Pixels);
                        Console.Title = "PixelDraw: Change Color = Tab, Paint = Spacebar, Save to file = S, Load file = L";
                        //keyInfo = Console.ReadKey(true);
                        // MyUser.MoveCursor(MyUser.X, MyUser.Y);
                        break;
                }

            } while (MyUser.Quit == false);
        }
    }

    enum Action
    {
        ChangeColor = ConsoleKey.Tab,
        MoveCursor = ConsoleKey.M,
        Paint = ConsoleKey.Spacebar,
        SaveFile = ConsoleKey.S,
        LoadFile = ConsoleKey.L,
        ExitProgram = ConsoleKey.Escape
    }

    // Class Change color.
    class Change
    {
        public static void Color(int X, int Y)
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                Console.CursorVisible = false;
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (Console.BackgroundColor < ConsoleColor.White)
                        Console.BackgroundColor += 1;
                }

                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    if (Console.BackgroundColor > ConsoleColor.Black)
                        Console.BackgroundColor -= 1;
                }
                // Save last selected pixelcolor;
                PixelDrawProgram.SelectedPixelColor = (int)Console.BackgroundColor;
                User.DisplayPixel(X, Y);

            } while (keyInfo.Key != (ConsoleKey)Action.Paint);

        }

    }
    // Class Canvas data.
    class Canvas
    {
        // Evaluate if place constants in front of main.
        public const int Width = 90;
        public const int Height = 30;
        public const int PixelElements = Height * Width; // Height*Width.

        //Evaluate if needed.
        //public int X { get; set; }
        //public int Y { get; set; }
        // Canvas pixel elements with color data.
        public int[] Pixel { get; set; }

        //Print canvas to console.

        public static void DisplayCursor(int X, int Y)
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

        public static void DisplayCanvas(int[] PixelArray)
        {
            // Remove Pixels can be used instead because of it is possible to reach "global".
            int[] Pixel = new int[PixelElements];
            Pixel = PixelArray;
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width - 1; x = x + 1)
                {
                    Console.BackgroundColor = (ConsoleColor)Pixel[(y * Width) + x];
                    User.DisplayPixel(x, y);
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        // Save painting
        public static void SaveToFile()
        {
            //Convert Pixels int array to string array.
            StringBuilder StringBuilderPixels = new StringBuilder();

            for (int i = 0; i < Canvas.PixelElements; i++)
            {
                if (i > 0)
                {
                    StringBuilderPixels.Append(",");
                }
                StringBuilderPixels.Append(PixelDrawProgram.Pixels[i]);
            }

            String StringPixels = StringBuilderPixels.ToString();


            System.IO.File.WriteAllText(PixelDrawProgram.FilePath, StringPixels);



        }

        // Load painting.
        public static void LoadFromFile()
        {
            String StringPixels = File.ReadAllText(PixelDrawProgram.FilePath);
            //Program.Pixels.ConvertAll<string, int>(StringPixels.Split(','), Convert.ToInt32);
            //Program.Pixels= JsonConvert.DeserializeObject<int[]>(StringPixels); //ConvertAll(StringPixels.Split(","), int.Parse);
            //text.Split(';').Select(n => Convert.ToInt32(n)).ToArray();

            //https://stackoverflow.com/questions/1763613/convert-comma-separated-string-of-ints-to-int-array
            List<int> myIntegers = new List<int>();
            Array.ForEach(StringPixels.Split(",".ToCharArray()), s =>
            {
                int currentInt;
                if (Int32.TryParse(s, out currentInt))
                    myIntegers.Add(currentInt);
            });
            PixelDrawProgram.Pixels = myIntegers.ToArray();

        }
    }

    // Declared Class User

    // Class namne (Contains data-types and Method)
    class User
    {
        //Action Choice { get; set; }
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
