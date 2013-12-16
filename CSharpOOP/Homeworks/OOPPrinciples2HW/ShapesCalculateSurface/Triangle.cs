namespace ShapesCalculateSurface
{
    /*Define two new classes Triangle and Rectangle that implement the virtual
     * method and return the surface of the figure (height*width for rectangle and height*width/2 for triangle).*/
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Triangle : Shape
    {
        public Triangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override double CalculateSurface(Shape triangle)
        {
            return triangle.Height * triangle.Width / 2;
        }
    }
}
