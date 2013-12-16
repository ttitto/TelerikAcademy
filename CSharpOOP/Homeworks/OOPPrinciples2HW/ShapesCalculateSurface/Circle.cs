namespace ShapesCalculateSurface
{
    /*Define class Circle and suitable constructor so 
     * that at initialization height must be kept equal to width and implement the CalculateSurface() method.*/
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Circle : Shape
    {
        public override double Width
        {
            get { return this.width; }
            set
            {
                //Zeroes are not allowed, circle with radius 0 is a point. 
                //During the initialization of a circle one of the width or height is 0 and the second check is to allow initialization
                if (value != this.height && this.height != 0) throw new ArgumentException("Width and Height must be equal!");
                this.width = value;
                ;
            }
        }
        public override double Height
        {
            get { return this.height; }
            set
            {
                if (value != this.width && this.width != 0) throw new ArgumentException("Width and Height must be equal!");
                this.height = value;
                ;
            }
        }


        public Circle(double diameter)
        {
            this.Width = this.Height = diameter;
        }

        public override double CalculateSurface(Shape circle)
        {
            return Math.PI * circle.Width * circle.Width / 4;
        }
    }
}
