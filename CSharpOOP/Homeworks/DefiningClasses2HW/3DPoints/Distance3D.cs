// -----------------------------------------------------------------------
// <copyright file="Distance3D.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Points3D
{
    /*3. Write a static class with a static method to calculate the distance between two points in the 3D space.*/
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class Distance3D
    {
        public static double CalculateDistance(Point3D firstPoint3D, Point3D secondPoint3D)
        {
            double distance = 0;
            distance = Math.Sqrt((firstPoint3D.X - secondPoint3D.X) * (firstPoint3D.X - secondPoint3D.X)+
                (firstPoint3D.Y - secondPoint3D.Y) * (firstPoint3D.Y - secondPoint3D.Y)+
                (firstPoint3D.Z - secondPoint3D.Z) * (firstPoint3D.Z - secondPoint3D.Z));
            return distance;
        }
    }
}
