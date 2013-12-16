using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Apartment : BlockObject
{
    #region Fields

    private int numPeople;

    #endregion

    #region Properties

    public int NumPeople
    {
        get
        {
            return this.numPeople;
        }
        set
        {
            this.numPeople = value;
        }
    }

    #endregion

    #region Constructor

    public Apartment(double area, int floor, int number, int numPeople)
        : base(area, floor, number)
    {
        this.NumPeople = numPeople;
    }

    #endregion

    #region Methods

    public override string ToString()
    {
        return string.Format("{0} /" + "{1} /" + "{2} /" + "{3}",
                base.Area, base.Floor, base.Number, this.numPeople);
    }

    #endregion
}
