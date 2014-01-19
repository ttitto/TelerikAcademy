using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using System.Text;

namespace NinjaSquash
{
    class GameUI
    {
        //TODO: Има проблем със свързването с енджина. Големините на конзолите ни се различават.
        // нарочно е това и нямаше никакъв проблем (освен ако не сте затрили нещо)

        static string intro = @"..\..\intro_screen.txt";
        static string help_screen = @"..\..\help_screen.txt";
        static string top_results = @"..\..\top_results.txt";
        static string gameover_screen = @"..\..\gameover_screen.txt";


        public static void IntroPlayer()
        {
            PrintingFileContentOnScreen(intro);

            ReadingKeyAndOpenNewScreen();
        }

        public static void OpenHelpMenu()
        {
            Console.Clear();

            PrintingFileContentOnScreen(help_screen);

            ReadingKeyAndOpenNewScreen();
        }

        public static void OpenGame()
        {
            //GameEngine.Initialize();
            //GameEngine.Run();
        }

        public static void OpenHighScore() 
        {
            Console.Clear();

            PrintingFileContentOnScreen(top_results);

            ReadingKeyAndOpenNewScreen();
        }

        public static void CloseGame()
        {
            System.Environment.Exit(1);
        }
        public static void GameOver()
        {
            Console.Clear();

            CSounds.musicThread.Suspend();
            
            PrintingGameOverScreen(gameover_screen);

            ReadingKeyAndOpenNewScreen();
        }

        private static void ReadingKeyAndOpenNewScreen()
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);

            if (pressedKey.Key == ConsoleKey.F1)
            {
                OpenHelpMenu();
            }

            else if (pressedKey.Key == ConsoleKey.F2)
            {
                OpenGame();
            }

            else if (pressedKey.Key == ConsoleKey.F3)
            {
                GameEngine.LoadGame();
            }

            else if (pressedKey.Key == ConsoleKey.F4)
            {
                OpenHighScore();
                //CloseGame();
            }
            else if (pressedKey.Key == ConsoleKey.F5)
            {
                CloseGame();
            }
            else if (pressedKey.Key == ConsoleKey.F8)
            {
                IntroPlayer();
            }
            else
            {
                ReadingKeyAndOpenNewScreen();
            }
        }

        public static void PrintingFileContentOnScreen(string stringWitPath) 
        {
            //console init
            Console.BufferHeight = Console.WindowHeight = 40;
            Console.BufferWidth = Console.WindowWidth = 80;
            Console.OutputEncoding = Encoding.Unicode;

            using (StreamReader stream = new StreamReader(stringWitPath))
            {
                while (!stream.EndOfStream)
                {
                    Console.WriteLine(stream.ReadLine());
                    Thread.Sleep(30);
                }
            }
        }
        public static void PrintingGameOverScreen(string stringWitPath)
        {
            Console.BufferHeight = Console.WindowHeight = 50;
            Console.BufferWidth = Console.WindowWidth = 120;
            Console.OutputEncoding = Encoding.Unicode;
            Console.SetCursorPosition(0, Console.WindowHeight / 2);

            using (StreamReader stream = new StreamReader(stringWitPath))
            {
                while (!stream.EndOfStream)
                {
                    Console.WriteLine(stream.ReadLine());
                }
            }
        }
    }
}