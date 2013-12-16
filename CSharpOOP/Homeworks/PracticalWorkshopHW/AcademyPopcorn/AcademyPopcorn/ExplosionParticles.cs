using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    /// <summary>
    /// Holds information about the particles that are created after an Exploding block is destroyed
    /// </summary>
    class ExplosionParticle :MovingObject
    {
         uint lifetime;
        /// <summary>
        /// Constructs an explosion particle
        /// </summary>
        /// <param name="topLeft">holds the coordinates as row and column of the explosion particle</param>
        /// <param name="body">holds the chars that build the body of the explosion particles</param>
        /// <param name="lifetime">hold the count of the game cycles after which the explosion particles get destroyed</param>
         public ExplosionParticle(MatrixCoords topLeft, char[,] body, uint lifetime)
            : base(topLeft, body,new MatrixCoords(0,0))
        {
            this.lifetime = lifetime;
        }
        /// <summary>
        /// Defines the other object that an explosion particle can collide with
        /// </summary>
        /// <param name="otherCollisionGroupString">a string identifying another object</param>
        /// <returns>true or false</returns>
         public override bool CanCollideWith(string otherCollisionGroupString)
         {
             return otherCollisionGroupString == "block";
         }
        /// <summary>
        /// Updates the Explosion particle state after each game cycle run. 
        /// Decreases the lifetime of the explosion particle until it gets zero
        /// </summary>
        public override void Update()
        {
            if (this.lifetime == 1)
            {
                this.lifetime = 0;
                this.IsDestroyed = true;
            }
            else this.lifetime--;
        }
    }
}
