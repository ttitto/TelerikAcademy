using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace GameXO
{
   public class GameEngine
    {
        const int DefaultSize = 15;
        private char[,] board;

        public char[,] Board
        {
            get { return this.board; }
            private set { this.board = value; }
        }

        public GameEngine()
            : this(DefaultSize)
        {
        }

        public GameEngine(int boardSize)
        {
            this.board = new char[boardSize, boardSize];
        }

        /// <summary>
        /// Pause the game, until a key is pressed
        /// </summary>
        /// 
        public static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Draws the board 15x15
        /// </summary>
        public void DrawBoard()
        {
            Console.Clear();
            Console.Write(" ");
            for (int i = 1; i <= this.board.GetLength(1); i++)
            {
                Console.Write("{0,3}", i);
            }
            Console.WriteLine();
            for (int i = 0; i < this.board.GetLength(0); i++)
            {
                Console.Write("{0}", (char)(i + 65));
                for (int j = 0; j < this.board.GetLength(1); j++)
                {
                    if (this.board[i, j] == '\0')
                    {
                        Console.Write("{0,3}", '.');
                    }
                    else
                    {
                        Console.Write("{0,3}", this.board[i, j]);
                    }
                }
                Console.Write("{0,3}", (char)(i + 65));
                Console.WriteLine();
            }

            Console.Write(" ");
            for (int i = 1; i <= this.board.GetLength(1); i++)
            {
                Console.Write("{0,3}", i);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Select which player is going to play first: Player O or Player X. Waiting for an input - the number of the choice.
        /// </summary>
        /// If an incorrect choice is entered, a message appears "Invalid choice, please try again", the player has to make a new choice.
        public void SetFirstPlayer(Player playerO, Player playerX)
        {
            bool isChoiceValid = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Who will play first?");
                Console.WriteLine("1. Player " + playerO.PlayerFigure);
                Console.WriteLine("2. Player " + playerX.PlayerFigure);
                int n;
                isChoiceValid = int.TryParse(Console.ReadLine(), out n);
                if (isChoiceValid)
                {
                    switch (n)
                    {
                        case 1: playerO.IsOnMove = true;
                            break;
                        case 2: playerX.IsOnMove = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice, please try again");
                            Pause();
                            isChoiceValid = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again");
                    Pause();
                }
            } while (!isChoiceValid);
        }

        /// <summary>
        /// Loads the saved GameEngine state.
        /// </summary>
        /// <param name="playerO">The player O.</param>
        /// <param name="playerX">The player X.</param>
        /// 
        /// <returns>GameEngine</returns>
        /// Throws argument exception if file doesn't exist
        public static GameEngine Load(ref Player playerO, ref Player playerX)
        {
            GameEngine engine;
            string fileName = GetFileName();
            if (File.Exists(fileName))
            {
                var document = XDocument.Load(fileName);
                var playerElement = document.Root.Descendants("Player");
                var enumerator = playerElement.GetEnumerator();
                enumerator.MoveNext();
                playerO = LoadPlayer(enumerator.Current);
                engine = new GameEngine();
                engine.ReplayMoves(playerO);
                enumerator.MoveNext();
                playerX = LoadPlayer(enumerator.Current);
                engine.ReplayMoves(playerX);
            }
            else
            {
                Console.WriteLine("File doesn't exist!");
                return null;
            }
            return engine;
        }

        public void ReplayMoves(Player player)
        {
            foreach (var move in player.PlayedMoves)
            {
                int row, col;
                if (Decode(move, out row, out col))
                    this.Board[row, col] = player.PlayerFigure;
            }
        }

        private static Player LoadPlayer(XElement playerElement)
        {
            //Load player figure - first char of a string
            char playerFigure = GetXmlTagValue(playerElement, "PlayerFigure")[0];
            //Load moves
            var moveElements = playerElement.Descendants("Move");
            var playerMoves = new List<string>();
            foreach (var move in moveElements)
            {
                playerMoves.Add(move.Value);
            }
            Player player = new Player(playerMoves, playerFigure);
            string value = GetXmlTagValue(playerElement, "IsOnMove");
            player.IsOnMove = bool.Parse(value);
            return player;
        }

        private static string GetXmlTagValue(XElement playerElement, string tagName)
        {
            //Load player figure as string 
            var enumerator = playerElement.Descendants(tagName).GetEnumerator();
            enumerator.MoveNext();
            return enumerator.Current.Value;
        }

        /// <summary>
        /// Saves the specified players.
        /// </summary>
        /// <param name="players">The players array.</param>
        public static void Save(params Player[] players)
        {
            string fileName = GetFileName();
            if (!File.Exists(fileName) || ConfirmOverwrite(fileName))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                using (var xmlWriter = XmlWriter.Create(fileName, settings))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Game");
                    foreach (var player in players)
                    {
                        SavePlayer(xmlWriter, player);
                    }
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                }
            }
        }

        private static string GetFileName()
        {
            Console.Write("Enter savegame name: ");
            string fileName = Console.ReadLine();
            if (!fileName.Contains("."))
            {
                fileName = fileName + ".xml";
            }
            return fileName;
        }

        private static void SavePlayer(XmlWriter xmlWriter, Player player)
        {
            xmlWriter.WriteStartElement("Player");
            xmlWriter.WriteElementString("PlayerFigure", player.PlayerFigure.ToString());
            xmlWriter.WriteElementString("IsOnMove", player.IsOnMove.ToString());
            var moves = player.PlayedMoves;
            for (int i = 0; i < moves.Count; i++)
            {
                xmlWriter.WriteElementString("Move", moves[i]);
            }
            xmlWriter.WriteEndElement();
        }

        private static bool ConfirmOverwrite(string fileName)
        {
            bool isConfirmed = false;
            Console.Write("File \"{0}\" exists! overwrite? ", fileName);
            string confirmation = Console.ReadLine().Trim();
            if (!string.IsNullOrWhiteSpace(confirmation) && char.ToLower(confirmation[0]) == 'y')
            {
                isConfirmed = true;
            }
            return isConfirmed;
        }

        /// <summary>
        /// Checks if there are 5 consecutive symbols from the last placed symbol in horizontal, vertical and both diagonal directions
        /// </summary>
        /// <param name="list">A list of strings representing each move in format "5b".</param>
        /// <param name="board">The playing desk updated with the last move.</param>
        /// <returns>TRUE if there are five consecutive symbols around the last placed symbol, Otherwise returns FALSE</returns>
        /// Doesn't throw any exceptions
        /// <author>Todor Todorov</author>        
        public bool WinCheck(List<string> list, char[,] board)
        {
            int dimRow;
            int dimCol;
            Decode(list[list.Count - 1], out dimRow, out dimCol);
            char currChar = board[dimRow, dimCol];
            Regex winMatch = new Regex(@"[" + currChar + @"]{5}");
            StringBuilder sbNearFields = new StringBuilder();
            int startRow, endRow, startCol, endCol;
            //Horizontal wincheck
            startRow = endRow = dimRow;
            if (dimCol >= 5 && dimCol <= 9)
            {
                startCol = dimCol - 4;
                endCol = dimCol + 4;
            }
            else if (dimCol < 5)
            {
                startCol = 0;
                endCol = dimCol + 4;
            }
            else// if (Dim1 > 9)
            {
                endCol = 14;
                startCol = dimCol - 4;
            }
            for (int i = startCol; i <= endCol; i++)
            {
                sbNearFields.Append(board[dimRow, i]);
            }
            if (winMatch.IsMatch(sbNearFields.ToString())) return true;
            sbNearFields.Clear();
            //Vertical wincheck
            startCol = endCol = dimCol;
            if (dimRow >= 5 && dimRow <= 9)
            {
                startRow = dimRow - 4;
                endRow = dimRow + 4;
            }
            else if (dimRow < 5)
            {
                startRow = 0;
                endRow = dimRow + 4;
            }
            else //if (dimRow)>9
            {
                endRow = 14;
                startRow = dimRow - 4;
            }
            for (int i = startRow; i <= endRow; i++)
            {
                sbNearFields.Append(board[i, dimCol]);
            }
            if (winMatch.IsMatch(sbNearFields.ToString())) return true;
            sbNearFields.Clear();
            //Diagonal to right top check
            endRow = startRow = dimRow;
            endCol = startCol = dimCol;
            int counter = 1;
            while (endRow >= 0 && endCol <= 14 && counter < 6)
            {
                sbNearFields.Append(board[endRow, endCol]);
                endRow--;
                endCol++;
                counter++;
            }
            counter = 2;
            startRow++;
            startCol--;
            while (startRow <= 14 && startCol >= 0 && counter < 6)
            {
                sbNearFields.Insert(0, board[startRow, startCol]);
                startRow++;
                startCol--;
                counter++;
            }
            if (winMatch.IsMatch(sbNearFields.ToString())) return true;
            sbNearFields.Clear();
            //Diagonal to right bottom check
            endRow = startRow = dimRow;
            endCol = startCol = dimCol;
            counter = 1;
            while (counter < 6 && startRow <= 14 && startCol <= 14)
            {
                sbNearFields.Insert(0, board[startRow, startCol]);
                counter++;
                startRow++;
                startCol++;
            }
            counter = 2;
            endRow--;
            endCol--;
            while (counter < 6 && endRow >= 0 && endCol >= 0)
            {
                sbNearFields.Append(board[endRow, endCol]);
                counter++;
                endRow--;
                endCol--;
            }
            if (winMatch.IsMatch(sbNearFields.ToString())) return true;
            sbNearFields.Clear();

            return false;
        }
        //Decodes the entry in the list with moves from ex. 9B to row=1; col=8;
        /// <summary>
        /// Decodes the user input of the position to coordinates of a position in a two-dimensional array
        /// </summary>
        /// <param name="move">Holds the last input in user friendly format, only valid input is expected, Otherwise throws unhandled FormatException</param>
        /// <param name="row"> Holds the row of the current user input; is returned as an out parameter</param>
        /// <param name="col">Holds the column of the current user input; it is returned as an out parameter</param>
        /// <author>Lyubka Nikiforova</author>
        public static bool Decode(string move, out int row, out int col)
        {
            string trimMoveCharLs = Regex.Replace(move, @"[\d-\s-]", string.Empty);
            string trimMoveDigitLs = Regex.Replace(move, @"[^0-9]+", string.Empty);

            if (trimMoveCharLs.Length != 1 || trimMoveDigitLs.Length > 2 || trimMoveDigitLs.Length < 1)
            {
                row = -1;
                col = -1;
                return false;
            }
            else
            {
                col = int.Parse(trimMoveDigitLs) - 1;
                row = char.Parse(trimMoveCharLs.ToUpper()) - 65;

                if (row >= DefaultSize || col >= DefaultSize)
                {
                    return false;
                }
                return true;
            }
        }
        //Proverka za ravenstvo. Ravenstvo e samo kogato tablicata e pylna.
        /// <summary>
        /// Checks if there are empty positions on the desk
        /// </summary>
        /// <param name="board">Holds the chars on the game desk</param>
        /// <returns>TRUE if all positions on the desk are busy, Otherwise returns FALSE</returns>
        /// <author>Todor Todorov</author>
        public bool DrawCheck(char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == '\0') return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks if the position on the board is empty
        /// </summary>
        /// <param name="row">A row in the game desk</param>
        /// <param name="col">A column in the game desk</param>
        /// <param name="board">The game desk</param>
        /// <returns>TRUE if the position on the desk is empty; Otherwise returns FALSE</returns>        
        public static bool CheckPossition(int row, int col, char[,] board)
        {
            bool emptyPos = false;
            if (board[row, col] == '\0')
            {
                emptyPos = true;
            }
            return emptyPos;
        }


    }
}

