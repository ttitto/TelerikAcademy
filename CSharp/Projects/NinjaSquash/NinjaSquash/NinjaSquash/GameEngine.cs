using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NinjaSquash
{
    public class GameEngine
    {
        private static int bufferHeight = 50; //same as GameUI but different value!
        private static int bufferWidth = 120;
        private const string EXTENSION = ".txt";
        private const string GAME_PATH = @"..\..\gamesav\";

        public static void engineMain()
        {
            //DONE: Initialize game
            //DONE: Move racket -- Steph ->class Racket
            //DONE: Move ball -- ttitto
            //DONE: Implement the change of the ball's speed -- ttitto
            //DONE: Implement collision behaviour with walls -- ttitto
            //DONE: Implement collision behaviour with racket
            //DONE: Implement collision behaviour with static objects
            //DONE: Print updated gameField -- OzoneBg
            //DONE: Save game to a file and load game -- Yanko
        }
        //the first object is always the ball: gameObjects[1]
        //All other objects are the targets
        public static List<GameObject> gameObjects = new List<GameObject>();
        public static List<GameObject> destroyed = new List<GameObject>();
        static Random rnd = new Random();
        static readonly float RACKETAREA = 0.4f;

        public static void Initialize()
        {
            //Console screen and buffer init
            Console.SetBufferSize(bufferWidth, bufferHeight);
            Console.SetWindowSize(bufferWidth + 1, bufferHeight + 1);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            gameObjects.Insert(0, new Ball(0, 2, new char[1, 1] { { '@' } }, 1)); //the ball
            //gameObjects.Insert(1, new.... );  //the racket

            //add the random object to the gameObjects list
            for (int i = 0; i < rnd.Next(10, 40); i++)
            {
                gameObjects.Add(GenerateRandomObject());
            }
            Console.Clear();
            InitialPrint();
        }
        public static void Run()
        {
            CSounds.StartMusic();  //MUSIC START

            while (true)
            {
                //Console.Clear();
                RemoveDestroyed();
                UpdateAll();
                ClearPad();
                Print();
                Racket.MovePad();
                Thread.Sleep(50);
            }
        }
        //generates random objects at random positions
        private static GameObject GenerateRandomObject()
        {
            char[] characters = new char[] { '#', '%', '&', '*', '+', 'O', '0' };
            char[,] shape = new char[rnd.Next(2, 6), rnd.Next(2, 6)];
            char rndChar = characters[rnd.Next(0, characters.Length)];
            for (int row = 0; row < shape.GetLength(0); row++)
            {
                for (int col = 0; col < shape.GetLength(1); col++)
                {
                    shape[row, col] = rndChar;
                }
            }
            if (rnd.Next(0, 2) == 0)
            {
                GameObject gObj = new GameObject(
                               rnd.Next(1, bufferHeight - 6),
                               rnd.Next(1, (int)((0.5 - RACKETAREA / 2) * bufferWidth) - shape.GetLength(1) > 0 ?
                               (int)((0.5 - RACKETAREA / 2) * bufferWidth) - shape.GetLength(1) : 1),
                               shape
                               );
                return gObj;
            }
            else
            {
                GameObject gObj = new GameObject(
                              rnd.Next(1, bufferHeight-6),
                              rnd.Next(bufferWidth / 2 + (int)(RACKETAREA * bufferWidth / 2), bufferWidth - shape.GetLength(1)),
                              shape
                              );
                return gObj;
            }

        }

        private static void UpdateAll()
        {
            destroyed.Add(gameObjects[0]);
            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i].IsDestroyed == true)
                {
                    Console.Beep(1998, 300); //BEEP with destroy
                    destroyed.Add(gameObjects[i]);
                    gameObjects.Remove(gameObjects[i]);
                }
                else
                {
                    gameObjects[i].Update();
                }
            }
        }
        //Removes the objects that are hit by the ball
        private static void RemoveDestroyed()
        {
            foreach (var item in destroyed)
            {
                for (int row = 0; row < item.Shape.GetLength(0); row++)
                {
                    for (int col = 0; col < item.Shape.GetLength(1); col++)
                    {
                        Console.SetCursorPosition(item.Col + col, (item.Row + row) <= bufferHeight ? item.Row + row : bufferHeight);
                        Console.Write(" ");
                    }
                }
            }
            destroyed.Clear();
        }
        private static void InitialPrint()
        {
            //Game Objects drawing
            foreach (var item in gameObjects)
            {
                Console.ForegroundColor = (ConsoleColor)(rnd.Next(Enum.GetNames(typeof(ConsoleColor)).Length));
                if (Console.ForegroundColor==ConsoleColor.DarkBlue)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                for (int row = 0; row < item.Shape.GetLength(0); row++)
                {
                    for (int col = 0; col < item.Shape.GetLength(1); col++)
                    {
                        Console.SetCursorPosition(item.Col + col, (item.Row + row) <= bufferHeight ? item.Row + row : bufferHeight);
                        Console.WriteLine("{0}", item.Shape[0, 0]);
                    }
                }
            }
        }
        private static void ClearPad()
        {
            for (int i = Racket.padY; i < Racket.padY + Racket.padLength + 2; i++)
            {
                if (i == 0) i = 1;
                if (i > bufferHeight + 1) return;
                Console.SetCursorPosition(Racket.padX - 2, i - 1);
                Console.Write("      ");
            }
        }
        private static void Print()
        {
            //Print speed
            Console.CursorVisible = false;
            //Console.SetCursorPosition(Console.WindowLeft, Console.WindowTop);
            //Console.Write("Speed:     ");
            Console.SetCursorPosition(Console.WindowLeft, Console.WindowTop);
            Console.Write("Speed: {0}", Ball.LIMIT - GameEngine.gameObjects[0].Speed);
            if (Ball.LIMIT - GameEngine.gameObjects[0].Speed < 100)
            {
                Console.SetCursorPosition(Console.WindowLeft + 9, Console.WindowTop);
                Console.Write(" ");
            }
            if (Ball.LIMIT - GameEngine.gameObjects[0].Speed < 10)
            {
                Console.SetCursorPosition(Console.WindowLeft + 8, Console.WindowTop);
                Console.Write(" ");
            }

            //Print objects
            for (int row = 0; row < gameObjects[0].Shape.GetLength(0); row++)
            {
                for (int col = 0; col < gameObjects[0].Shape.GetLength(1); col++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.SetCursorPosition(gameObjects[0].Col + col, gameObjects[0].Row + row);
                    Console.WriteLine("{0}", gameObjects[0].Shape[0, 0]);
                }
            }
            //The pad
            for (int i = Racket.padY; i < Racket.padY + Racket.padLength; i++)
            {
                Console.SetCursorPosition(Racket.padX, i);
                Console.Write("##");
            }
        }


        //<<<------------Load/Save GAME------------->>>\\
        /// <summary>                                  \\\
        ///                 [x]LoadGame                \\\
        ///                 [x]SaveGame                \\\
        /// </summary>                                 \\\
        //<<<------------Load/Save GAME------------->>>\\


        public static void LoadGame()
        {
            Console.Clear();
            try
            {
                CheckDirectory(GAME_PATH);
            }
            catch (Exception)
            {
            }
            try
            {
                CheckInsertedGame(GetWantedGame());
            }
            catch (Exception)
            {
            }
        }

        public static void SaveGame()
        {
            //Check for existing folder
            try
            {
                if (!Directory.Exists(GAME_PATH))
                {
                    Directory.CreateDirectory(GAME_PATH);
                }
            }
            catch (Exception)
            {
                //TODO: catch the exceptions 
            }
            CheckNameBeforeSaving(GetNameForSaving());
        }

        private static string GetWantedGame()
        {
            Console.Write("Type in the game you want to start: ");
            string gameName = Console.ReadLine();
            return gameName;
        }

        private static void CheckInsertedGame(string gameName)
        {
            if (File.Exists(string.Concat(GAME_PATH, gameName, EXTENSION)))
            {
                //LoadFromFile(gameName);
            }
            else
            {
                Console.WriteLine("Reccord not found!!!");
                Thread.Sleep(2000);
                Console.Clear();
                PrintSavedGames(GAME_PATH);
                CheckInsertedGame(GetWantedGame());
            }

        }

        private static void LoadFromFile(string gameName)
        {
            using (StreamReader readGameInfo = new StreamReader(string.Concat(GAME_PATH, gameName, EXTENSION)))
            {
                string line = readGameInfo.ReadLine();
                int index = 0;
                string[] data = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                char[,] shapeArr = new char[int.Parse(data[2]), int.Parse(data[3])];

                for (int row = 0; row < shapeArr.GetLength(0); row++)
                {
                    for (int col = 0; col < shapeArr.GetLength(1); col++)
                    {
                        shapeArr[row, col] = GenerateChar();
                    }
                }

                gameObjects.Insert(index, new Ball(int.Parse(data[0]), int.Parse(data[1]), shapeArr, int.Parse(data[4])));

                while ((line = readGameInfo.ReadLine()) != null)
                {
                    data = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    char[,] hapeArr = new char[int.Parse(data[2]), int.Parse(data[3])];

                    for (int row = 0; row < shapeArr.GetLength(0); row++)
                    {
                        for (int col = 0; col < shapeArr.GetLength(1); col++)
                        {
                            shapeArr[row, col] = GenerateChar();
                        }
                    }
                    gameObjects.Add(new GameObject(int.Parse(data[0]), int.Parse(data[1]), shapeArr, int.Parse(data[4])));
                }
            }

            GameEngine.Run();
        }

        private static char GenerateChar()
        {
            char[] chars = { '#', '%', '&', '*', '+', 'O', '0' };
            Random r = new Random();
            return chars[r.Next(0, chars.Length)];
        }

        static char[,] Shape(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = '%';
                }
            }
            return matrix;
        }

        private static void CheckDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine("No such directory");
                Console.WriteLine("Loading...");
                Thread.Sleep(2000);
                GameUI.IntroPlayer();
            }
            else
            {
                PrintSavedGames(GAME_PATH);
            }

        }

        private static void PrintSavedGames(string GAME_PATH)
        {
            string[] files = Directory.GetFiles(GAME_PATH);

            if (files.Count() > 0)
            {
                Console.WriteLine("Your savings: \n");

                foreach (var file in files)
                {
                    Console.WriteLine(file.Substring(file.LastIndexOf('\\') + 1, file.LastIndexOf('.') - 1 - file.LastIndexOf('\\')));
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No Savings");
                Console.WriteLine("Loading...");
                Thread.Sleep(2000);
                //TODO: go to main menu
                GameUI.IntroPlayer();
            }
        }

        private static void CheckNameBeforeSaving(string gameSave)
        {
            if (File.Exists(string.Concat(GAME_PATH, gameSave, EXTENSION)))
            {
                Console.WriteLine("{0} already exist!", gameSave);
                Console.Write("Overwrite it?(y/n): ");
                ConsoleKeyInfo key = Console.ReadKey();
                GetKeyPressed(key.Key, gameSave);
            }
            else
            {
                SaveGameToFile(gameSave);
            }

        }

        private static string GetNameForSaving()
        {
            Console.Write("Please enter name of your save: ");
            string gameSave = Console.ReadLine();
            return gameSave;
        }

        private static void GetKeyPressed(ConsoleKey key, string game)
        {
            if (key == ConsoleKey.N)
            {
                CheckNameBeforeSaving(GetNameForSaving());

            }
            else if (key == ConsoleKey.Y)
            {
                SaveGameToFile(game);
            }
            else
            {
                Console.WriteLine("Invalid choice!");
                CheckNameBeforeSaving(GetNameForSaving());
            }
        }

        private static void SaveGameToFile(string gameSave)
        {
            //(List <> GameObjects ())
            using (StreamWriter saveGame = new StreamWriter(string.Concat(GAME_PATH, gameSave, EXTENSION)))
            {
                foreach (var item in gameObjects)
                {
                    if (!item.IsDestroyed)
                    {
                        saveGame.WriteLine("{0}, {1}, {2}, {3}, {4}", item.Row, item.Col, item.Shape.GetLength(0), item.Shape.GetLength(1), item.Speed);
                    }

                }
                
            }
            Console.Clear();
            GameUI.IntroPlayer();
            GameEngine.Initialize();
        }
    }
}
