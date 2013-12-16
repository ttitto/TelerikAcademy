using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    /// <summary>
    /// Holds a unpassable block that rejects all kind of balls and can't be destroyed
    /// </summary>
    class UnpassableBlock : IndestructibleBlock
    {
        /// <summary>
        /// Constructs an unpassable block
        /// </summary>
        /// <param name="upperLeft">holds the coordinates of the block where it is created</param>
        public UnpassableBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0,0] = UnpassableBlock.Symbol;
        }
        /// <summary>
        /// holds the char that creates the body of the unpassable block
        /// </summary>
        public new const char Symbol = '*';
        /// <summary>
        /// Identifies the group as string to which an unpassable block is assigned to
        /// </summary>
        public new const string CollisionGroupString = "unpassableBlock";
        /// <summary>
        /// Defines the other objects that an unpassable block can collide with
        /// </summary>
        /// <returns></returns>
        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }
        /// <summary>
        /// Describes the behaviour of the unpassable block when it collides with another object
        /// </summary>
        /// <param name="collisionData">Holds data about the direction of the collision and the other
        /// objects that collide with the unpassable block</param>
        public override void RespondToCollision(CollisionData collisionData)
        {
        }
    }
}
