using PixelDraw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CU.Logic.Graphics
{
    public class FileData
    {
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
}
