using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    class Tomcat : Cat
    {
        public Tomcat(string name, uint age, Sex placeHolder)
            : base(name, age, Sex.Male)
        {
        }
    }
}
