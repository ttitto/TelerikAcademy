using System;
using System.IO;
using System.Linq;
using System.Text;

namespace GameXO
{
   public class Game
    {
        static GameEngine ge;
        static Player playerO = new Player('O');
        static Player playerX = new Player('X');

        static void RunGame()
        {
            bool draw = false;

            while (!draw && !playerO.Win && !playerX.Win)
            {
                ge.DrawBoard();
                if (playerO.IsOnMove)
                {
                    if (playerX.PlayedMoves.Count > 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Player {0} last move was: {1}", playerX.ToString(),
                            playerX.PlayedMoves[playerX.PlayedMoves.Count - 1]);
                    }
                    if (playerO.Play(playerO, playerX, ge.Board))
                    {
                        playerO.IsOnMove = false;
                        playerX.IsOnMove = true;
                        playerO.Win = ge.WinCheck(playerO.PlayedMoves, ge.Board);
                    }
                    else
                    {
                        //go to menu
                        return;
                    }
                }
                else
                {
                    if (playerO.PlayedMoves.Count > 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Player {0} last move was: {1}", playerO.ToString(),
                            playerO.PlayedMoves[playerO.PlayedMoves.Count - 1]);
                    }
                    if (playerX.Play(playerX, playerO, ge.Board))
                    {
                        playerO.IsOnMove = true;
                        playerX.IsOnMove = false;
                        playerX.Win = ge.WinCheck(playerX.PlayedMoves, ge.Board);
                    }
                    else
                    {
                        //go to menu
                        return;
                    }
                }

                //Clause retreive
                draw = ge.DrawCheck(ge.Board);
            }

            ge.DrawBoard();
            if (playerX.Win)
            {
                Console.WriteLine("Congratulation, player {0} won!!", playerX.ToString());
                GameEngine.Pause();
            }
            else if (playerO.Win)
            {
                Console.WriteLine("Congratulation, player {0} won!!", playerO.ToString());
                GameEngine.Pause();
            }
            else
            {
                Console.WriteLine("Draw!!!");
                GameEngine.Pause();
            }

        }

        static void Menu()
        {
            int n = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("1. New Game.");
                Console.WriteLine("2. Load.");
                Console.WriteLine("3. Instruction.");
                Console.WriteLine("4. Continue current game");
                Console.WriteLine("5. Exit.");
                Console.Write("Enter option: ");
                try
                {
                    n = int.Parse(Console.ReadLine());

                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. One of the above numbers is expected!");
                    GameEngine.Pause();
                    continue;
                }

                switch (n)
                {
                    case 1:
                        // Inicializirane na obekt chrez konstruktor na klasa GameEngine, koqto zadava razmer na tablicata.
                        playerO = new Player('O');
                        playerX = new Player('X');
                        ge = new GameEngine();
                        ge.SetFirstPlayer(playerO, playerX);
                        RunGame();
                        break;
                    case 2:
                        // Inicializirane na obekt s zapazeni parametri
                        ge = GameEngine.Load(ref playerO, ref playerX);
                        if (ge != null)
                            RunGame();
                        break;
                    case 3:
                        string instrustionsPath = @"..\..\Instructions.txt";
                        Console.WriteLine("\n" + ReadInstructions(instrustionsPath));
                        GameEngine.Pause();
                        break;
                    case 4:
                        if (ge == null)
                        {
                            Console.WriteLine("Invalid game state! Use NewGame or Load from menu.");
                            GameEngine.Pause();
                        }
                        else
                        {
                            RunGame();
                        }
                        break;
                    case 5: Console.WriteLine("Good Bye!");
                        break;
                    default: Console.WriteLine("Invalid choice!"); GameEngine.Pause();
                        break;
                }
            } while (n != 5);
        }
        /// <summary>
        /// Reads the content of a text file written in Encoding "UTF-8"
        /// </summary>
        /// <param name="path">The path of the txt-file to be read</param>
        /// <returns>A string containing the file content, including new lines.</returns>
        /// <author>Todor Todorov</author>
        public static string ReadInstructions(string path)
        {
            string instruction;
            using (StreamReader sr = new StreamReader(path, Encoding.GetEncoding("UTF-8")))
            {
                instruction = sr.ReadToEnd();
            }
            return instruction;
        }

        static void Main(string[] args)
        {
            Menu();
        }
    }
}
