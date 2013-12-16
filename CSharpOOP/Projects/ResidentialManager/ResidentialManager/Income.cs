using System;
using System.Collections.Generic;
using System.Collections;

namespace ResidentialManager
{
    class Income
    {
        #region Private and protected members

        private double total;
        private ArrayList over18;
        private ArrayList under18;
        private ArrayList pets;

        #endregion Private and protected members

        #region Public properties

        public double Total
        {
            get
            {
                return this.total;
            }
        }

        public ArrayList Over18
        {
            get
            {
                return this.over18;
            }
            set
            {
                this.over18 = value;
            }
        }

        public ArrayList Under18
        {
            get
            {
                return this.under18;
            }
            set
            {
                this.under18 = value;
            }
        }

        public ArrayList Pets
        {
            get
            {
                return this.pets;
            }
            set
            {
                this.pets = value;
            }
        }

        #endregion Public properties

        #region Classl ifecycle

        public Income()
        {
            this.Over18 = new ArrayList();
            this.Under18 = new ArrayList();
            this.Pets = new ArrayList();
        }

        public Income(ArrayList over18, ArrayList under18, ArrayList pets)
        {
            this.Over18 = new ArrayList();
            this.Under18 = new ArrayList();
            this.Pets = new ArrayList();

            this.over18 = over18;
            this.under18 = under18;
            this.pets = pets;
        }

        #endregion Classl ifecycle

        #region Public methods

        public double Calculate()
        {
            double result = 0.0;

            result = Over18.Count * 10;
            result += Under18.Count * 5;

            foreach (Pet p in Pets)
            {
                if (p.Walk)
                {
                    result += 2;
                }
            }

            return result;
        }

        #endregion Public methods
    }
}
