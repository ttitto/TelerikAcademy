using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace NinjaSquash
{
    class Racket
    {
        // statics

        static readonly int horizontal = Console.WindowWidth;
        static readonly int vertical = Console.WindowHeight;
        public static int padX = horizontal / 2;
        public static int padY = vertical / 2;
        public static int padLength = 7;
        
        public static void MovePad()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                if (padY > -1 && padY + padLength < vertical + 1
                    && padX < ((horizontal / 2 + (horizontal / 12)) + 1)
                    && padX > ((horizontal / 2 - (horizontal / 12)) - 1))// set padX depend by %
                {
                    ExecuteKeyMove(key);
                }
            }
        }
        static void ExecuteKeyMove(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.LeftArrow && padX > (horizontal / 2 - (horizontal / 12)) || key.Key == ConsoleKey.J && padX > (horizontal / 2 - (horizontal / 12)))
            {
                
                for (int i = 0; i < padLength; i++)
                {
                    Console.SetCursorPosition(padX, padY + i);
                }
                padX--;
                Console.SetCursorPosition(padX, padY);
            }
            if (key.Key == ConsoleKey.RightArrow && padX < (horizontal / 2 + (horizontal / 12)) || key.Key == ConsoleKey.L && padX < (horizontal / 2 + (horizontal / 12)))
            {
                for (int i = 0; i < padLength; i++)
                {
                    Console.SetCursorPosition(padX, padY + i);
                }
                padX++;
                Console.SetCursorPosition(padX, padY);
            }
            if (key.Key == ConsoleKey.UpArrow && padY > 0 || key.Key == ConsoleKey.I && padY > 0)
            {
                padY--;
                Console.SetCursorPosition(padX, padY + padLength);
            }
            if (key.Key == ConsoleKey.DownArrow && padY + padLength < vertical || key.Key == ConsoleKey.K && padY + padLength < vertical)
            {
                padY++;
                Console.SetCursorPosition(padX, padY - 1);
            }
            if (key.Key == ConsoleKey.F8)
            {
                Console.Clear();

                CSounds.musicThread.Suspend();
                GameEngine.SaveGame();
            }
        }
    }
}
