﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CU.Logic.Graphics
{
    public class Canvas
    {
        public int _width {get; init;} /* = 90;*/
        public int _height { get; init;}  /*_height = 30;*/
        public int _pixelElements { get; init; }  // Height*Width.
        public int[] Pixel { get; set; }

        public Canvas(int Height, int Width)
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
             // Evaluate if place constants in front of main.

        //Evaluate if needed.
        //public int X { get; set; }
        //public int Y { get; set; }
        // Canvas pixel elements with color data.
    }
    
}
