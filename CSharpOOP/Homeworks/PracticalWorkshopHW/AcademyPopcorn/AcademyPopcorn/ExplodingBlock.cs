using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    /// <summary>
    /// Holds a block, that explodes when hit and destroys all the neighbor elements, except balls
    /// </summary>
    class ExplodingBlock : Block
    {
        /// <summary>
        /// Constructs and exploding block
        /// </summary>
        /// <param name="topLeft">holds the row and column coordinates of the exploding block</param>
        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
        }
        /// <summary>
        /// Describes the behaviour of the exploding block when it collides with another object
        /// </summary>
        /// <param name="collisionData">Hold data about the direction of the collision and the other
        /// objects that collide with the exploding block</param>
        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            this.ProduceObjects();
        }
        /// <summary>
        /// Produces ExplosionParticles around the Exploding block
        /// </summary>
        /// <returns>list with the produced ExplosionParticles</returns>
        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                List<GameObject> explosionParticles = new List<GameObject>();
                explosionParticles.Add(new ExplosionParticle(new MatrixCoords(this.topLeft.Row - 1, this.topLeft.Col-1), new char[,] { { '*' } }, 3));
                explosionParticles.Add(new ExplosionParticle(new MatrixCoords(this.topLeft.Row - 1, this.topLeft.Col), new char[,] { { '*' } }, 3));
                explosionParticles.Add(new ExplosionParticle(new MatrixCoords(this.topLeft.Row - 1, this.topLeft.Col+1), new char[,] { { '*' } }, 3));
                explosionParticles.Add(new ExplosionParticle(new MatrixCoords(this.topLeft.Row, this.topLeft.Col-1), new char[,] { { '*' } }, 3));
                explosionParticles.Add(new ExplosionParticle(new MatrixCoords(this.topLeft.Row, this.topLeft.Col+1), new char[,] { { '*' } }, 3));
                explosionParticles.Add(new ExplosionParticle(new MatrixCoords(this.topLeft.Row+1, this.topLeft.Col-1), new char[,] { { '*' } }, 3));
                explosionParticles.Add(new ExplosionParticle(new MatrixCoords(this.topLeft.Row+1, this.topLeft.Col), new char[,] { { '*' } }, 3));
                explosionParticles.Add(new ExplosionParticle(new MatrixCoords(this.topLeft.Row+1, this.topLeft.Col+1), new char[,] { { '*' } }, 3));
                return explosionParticles;
            }
            return new List<GameObject>().AsEnumerable();
        }

    }
}
