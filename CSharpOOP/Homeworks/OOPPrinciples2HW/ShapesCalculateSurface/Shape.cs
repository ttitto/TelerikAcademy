using System;
namespace ShapesCalculateSurface
{
    /* Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height.*/
    public abstract class Shape
    {
        protected double height;
        protected double width;

        public virtual double Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid height! Height can not be 0, nor less.");
                this.height = value;
                ;
            }
        }
        public virtual double Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid width! Width can not be 0, nor less.");
                this.width = value;
                ;
            }
        }

        public abstract double CalculateSurface(Shape shape);
    }
}
