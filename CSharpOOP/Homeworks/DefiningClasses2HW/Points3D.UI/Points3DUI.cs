using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Points3D;
using System.IO;
namespace Points3D.UI
{
    class Points3DUI
    {
        static void Main(string[] args)
        {
            Path myPath = new Path(new Point3D(1.58, 2.75, 3), new Point3D(4, 5.60, 6), Point3D.O);
            for (int i = 0; i < myPath.Length; i++)
            {
                Console.WriteLine(myPath[i].ToString());
            }
            PathStorage.SavePaths(myPath, @"../../SavePaths.txt");

            string loadPathsAddress = @"../../LoadPaths.txt";
            if (File.Exists(loadPathsAddress))
            {
               myPath= PathStorage.LoadPaths(loadPathsAddress);
            }

            Console.WriteLine("The distance between the first two points in the path is: {0:F3}",Distance3D.CalculateDistance(myPath[0],myPath[1]));
        }
    }
}
