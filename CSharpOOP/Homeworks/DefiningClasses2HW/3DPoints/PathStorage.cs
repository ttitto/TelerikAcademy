using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Points3D
{/*3. Create a static class PathStorage with static methods to save and load paths from a text file.
  * Use a file format of your choice.*/
    public static class PathStorage
    {
        private static string fullPath;

        public static string FullPath
        {
            get { return fullPath; }
            set
            {
                //TODO: Validate txt file address
                fullPath = value;
            }
        }

        public static void SavePaths(Path path, string pathStorage)
        {
            using (StreamWriter sw= new StreamWriter(pathStorage,false,Encoding.GetEncoding("UTF-8")))
            {
                for (int i = 0; i < path.Length; i++)
                {
                    sw.WriteLine(path[i]);
                }
            }
        }
        public static Path LoadPaths(string pathStorage)
        {
            Path path = new Path();
            Point3D point3D = new Point3D();
            string[] readPoints = new string[2];
            using (StreamReader sr=new StreamReader(pathStorage,Encoding.GetEncoding("UTF-8")))
            {
                string line=sr.ReadLine();
                while (line != null)
                {
                    readPoints = line.Split(new char[] { '{', ' ', '}', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    point3D.X = double.Parse(readPoints[0]);
                    point3D.Y = double.Parse(readPoints[1]);
                    point3D.Z = double.Parse(readPoints[2]);
                    path.Path3D.Add(point3D);
                    line = sr.ReadLine();
                }
            }
            return path;
        }
    }
}
