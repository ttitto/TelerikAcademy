using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class ParticleRepeller : ParticleAttractor
    {
        public ParticleRepeller(MatrixCoords position, MatrixCoords speed, int power, int actionRange)
            : base(position, speed, power)
        {
            this.ActionRange = actionRange;
        }


        private int actionRange;

        public int ActionRange
        {
            get { return this.actionRange; }
            set { this.actionRange = value; }
        }

        public override char[,] GetImage()
        {
            return new char[,] { { 'R' } };
        }
    }
}
