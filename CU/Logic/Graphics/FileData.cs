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
        private string _filePath{ get; init; }

        public FileData(string FilePath)
        {
            _filePath = FilePath;
        }

        // Save painting
        public static void SaveToFile(int PixelElements)
        {
            //Convert Pixels int array to string array.
            StringBuilder StringBuilderPixels = new StringBuilder();

            for (int i = 0; i < PixelElements; i++)
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
        public int[] LoadFromFile()
        {
            String StringPixels = File.ReadAllText(_filePath);

            //https://stackoverflow.com/questions/1763613/convert-comma-separated-string-of-ints-to-int-array
            List<int> myIntegers = new List<int>();
            Array.ForEach(StringPixels.Split(",".ToCharArray()), s =>
            {
                int currentInt;
                if (Int32.TryParse(s, out currentInt))
                    myIntegers.Add(currentInt);
            });
            return myIntegers.ToArray();

        }
    }
}
