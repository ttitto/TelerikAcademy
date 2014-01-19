using System;
using System.Collections.Generic;
using System.Media;
using System.Threading;

//The main class for playing Sounds in the game.

namespace NinjaSquash
{
    public static class CSounds
    {
        //Initialize variables
        private static ThreadStart musicMethod;
        public static Thread musicThread;

        public static void StartMusic()
        {
            musicMethod = new ThreadStart(SoundPlayer);
            musicThread = new Thread(musicMethod);
            musicThread.Start();
        }

        private static void SoundPlayer()
        {
            Console.Beep(440, 500); Console.Beep(440, 500);
            Console.Beep(440, 500); Console.Beep(349, 350);
            Console.Beep(523, 150); Console.Beep(440, 500);
            Console.Beep(349, 350); Console.Beep(523, 150);
            Console.Beep(440, 1000); Console.Beep(600, 500);
            Console.Beep(600, 500); Console.Beep(600, 500);
            Console.Beep(500, 350); Console.Beep(683, 150);
            Console.Beep(600, 500); Console.Beep(500, 350);
            Console.Beep(683, 150); Console.Beep(600, 1000);
            Console.Beep(349, 650);

            while (true)
            {
                Thread.Sleep(100);
                Console.Beep(440, 500); Console.Beep(440, 500);
                Console.Beep(440, 500); Console.Beep(349, 350);
                Console.Beep(523, 150); Console.Beep(440, 500);
                Console.Beep(349, 350); Console.Beep(523, 150);
                Console.Beep(440, 1000); Console.Beep(600, 500);
                Console.Beep(600, 500); Console.Beep(600, 500);
                Console.Beep(500, 350); Console.Beep(683, 150);
                Console.Beep(600, 500); Console.Beep(500, 350);
                Console.Beep(683, 150); Console.Beep(600, 1000);
                Console.Beep(349, 650);
            }
        }
    }
}