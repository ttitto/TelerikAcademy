using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*1.Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. 
 * Implement the ToString() to enable printing a 3D point.
2. Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}. 
 * Add a static property to return the point O.
4. Write a static class with a static method to calculate the distance between two points in the 3D space.*/
namespace Points3D
{
    public struct Point3D
    {
        #region Fields
        private double x;
        private double y;
        private double z;

        private static readonly Point3D o; 
        #endregion

        #region Properties
        public double X
        {
            get { return this.x; }
            set
            {
                //TODO: Validate the 3d Point values
                this.x = value;
            }
        }
        public double Y
        {
            get { return this.y; }
            set
            {
                //TODO: Validate the 3d Point values
                this.y = value;
            }
        }
        public double Z
        {
            get { return this.z; }
            set
            {
                //TODO: Validate the 3d Point values
                this.z = value;
            }
        }
        public static  Point3D O
        {
            get { return o;}
        }
        #endregion
        #region Constructors

        public Point3D(double x, double y, double z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        } 
        #endregion

        #region Methods
        public override string ToString()
        {
            return String.Format("{{ {0:F}, {1:F}, {2:F} }}", this.X.ToString(), this.Y.ToString(), this.Z.ToString());
        } 
        #endregion
    }
}
