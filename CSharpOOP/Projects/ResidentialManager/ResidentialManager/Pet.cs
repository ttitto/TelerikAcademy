using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentialManager
{
 
    struct Pet
    {
        #region Private and protected members

        private string name;
        private int years;
        private bool walk;

        #endregion Private and protected members

        #region Public properties

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public int Years
        {
            get
            {
                return this.years;
            }
        }

        public bool Walk
        {
            get
            {
                return this.walk;
            }
        }

        #endregion Public properties

        #region Class lifecycle

        public Pet(string name, int years, bool walk)
        {
            this.name = name;
            this.years = years;
            this.walk = walk;
        }

        #endregion Class lifecycle
    }
}

