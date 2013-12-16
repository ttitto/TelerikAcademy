using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class TrailObject : GameObject
    {
        uint lifetime;
        /// <summary>
        /// Constructs a trail object with a given body and lifetime
        /// </summary>
        /// <param name="topLeft">the coordinates as row and column where a trail object is created</param>
        /// <param name="body">the characters that form the trail object</param>
        /// <param name="lifetime">a number of run cycles of the program</param>
        public TrailObject(MatrixCoords topLeft, char[,] body, uint lifetime)
            : base(topLeft, body)
        {
            this.lifetime = lifetime;
        }
        /// <summary>
        /// Updates the state of the trail object after each cycle runs.
        /// Decreases the lifetime until it gets zero
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
