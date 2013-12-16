using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Inhabitant
    {
        private string firstName;
        private string lastName;
        private string address;
        private string telephoneNumber;
        private bool hasPet;
        private InhabitantType status;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {         
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
            }
        }

        public string TelephoneNumber
        {
            get
            {
                return this.telephoneNumber;
            }
            set
            {
                this.telephoneNumber = value;
            }
        }

        public bool HasPet
        {
            get
            {
                return this.hasPet;
            }
            set
            {
                this.hasPet = value;
            }
        }

        public InhabitantType Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }
        public override string ToString()
        {
            return string.Format("{0} " + "{1} " + "{2} " + "{3} " + "{4} " + "{5}",
                       this.FirstName, this.LastName, this.Status, this.Address, this.TelephoneNumber, this.HasPet);
        }

        public Inhabitant(string firstName, string lastName, InhabitantType status, string address, string telephoneNumber, bool hasPet)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Status = status;
            this.Address = address;
            this.TelephoneNumber = telephoneNumber;
            this.HasPet = hasPet;
        }


    }
