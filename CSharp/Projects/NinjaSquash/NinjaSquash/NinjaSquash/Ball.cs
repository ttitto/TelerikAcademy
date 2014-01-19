using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaSquash
{
    public class Ball : GameObject
    {
        public Ball(int row, int col, char[,] shape, int speed)
            : base(row, col, shape, speed)
        {

            this.Directions = new int[2] { -1, 1 };
        }
        public const decimal LIMIT = 300;
        public static int iterationCounter = 1;
        public override void Update()
        {
            //TODO: Implement ball stopped case
            if (GameEngine.gameObjects[0].Speed == LIMIT)
            {
                GameUI.GameOver();
                return;
                //   throw new NotImplementedException("Ball stopped");
            }
            if (iterationCounter % GameEngine.gameObjects[0].Speed == 0)
            {
                //DONE: Implement changes of the ball movement coordinates -- ttitto
                //collision with upper and bottom wall
                if (GameEngine.gameObjects[0].Row == 0 || GameEngine.gameObjects[0].Row == Console.WindowHeight - 2)
                {
                    Console.Beep(1408, 250); //BEEP wall
                    GameEngine.gameObjects[0].Directions[0] *= -1;
                }
                //collision with left and right wall
                if (GameEngine.gameObjects[0].Col == 0 || GameEngine.gameObjects[0].Col == Console.WindowWidth - 1)
                {
                    Console.Beep(1408, 250); //BEEP wall
                    GameEngine.gameObjects[0].Directions[1] *= -1;
                }
                //Collision with racket
                if ((GameEngine.gameObjects[0].Col == Racket.padX - 1 || GameEngine.gameObjects[0].Col == Racket.padX + 2) &&
                    GameEngine.gameObjects[0].Row <= Racket.padY + Racket.padLength &&
                    GameEngine.gameObjects[0].Row >= Racket.padY)
                {
                    Console.Beep(1408, 250); //BEEP racket
                    GameEngine.gameObjects[0].Directions[1] *= -1;
                }

                //update ball's coordinates
                GameEngine.gameObjects[0].Row += GameEngine.gameObjects[0].Directions[0];
                GameEngine.gameObjects[0].Col += GameEngine.gameObjects[0].Directions[1];

                GameEngine.gameObjects[0].Speed++;
                iterationCounter = (int)(GameEngine.gameObjects[0].Speed * 0.98);
            }
            else
            {
                iterationCounter++;
            }
        }
    }
}
