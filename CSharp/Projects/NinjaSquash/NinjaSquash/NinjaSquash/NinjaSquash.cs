using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaSquash
{
    class NinjaSquashClass
    {
        static void Main()
        {
            GameUI.IntroPlayer();
            GameEngine.Initialize();
            GameEngine.Run();
        }
    }
}