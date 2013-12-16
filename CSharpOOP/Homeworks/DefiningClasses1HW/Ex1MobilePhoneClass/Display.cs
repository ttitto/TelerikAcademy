// -----------------------------------------------------------------------
// <copyright file="Display.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Ex1MobilePhoneClass
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    ///Defines a Display object
    /// </summary>
    public class Display
    {
        //Fields
        float size;
        int numOfColors;
        #region Constructiors
        /// <summary>
        /// Builds a Display object
        /// </summary>
        /// <param name="size"></param>
        /// <param name="numOfColors"></param>
        public Display(float size,int numOfColors)
        {
            this.Size = size;
            this.NumOfColors = numOfColors;
        }
        #endregion
        #region Properties
        /// <summary>
        /// The size of a display.
        /// Can not be negative!
        /// </summary>
       public float Size 
        {
            get{return this.size;}
            set{
                if (value < 0) throw new ArgumentException("Invalid size value!");
                this.size=value;}
        }
        /// <summary>
        /// The number of colors of a Display.
        /// Can not be negative!
        /// </summary>
       public int NumOfColors
        {
            get { return this.numOfColors; }
            set { 
                if(value<0) throw new ArgumentException("Invalid value for the number of the display's colors!");
                this.numOfColors = value; 
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns a text with the information about the size and the number of the colors of a display.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Size: {0}, Colors: {1}", this.Size, this.NumOfColors);
        }
        #endregion

    }
}
