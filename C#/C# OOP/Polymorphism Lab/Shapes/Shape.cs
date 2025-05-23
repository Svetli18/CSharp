﻿namespace Shapes
{
    public abstract class Shape : IShape
    {
        public abstract double CalculateArea();

        public abstract double CalculatePerimeter();

        public abstract string Draw();
    }
}
