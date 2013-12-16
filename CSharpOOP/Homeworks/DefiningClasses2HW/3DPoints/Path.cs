using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Points3D
{/*3.Create a class Path to hold a sequence of points in the 3D space.*/
    public class Path
    {
        #region Fields
        private List<Point3D> path3D;
        
        #endregion
        #region Properties

        public List<Point3D> Path3D
        {
            get { return this.path3D; }
            set
            {
                //TODO: Validate value!
                this.path3D = value;
            }
        }
        public int Length
        {
            get { return this.path3D.Count; }
        }
        //Indexer declaration
        public Point3D this[int indx]
        {
            get { return path3D[indx]; }
            set
            {
                //TODO: Validate value!
                path3D[indx] = value;
            }
        } 
        #endregion
        #region Constructors

        public Path(params Point3D[] point3D)
            
        {
            this.Path3D = new List<Point3D>();
            for (int i = 0; i < point3D.Length; i++)
            {
                this.Path3D.Add(point3D[i]);
            }
        } 
        #endregion
    }
}
