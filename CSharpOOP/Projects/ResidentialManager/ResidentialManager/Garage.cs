using System.Text;
using System.Collections.Generic;

public class Garage : BlockObject
{
    #region Fields

    private double width;
    private double height;
    private double depth;

    #endregion

    #region Properties

    public double Width
    {
        get
        {
            return this.width;
        }
        set
        {
            this.width = value;
        }
    }
    public double Height
    {
        get
        {
            return this.height;
        }
        set
        {
            this.height = value;
        }
    }
    public double Depth
    {
        get
        {
            return this.depth;
        }
        set
        {
            this.depth = value;
        }
    }

    #endregion

    #region Constructors

    public Garage(double area, int floor, int number, double width, double height, double depth)
        : base(area, floor, number)
    {
        this.Width = width;
        this.Height = height;
        this.Depth = depth;
    }

    #endregion

    #region Methods

    public override string ToString()
    {
        return string.Format("{0} /" + "{1} /" + "{2} /" + "{3} /" + "{4} /" + "{5}",
                base.Area, base.Floor, base.Number, this.width, this.height, this.depth);
    }

    #endregion
}

