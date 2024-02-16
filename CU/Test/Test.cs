using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CU.Test
{
    public static class Test
    {
        public static  string CanvasFilePath = @"..\..\..\Files\Graphics\Background\PixelCanvas.txt";
        static int[] testCanvas1 = new int[2];
        static int NumberOfElements = 2;
       public static void TestWriteToFile()
        {
            testCanvas1[0]=7;
            testCanvas1[1]=6;
            Logic.Graphics.FileData canvasData = new Logic.Graphics.FileData(CanvasFilePath);
            canvasData.SaveToFile(NumberOfElements,testCanvas1);
        }

        public static void TestReadFromFile()
        {
            Logic.Graphics.FileData canvasData = new Logic.Graphics.FileData(CanvasFilePath);
            Logic.Graphics.Canvas bgCanvas = new Logic.Graphics.Canvas(100, 100);
            bgCanvas.Pixel = canvasData.LoadFromFile();
            for(int i = 0; i < bgCanvas.Pixel.Length; i++)
            {
                Console.WriteLine($"{bgCanvas.Pixel[i]}");
            
            }
        
        }



    }
}
