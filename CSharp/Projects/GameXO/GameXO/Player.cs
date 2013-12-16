using System;
using System.Collections.Generic;

namespace GameXO
{
    public class Player
    {
        public char PlayerFigure { set; get; }
        public bool IsOnMove { get; set; }

        /// <summary>
        /// Keep the player's moves
        /// </summary>
        public List<string> PlayedMoves { get; set; }

        public bool Win { get; set; }

        private Player()
        {
            PlayedMoves = new List<string>();
            IsOnMove = false;
        }
        public Player(char playerFigure)
        {
            this.PlayerFigure = playerFigure;
            this.PlayedMoves = new List<string>();
            this.Win = false;
        }

        public Player(List<string> playedMoves, char playerFigure)
            : this()
        {
            this.PlayedMoves = playedMoves;
            this.PlayerFigure = playerFigure;
            this.Win = false;
        }

        /// <summary>
        /// </summary>
        /// <returns>Player figure as string</returns>
        public string ToString()
        {
            return PlayerFigure.ToString();
        }

        /// <summary>
        /// The player enters his move. The move is like 5b or 5B (case non-sensitive)
        /// In case the move looks like bb5, b5b, 55b bb 55 ... a message is raised
        /// If the player enters b5, it is transformed to 5b
        /// If the player enters "5   b", "b   5", it is transformed to 5b
        /// If the player enters possition outside the board, a message is raised.
        /// If the player's move is correct, the board is field with the player's figure
        /// </summary>
        /// <param name="currentPlayer"></param>
        /// <param name="otherPlayer"></param>
        /// <param name="board"></param>
        /// <author>Lyubka Nikiforova</author>
        public bool Play(Player currentPlayer, Player otherPlayer, char[,] board)
        {
            string move;
            int row;
            int col;
            bool playerMoved = false;

            do
            {
                Console.Write("Player {0} turn (Ex. 9a or 9A), or command Save/Menu:", currentPlayer.PlayerFigure);
                move = Console.ReadLine();
                if (move.Trim().ToUpper().Equals("MENU"))
                {
                    break;
                }
                else if (move.Trim().ToUpper().Equals("SAVE"))
                {
                    GameEngine.Save(currentPlayer, otherPlayer);
                }
                else if (GameEngine.Decode(move, out row, out col))
                {
                    if (GameEngine.CheckPossition(row, col, board))
                    {
                        currentPlayer.PlayedMoves.Add(string.Format("{0}{1}", col + 1, (char)(row + 65)));
                        board[row, col] = currentPlayer.PlayerFigure;
                    }
                    playerMoved = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            } while (true);

            return playerMoved;
        }
    }
}

