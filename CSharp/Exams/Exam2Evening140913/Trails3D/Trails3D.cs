using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trails3D
{
    class Trails3DClass
    {
        static void Main(string[] args)
        {
            //input
            string[] dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int x = int.Parse(dimensions[0]);
            int z = int.Parse(dimensions[1]);
            int y = int.Parse(dimensions[2]);

            char[, ,] cuboid = new char[x, y, z];

            //start points
            cuboid[y / 2, x / 2, 0] = 'r';
            cuboid[y / 2, x / 2, z - 1] = 'b';

            //commands
            string[] redCmds = Console.ReadLine().Split(new char[] { 'M' }, StringSplitOptions.RemoveEmptyEntries);
            string[] blueCmds = Console.ReadLine().Split(new char[] { 'M' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < redCmds.Length; i++)
            {
                int repetitions = 0;
                if (int.TryParse(redCmds[i], out repetitions))
                {
                    redCmds[i] = new string('M', repetitions);
                }
            }
            for (int i = 0; i < blueCmds.Length; i++)
            {
                int repetitions = 0;
                if (int.TryParse(blueCmds[i], out repetitions))
                {
                    blueCmds[i] = new string('M', repetitions);
                }
            }
            string rCmds = String.Join("", redCmds);
            string bCmds = String.Join("", blueCmds);
            int maxIterations = Math.Max(rCmds.Length, bCmds.Length);

            for (int ii = 0; ii < maxIterations; ii++)
            {
                //Red player
                if (rCmds[ii] == 'M')
                {

                }

                //Blue player
            }

        }
        static void MoveRight()
        {

        }
        static void MoveLeft()
        {

        }
        static void MoveForward()
        {
        }
    }
}
