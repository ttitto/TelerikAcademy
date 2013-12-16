using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class MyEngine :Engine
    {
        public MyEngine(IRenderer renderer, IUserInterface userInterface, uint sleepTime)
            : base(renderer, userInterface, sleepTime) { }

        void ShootPlayerRacket()
        { 
        }
    }
}
