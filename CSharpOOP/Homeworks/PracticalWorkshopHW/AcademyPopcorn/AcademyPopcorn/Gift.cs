using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    /// <summary>
    /// Holds a gift object
    /// </summary>
    class Gift: MovingObject
    {
        /// <summary>
        /// Constructs a falling gift object
        /// </summary>
        /// <param name="topLeft">holds the coordinates as row and columnt where a gift object appears</param>
        /// <param name="body">holds the chars that participate in the body of the gift object</param>
         public Gift(MatrixCoords topLeft, char[,] body)
            : base(topLeft, body,new MatrixCoords(1,0))
        {
            this.Speed = new MatrixCoords(1,0);
        }
        /// <summary>
        /// Identifies the group as string to which a gift object is assigned 
        /// </summary>
         public new const string CollisionGroupString = "gift";
         /// <summary>
         /// Defines the other object that a gift object can collide with
         /// </summary>
         /// <param name="otherCollisionGroupString">a string identifying another object</param>
         /// <returns>true or false</returns>
         public override bool CanCollideWith(string otherCollisionGroupString)
         {
             return this.GetCollisionGroupString()=="racket";
         }
         /// <summary>
         /// Describes the behaviour of the gift object when it collides with another object
         /// </summary>
         /// <param name="collisionData">Holds data about the direction of the collision and the other
         /// objects that collide with the gift object</param>
         public override void RespondToCollision(CollisionData collisionData)
         {
             this.IsDestroyed = true;
         }
    }
}
