using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));
                engine.AddObject(currBlock);
            }

            //Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            //engine.AddObject(theBall);

            ////Test Meteoritball
            //MeteoriteBall metball = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            //engine.AddObject(metball);
            //metball.ProduceObjects();
            ////End test Meteoritball

            //Test unstoppable ball
            UnstoppableBall unstopBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            engine.AddObject(unstopBall);
            //End test unstoppable ball

            //Add GiftBlock
            GiftBlock myGift = new GiftBlock(new MatrixCoords(4, 10));
            engine.AddObject(myGift);

            //Add ExplodingBlock 
            ExplodingBlock explode = new ExplodingBlock(new MatrixCoords(2,16));
            engine.AddObject(explode);
            ExplodingBlock explode1 = new ExplodingBlock(new MatrixCoords(4, 25));
            engine.AddObject(explode1);

            //Add UnpassableBlock
            UnpassableBlock unpass = new UnpassableBlock(new MatrixCoords(20, 18));
            engine.AddObject(unpass);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);
            engine.AddObject(theRacket);
            /*1.The AcademyPopcorn class contains an IndestructibleBlock class. Use it to create side 
             * and ceiling walls to the game. You can ONLY edit the AcademyPopcornMain.cs file.*/
            for (int ii = 0; ii < WorldRows; ii++)
            {
                IndestructibleBlock leftGameBorder = new IndestructibleBlock(new MatrixCoords(ii, 0));
                IndestructibleBlock rightGameBorder = new IndestructibleBlock(new MatrixCoords(ii, WorldCols - 1));
                engine.AddObject(leftGameBorder);
                engine.AddObject(rightGameBorder);
            }
            for (int ii = 0; ii < WorldCols; ii++)
            {
                IndestructibleBlock topBorder = new IndestructibleBlock(new MatrixCoords(0, ii));
                engine.AddObject(topBorder);
            }
            /*Exercise 5*/
            TrailObject trail = new TrailObject(new MatrixCoords(6, 8), new char[,] { { '+' } }, 20);
            engine.AddObject(trail);
        }

        static void Main(string[] args)
        {

            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard, 150);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);


            //

            gameEngine.Run();
        }
    }
}
