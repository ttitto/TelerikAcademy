using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class ChickenParticle : ChaoticParticle
    {
        private uint layingInterval;
        private int cycleCounter;
        public ChickenParticle(MatrixCoords position, MatrixCoords speed, uint layingInterval)
            : base(position, speed)
        {
            this.LayingInterval = layingInterval;
            this.cycleCounter = 0;
        }
        public uint LayingInterval
        {
            get { return this.layingInterval; }
            private set { this.layingInterval = value; }
        }
        public override IEnumerable<Particle> Update()
        {
            var baseProduced = base.Update();
            List<Particle> chickenParticleProduced = new List<Particle>();
            if (this.cycleCounter == this.LayingInterval)
            {
                chickenParticleProduced.Add(new ChickenParticle(this.Position, this.Speed, this.layingInterval));
                chickenParticleProduced.AddRange(baseProduced);
                this.cycleCounter = -1;
            }
            cycleCounter++;
            return chickenParticleProduced;
        }
    }
}
