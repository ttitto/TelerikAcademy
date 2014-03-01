using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class ChaoticParticle : Particle
    {
        public ChaoticParticle(MatrixCoords position, MatrixCoords speed)
            : base(position, speed)
        { }
        private Random rnd = new Random();
        protected override void Move()
        {
            base.Move();
            this.Accelerate(new MatrixCoords(rnd.Next(-1, 2), rnd.Next(-1, 2)));
        }
        public override char[,] GetImage()
        {
            return new char[,] { { '#' } };
        }

    }
}
