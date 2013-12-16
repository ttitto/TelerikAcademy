using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    /// <summary>
    /// Holds a block that drops gifts when it is destroyed
    /// </summary>
    class GiftBlock : Block
    {
        /// <summary>
        /// Constructs a gift block at a given place
        /// </summary>
        /// <param name="topLeft">Holds the coordinates as row and column where a gift block is created</param>
        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
        }
        /// <summary>
        /// Describes the behaviour of the gift block when it collides with another object
        /// </summary>
        /// <param name="collisionData">Hold data about the direction of the collision and the other
        /// objects that collide with the Gift block</param>
        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            this.ProduceObjects();
        }
        /// <summary>
        /// Produces gift objects when destroyed
        /// </summary>
        /// <returns>a list of gifts or empty list</returns>
        public override IEnumerable<GameObject> ProduceObjects()
        {
            if(this.IsDestroyed)
            {
            List<Gift> myGift = new List<Gift>();
            myGift.Add(new Gift(this.TopLeft, new char[,] { { '$' } }));
            return myGift.AsEnumerable<Gift>();
            }
            else return new List<Gift>();
        }
    }
}
