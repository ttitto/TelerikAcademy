using System.Collections.Generic;

public abstract class BlockObject
{
    #region Fields

    private double area;
    private int floor;
    private int number;

    #endregion

    #region Properties

    public double Area
    {
        get
        {
            return this.area;
        }
        set
        {
            this.area = value;
        }
    }
    public int Floor
    {
        get
        {
            return this.floor;
        }
        set
        {
            this.floor = value;
        }
    }
    public int Number
    {
        get
        {
            return this.number;
        }
        set
        {
            this.number = value;
        }
    }

    #endregion

    #region Constructors

    public BlockObject(double area, int floor, int number)
    {
        this.Area = area;
        this.Floor = floor;
        this.Number = number;
    }

    #endregion
}

