using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaSquash
{
    public class GameObject
    {

        public GameObject(int row, int col, char[,] shape, int speed = 0)
        {
            this.Row = row;
            this.Col = col;
            this.Shape = shape;
            this.Directions = new int[2] { 0, 0 };
            this.Speed = speed;
            this.IsDestroyed = false;
            //Testing, testing~
        }

        char[,] shape;
        int row;
        int col;
        int[] directions;
        int speed;
        bool isDestroyed;

        public char[,] Shape
        {
            get { return this.shape; }
            set
            {
                if (value == null) throw new ArgumentNullException("Shape can not be null!");
                this.shape = value;
            }
        }
        public int Row
        {
            get { return this.row; }
            set { this.row = value; }
        }
        public int Col
        {
            get { return this.col; }
            set { this.col = value; }
        }
        public int[] Directions
        {
            get { return this.directions; }
            set
            {
                if (value == null) throw new ArgumentNullException("Directions can not be null!");
                this.directions = value;
            }
        }
        public int Speed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }
        public bool IsDestroyed
        {
            get { return this.isDestroyed; }
            set { this.isDestroyed = value; }
        }
        public virtual void Update()
        {
            //collision of GameObjects with the Ball
            //Check if it isn't the ball
            if (this.GetType() != typeof(Ball))
            {
                //right and left side collision
                if ((GameEngine.gameObjects[0].Col == this.Col + this.Shape.GetLength(1) || GameEngine.gameObjects[0].Col == this.Col-1 ||
                    GameEngine.gameObjects[0].Col == this.Col + this.Shape.GetLength(1)+1 || GameEngine.gameObjects[0].Col == this.Col) &&
                    (GameEngine.gameObjects[0].Row >= this.Row &&
                    GameEngine.gameObjects[0].Row <= this.Row + this.Shape.GetLength(0)-1))
                {
                    this.IsDestroyed = true;
                    GameEngine.gameObjects[0].Directions[1] *= -1;
                    GameEngine.gameObjects[0].Speed = 1;
                    Ball.iterationCounter = 1;
                }
                //top and bottom side collision
                if ((GameEngine.gameObjects[0].Row == this.Row-1 || GameEngine.gameObjects[0].Row == this.Row + this.Shape.GetLength(0) ||
                    GameEngine.gameObjects[0].Row == this.Row || GameEngine.gameObjects[0].Row == this.Row + this.Shape.GetLength(0)+1) &&
                    (GameEngine.gameObjects[0].Col >= this.Col &&
                    GameEngine.gameObjects[0].Col <= this.Col + this.Shape.GetLength(1)-1))
                {
                    this.IsDestroyed = true;
                    GameEngine.gameObjects[0].Speed = 1;
                    Ball.iterationCounter = 1;
                    GameEngine.gameObjects[0].Directions[0] *= -1;
                }



            }
        }
    }
}
