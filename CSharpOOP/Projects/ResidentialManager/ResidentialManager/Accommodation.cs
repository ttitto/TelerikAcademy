using System.Text;

public class Accommodation : BlockObject
{
    #region Fields

    private double width;
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

    public Accommodation(double area, int floor, int number, double width, double depth)
        : base(area, floor, number)
    {
        this.Width = width;
        this.Depth = depth;
    }

    #endregion

    #region Methods

    public override string ToString()
    {
        return string.Format("{0} /" + "{1} /" + "{2} /" + "{3} /" + "{4}",
                base.Area, base.Floor, base.Number, this.width, this.depth);
    }

    #endregion
}

