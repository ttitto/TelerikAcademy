using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    /// <summary>
    /// Holds a ball that doesn't reflect from most of the objects
    /// </summary>
    class UnstoppableBall : Ball
    {
        /// <summary>
        /// Constructs an unstoppable with given coordinates and movement direction
        /// </summary>
        /// <param name="topLeft"></param>
        /// <param name="speed"></param>
        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }
        /// <summary>
        /// identifies the group as string to which the unstoppable ball is assigned to
        /// </summary>
        public new const string CollisionGroupString = "unstoppableBall";
        /// <summary>
        /// Defines the other objects that an unstoppable ball can collide with
        /// </summary>
        /// <returns></returns>
        public override string GetCollisionGroupString()
        {
            return UnstoppableBall.CollisionGroupString;
        }
        /// <summary>
        /// Defines the object groups which objects an unstoppable ball can collide with
        /// </summary>
        /// <param name="otherCollisionGroupString"></param>
        /// <returns></returns>
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" || otherCollisionGroupString == "undestructibleBlock"
                || otherCollisionGroupString == "unpassableBlock" || otherCollisionGroupString == "block";
        }
        /// <summary>
        /// Defines the behaviour of the unstoppable ball when it collides with another object.
        /// </summary>
        /// <param name="collisionData"></param>
        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.hitObjectsCollisionGroupStrings.Contains("block"))
            {
                if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0)
                {
                    this.TopLeft.Col++;
                }
                if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0)
                {
                    this.TopLeft.Row++;
                }
            }
            else base.RespondToCollision(collisionData);
            
        }

    }

}
