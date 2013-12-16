namespace ShapesCalculateSurface
{
    /*Define two new classes Triangle and Rectangle that implement the virtual
     * method and return the surface of the figure (height*width for rectangle and height*width/2 for triangle).*/
    public class Rectangle : Shape
    {
        public Rectangle(double width, double height) 
        {
            this.Width = width;
            this.Height = height;
        }

        public override double CalculateSurface(Shape rectangle)
        {
            return rectangle.Height * rectangle.Width;
        }
    }
}
