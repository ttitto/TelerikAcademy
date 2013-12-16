using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Attribute
{
    [VersionAttribute(1,22)]
    class AttributeClass
    {
        static void Main(string[] args)
        {
            Object obj = new AttributeClass();
            Console.WriteLine("Version: {0}",obj.GetType().GetCustomAttributes(typeof(VersionAttribute), false)[0].ToString());
        }
    }
}
