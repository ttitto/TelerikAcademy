using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    /// <summary>
    /// Holds a meterorite ball
    /// </summary>
    class MeteoriteBall : Ball
    {
        /// <summary>
        /// Constructs a meteorite ball, that leaves a trail behind
        /// </summary>
        /// <param name="topLeft"></param>
        /// <param name="speed">holds the coordinates that must be added to the current coordinates of the ball
        /// This way is the direction of the movement defined.</param>
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }
     
        List<TrailObject> trailObjects = new List<TrailObject>();
        /// <summary>
        /// Holds the trail objects
        /// </summary>
        public IEnumerable<TrailObject> TrailObjects
        {
            get { return this.trailObjects.AsEnumerable<TrailObject>(); }
            set { this.trailObjects=value.ToList(); }
        }
        /// <summary>
        /// Updates the behaviour of the trail objects that are created after each run cycle
        /// Removes all the destroyed trails and adds new at the ball position
        /// </summary>
        public override void Update()
        {
            base.Update();
            trailObjects.RemoveAll(tr => tr.IsDestroyed == true);
            trailObjects.Add(new TrailObject(this.GetTopLeft(), this.body, 3));
            this.ProduceObjects();
        }
        /// <summary>
        /// Returns a list of trail objects
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<GameObject> ProduceObjects()
        {
            return this.TrailObjects;
        }
    }
}
