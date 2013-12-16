using System;
using System.Collections.Generic;

namespace ResidentialManager
{
    class _Apartment
    {
        #region Private and protected members

        private int id;
        private int numPeople;
        private int numChildren;
        private int numPets;
        private List<Payment> payments;

        #endregion Private and protected members

        #region Public properties

        public int ID
        {
            get
            {
                return this.id;
            }
        }

        public int People
        {
            get
            {
                return this.numPeople;
            }
        }

        public int Children
        {
            get
            {
                return this.numChildren;
            }
        }

        public int Pets
        {
            get
            {
                return this.numPets;
            }
        }

        public List<Payment> Payments
        {
            get
            {
                if (null == this.payments)
                {
                    this.payments = new List<Payment>();
                }

                return this.payments;
            }

            set
            {
                this.payments = value;
            }
        }

        #endregion Public properties

        #region Class lifecycle

        public _Apartment(int id, int people, int children, int pets)
        {
            this.id = id;
            this.numPeople = people;
            this.numChildren = children;
            this.numPets = pets;
        }

        #endregion Class lifecycle
    }
}
