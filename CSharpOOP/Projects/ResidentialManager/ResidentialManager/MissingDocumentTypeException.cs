using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentialManager
{
    class MissingDocumentTypeException :FormatException
    {
        public MissingDocumentTypeException()
            : base() { }
        public MissingDocumentTypeException(string message)
            :base (message)
        {

        }
        public MissingDocumentTypeException(string message, Exception inner)
            :base(message, inner)
        {

        }


    }
}
