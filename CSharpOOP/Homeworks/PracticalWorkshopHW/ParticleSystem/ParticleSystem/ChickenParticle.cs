using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class ChickenParticle:ParticleEmitter
    {
        private uint layingInterval;
        public ChickenParticle(MatrixCoords position, MatrixCoords speed,
            Random randomGenerator,
            uint maxEmittedPerTickCount, uint maxAbsSpeedCoord,
            Func<ParticleEmitter, Particle> randomParticleGeneratorMethod, uint layingInterval)
            : base(position,speed ,randomGenerator,maxEmittedPerTickCount,maxAbsSpeedCoord,randomParticleGeneratorMethod)
        {
           this.LayingInterval=layingInterval;
        }
        public uint LayingInterval
        {
            get { return this.layingInterval; }
            private set { this.layingInterval = value; }
        }
        public override IEnumerable<Particle> Update()
        {

            return base.Update();
        }
    }
}
