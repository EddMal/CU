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
            testCanvas1[0]=6;
            testCanvas1[1]=6;
            Logic.Graphics.FileData canvasData = new Logic.Graphics.FileData(CanvasFilePath);
            canvasData.SaveToFile(NumberOfElements,testCanvas1);
        }
    }
}
