using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ex11FallingRocks
{
    /*11. * Implement the "Falling Rocks" game in the text console. A small dwarf stays at the bottom 
     * of the screen and can move left and right (by the arrows keys). A number of rocks of different sizes
     * and forms constantly fall down and you need to avoid a crash.
     * 
     * Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density. 
     * The dwarf is (O). Ensure a constant game speed by Thread.Sleep(150).
     * Implement collision detection and scoring system.
*/
    class Ex11FallingRocksClass
    {
        //random generator used for random number of rocks in a row, 
        static Random rnd = new Random();
        static char[] rocks = new char[] { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '-' };
        // static char[] dwarf = new char[] { '(', 'O', ')' };
        static char[,] world = new char[70, 50];
        static int dwarfPosition;
        static int score = 0;
        static Queue<int> points = new Queue<int>();

        static void Main(string[] args)
        {
            // Console.BackgroundColor = ConsoleColor.DarkGray;
            DrawWorld(world);
            //initialize dwarf at the middle column
            dwarfPosition = (int)(0.5 * world.GetLength(1));
            world[world.GetLength(0) - 1, dwarfPosition] = '(';
            world[world.GetLength(0) - 1, dwarfPosition + 1] = 'O';
            world[world.GetLength(0) - 1, dwarfPosition + 2] = ')';

            //Game Engine
            while (true)
            {
                if (CollisionCheck(world) == true)
                {
                    //Print score
                    //gameover
                    Console.WriteLine("Your score is {0}.", score);
                    Console.WriteLine("GameOver");
                    Console.ReadLine();
                    break;
                }

                UpdateWorld(world);
                UpdateDwarf(world);
                DrawWorld(world);
                AddPoints();
                Thread.Sleep(150);
            }
        }

        //if some rocks are already passed, their points are taken from the Queue and added to the score
        private static void AddPoints()
        {
            if (points.Count() > world.GetLength(0) - 1)
            {
                score = score + points.Dequeue();
            }
        }
        //
        private static void UpdateWorld(char[,] world)
        {
            //Clear the console
            Console.SetCursorPosition(0, 0);

            int columnCount = world.GetLength(1);

            //Generate new falling rocks randomly on the zero row
            int rocksInRow = rnd.Next(0, columnCount - (int)(0.85 * columnCount));
            //adds the number of the generated rocks in a Queue
            points.Enqueue(rocksInRow / 2);
            for (int i = 0; i < rocksInRow; i++)
            {
                world[0, rnd.Next(0, world.GetLength(1))] = rocks[rnd.Next(0, rocks.Count())];
            }

            //move the current objects to the next row
            for (int row = world.GetLength(0) - 2; row >= 0; row--)
            {
                for (int col = 0; col < columnCount; col++)
                {
                    world[row + 1, col] = world[row, col];
                    world[row, col] = ' ';
                }
            }
        }
        //checks if a collision is going to happen in the current game engine run
        //a collision is possible only between the dwarf and the chars from the rocks array
        private static bool CollisionCheck(char[,] world)
        {
            bool isCollision = false;
            try
            {
                if (rocks.Contains(world[world.GetLength(0) - 2, dwarfPosition])
                        || rocks.Contains(world[world.GetLength(0) - 2, dwarfPosition + 1])
                        || rocks.Contains(world[world.GetLength(0) - 2, dwarfPosition + 2]))
                {
                    isCollision = true;
                }
            }
            catch (IndexOutOfRangeException)
            {
            }
            return isCollision;
        }
        //updates the position of the dwarf
        private static void UpdateDwarf(char[,] world)
        {
            //if there are pressed keys in the console input buffer
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo cki;
                //take the value of the pressed keys
                cki = Console.ReadKey();
                //if readkey is siccessful
                if (cki != null)
                {
                    if (cki.Key == ConsoleKey.RightArrow)
                    {
                        //change the dwarf position to the right
                        dwarfPosition++;
                        try
                        {
                            world[world.GetLength(0) - 1, dwarfPosition + 2] = ')';
                            world[world.GetLength(0) - 1, dwarfPosition + 1] = 'O';
                            world[world.GetLength(0) - 1, dwarfPosition] = '(';
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            dwarfPosition--;
                            while (Console.KeyAvailable)
                            {
                                Console.ReadKey(false);
                            }
                        }
                    }
                    else if (cki.Key == ConsoleKey.LeftArrow)
                    {
                        dwarfPosition--;
                        try
                        {
                            world[world.GetLength(0) - 1, dwarfPosition] = '(';
                            world[world.GetLength(0) - 1, dwarfPosition + 1] = 'O';
                            world[world.GetLength(0) - 1, dwarfPosition + 2] = ')';
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            dwarfPosition++;
                            while (Console.KeyAvailable)
                            {
                                Console.ReadKey(false);
                            }
                        }
                    }
                }
            }
            else
            {
                world[world.GetLength(0) - 1, dwarfPosition + 2] = ')';
                world[world.GetLength(0) - 1, dwarfPosition + 1] = 'O';
                world[world.GetLength(0) - 1, dwarfPosition] = '(';
            }
        }
        //draws all elements on the console
        private static void DrawWorld(char[,] world)
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < world.GetLength(0); row++)
            {
                for (int col = 0; col < world.GetLength(1); col++)
                {
                    sb.Append(world[row, col]);
                }
                sb.Append('\n');
            }
            Console.Write(sb.ToString());
        }
    }
}
