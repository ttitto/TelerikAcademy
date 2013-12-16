using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    class Kitten : Cat
    {
        public Kitten(string name, uint age, Sex placeHolder)
            : base(name, age, Sex.Female)
        {
        }

    }
}
