using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
using System.Threading;
using System.Globalization;

namespace ResidentialManager
{
    public class Building : BlockObject, IMember
    {
        #region Fields

        private int yearOfBuilt;
        private MaterialTypes material;
        private IList<Inhabitant> inhabitants;
        private List<Apartment> apartments;
        private List<Accommodation> accommodations;
        private List<Garage> garages;

        #endregion

        #region Properties

        public int YearOfBuilt
        {
            get
            {
                return this.yearOfBuilt;
            }
            set
            {
                this.yearOfBuilt = value;
            }
        }
        public MaterialTypes Material
        {
            get
            {
                return this.material;
            }
            set
            {
                this.material = value;
            }
        }
        public IList<Inhabitant> Inhabitants
        {
            get
            {
                return this.inhabitants;
            }
        }
        public List<Apartment> Apartments
        {
            get
            {
                return this.apartments;
            }
        }
        public List<Accommodation> Accommodations
        {
            get
            {
                return this.accommodations;
            }
        }
        public List<Garage> Garages
        {
            get
            {
                return this.garages;
            }
        }

        #endregion

        #region Constructor

        public Building(double area, int floor, int number, int yearOfBuilt)
            : base(area, floor, number)
        {
            this.YearOfBuilt = yearOfBuilt;
            this.garages = new List<Garage>();
            this.apartments = new List<Apartment>();
            this.accommodations = new List<Accommodation>();
            this.inhabitants = new List<Inhabitant>();
        }

        #endregion

        #region Methods

        public void AddApartment(Apartment apartment)
        {
            this.apartments.Add(apartment);
        }

        public void AddGarage(Garage garage)
        {
            this.garages.Add(garage);
        }

        public void AddAccommodation(Accommodation accommodation)
        {
            this.accommodations.Add(accommodation);
        }

        public void AddMember(Inhabitant inhabitant)
        {
            this.inhabitants.Add(inhabitant);
        }

        public static IEnumerable<Apartment> GetApartments()
        {
            return GetApartments(@"..\..\data\apartments.txt");
        }

        private static IEnumerable<Apartment> GetApartments(string file)
        {
            List<Apartment> apartments = new List<Apartment>();
            //Get data from database or file
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                string[] apartmentProperties;
                while ((line = sr.ReadLine()) != null)
                {
                    apartmentProperties = line.Split(new string[] { " /" }, StringSplitOptions.RemoveEmptyEntries);

                    apartments.Add(new Apartment(
                        double.Parse(apartmentProperties[0]),
                        int.Parse(apartmentProperties[1]),
                        int.Parse(apartmentProperties[2]),
                        int.Parse(apartmentProperties[3])
                        ));
                }
            }

            return apartments as IEnumerable<Apartment>;
        }

        public static IEnumerable<Garage> GetGarages()
        {
            return GetGarages(@"..\..\data\garages.txt");
        }

        private static IEnumerable<Garage> GetGarages(string file)
        {
            List<Garage> garages = new List<Garage>();
            //Get data from database or file
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                string[] garageProperties;
                while ((line = sr.ReadLine()) != null)
                {
                    garageProperties = line.Split(new string[] { " /" }, StringSplitOptions.RemoveEmptyEntries);

                    garages.Add(new Garage(
                        double.Parse(garageProperties[0]),
                        int.Parse(garageProperties[1]),
                        int.Parse(garageProperties[2]),
                        double.Parse(garageProperties[3]),
                        double.Parse(garageProperties[4]),
                        double.Parse(garageProperties[5]))
                        );
                }
            }

            return garages as IEnumerable<Garage>;
        }

        public static IEnumerable<Accommodation> GetAccommodations()
        {
            return GetAccommodations(@"..\..\data\accommodations.txt");
        }

        private static IEnumerable<Accommodation> GetAccommodations(string file)
        {
            List<Accommodation> accommodations = new List<Accommodation>();
            //Get data from database or file
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                string[] accommodationProperties;
                while ((line = sr.ReadLine()) != null)
                {
                    accommodationProperties = line.Split(new string[] { " /" }, StringSplitOptions.RemoveEmptyEntries);

                    accommodations.Add(new Accommodation(
                        double.Parse(accommodationProperties[0]),
                        int.Parse(accommodationProperties[1]),
                        int.Parse(accommodationProperties[2]),
                        double.Parse(accommodationProperties[3]),
                        double.Parse(accommodationProperties[4])
                        ));
                }
            }

            return accommodations as IEnumerable<Accommodation>;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(string.Format("The building is built in {0}\n", this.YearOfBuilt));
            result.Append(string.Format("Number: {0}\n", this.Number));
            result.Append(string.Format("It has {0} floors\n", this.Floor));
            result.Append(string.Format("The area is: {0}", this.Area));

            return result.ToString();
        }

        #endregion
    }
}