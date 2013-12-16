using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    /// <summary>
    /// Holds a block that can not be destructed
    /// </summary>
    public class IndestructibleBlock : Block
    {
        /// <summary>
        /// Holds the char building the body of the indestructible block
        /// </summary>
        public const char Symbol = '-';
        /// <summary>
        /// Defines the group as string where the indestuctible block is assigned to
        /// </summary>
        public new const string CollisionGroupString = "undestructibleBlock";

        /// <summary>
        /// Constructs an indestructible block
        /// </summary>
        /// <param name="upperLeft">holds the coordinates as row and column</param>
        public IndestructibleBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = IndestructibleBlock.Symbol;
        }
        /// <summary>
        /// Defines the other objects that can collide with the indestructible block
        /// </summary>
        /// <param name="otherCollisionGroupString"></param>
        /// <returns>true or false</returns>
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "ball" ;
        }
        /// <summary>
        /// Returns the collistion group string of the indestructible block
        /// </summary>
        /// <returns></returns>
        public override string GetCollisionGroupString()
        {
            return IndestructibleBlock.CollisionGroupString;
        }
        /// <summary>
        ///Defines the behaviour of the indestructible block when it collides with another object
        /// </summary>
        /// <param name="collisionData"></param>
        public override void RespondToCollision(CollisionData collisionData)
        {
        }
    }
}
