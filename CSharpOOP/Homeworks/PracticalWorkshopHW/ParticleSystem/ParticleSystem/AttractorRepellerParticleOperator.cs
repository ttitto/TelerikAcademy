using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class AttractorRepellerParticleOperator : AdvancedParticleOperator
    {
        private List<ParticleRepeller> repellers = new List<ParticleRepeller>();
        private List<Particle> otherParticles = new List<Particle>();
        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var repellerCandidate = p as ParticleRepeller;
            if (repellerCandidate == null)
            {
                this.otherParticles.Add(p);
            }
            else
            {
                this.repellers.Add(repellerCandidate);
            }

            return base.OperateOn(p);
        }
        public override void TickEnded()
        {
            foreach (var repeller in this.repellers)
            {
                foreach (var particle in otherParticles)
                {
                    int euclidDistance = (int)Math.Sqrt((repeller.Position.Row - particle.Position.Row) * (repeller.Position.Row - particle.Position.Row) + (repeller.Position.Col - particle.Position.Col) * (repeller.Position.Col - particle.Position.Col));

                    if (euclidDistance < repeller.ActionRange)
                    {
                        var currAcceleration = GetAccelerationFromParticleToAttractor(repeller, particle);
                        particle.Accelerate(currAcceleration);
                    }

                }
            }
            base.TickEnded();
        }

        private static MatrixCoords GetAccelerationFromParticleToAttractor(ParticleRepeller repeller, Particle particle)
        {
            var currParticleToRepellerVector = repeller.Position - particle.Position;

            int pToAttrRow = currParticleToRepellerVector.Row;
            pToAttrRow = DecreaseVectorCoordToPower(repeller, pToAttrRow);

            int pToAttrCol = currParticleToRepellerVector.Col;
            pToAttrCol = DecreaseVectorCoordToPower(repeller, pToAttrCol);

            var currAcceleration = new MatrixCoords(-pToAttrRow, -pToAttrCol);
            return currAcceleration;
        }

        private static int DecreaseVectorCoordToPower(ParticleRepeller repeller, int pToAttrCoord)
        {
            if (Math.Abs(pToAttrCoord) > repeller.Power)
            {
                pToAttrCoord = (pToAttrCoord / (int)Math.Abs(pToAttrCoord)) * repeller.Power;
            }
            return pToAttrCoord;
        }

    }
}
