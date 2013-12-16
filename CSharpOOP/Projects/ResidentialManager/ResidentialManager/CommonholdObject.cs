using System.Collections.Generic;

namespace ResidentialManager
{
    class CommonholdObject
    {
        #region Fields

        private List<Garage> garages;
        private List<Apartment> apartments;
        private List<Building> buildings;
        private List<Accommodation> accommodations;

        #endregion

        #region Properties

        public List<Garage> Garages
        {
            get
            {
                return this.garages;
            }
            set
            {
                this.garages = value;
            }
        }
        public List<Apartment> Apartments
        {
            get
            {
                return this.apartments;
            }
            set
            {
                this.apartments = value;
            }
        }
        public List<Building> Buildings
        {
            get
            {
                return this.buildings;
            }
            set
            {
                this.buildings = value;
            }
        }
        public List<Accommodation> Accommodations
        {
            get
            {
                return this.accommodations;
            }
            set
            {
                this.accommodations = value;
            }
        }

        #endregion

        #region Constructors

        public CommonholdObject(List<Garage> garages, List<Apartment> apartments, List<Building> buildings, List<Accommodation> accommodations)
        {
            this.Garages = garages;
            this.Apartments = apartments;
            this.Buildings = buildings;
            this.Accommodations = accommodations;
        }

        #endregion
    } 
}
