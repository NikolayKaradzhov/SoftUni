﻿using System;
using System.Collections.Generic;
using System.Text;

namespace p02.PointInRectangle
{
    public class Point
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }
    }
}