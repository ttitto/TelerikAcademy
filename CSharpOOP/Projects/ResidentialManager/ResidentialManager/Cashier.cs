using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentialManager
{
    public class Cashier : Inhabitant, IElection
    {
        public DateTime DateOfElection
        {
            get
            {
                return DateTime.Now;
            }
        }

        public Cashier(string firstName, string lastName, InhabitantType status,string address, string telephoneNumber, bool hasPet)
            : base(firstName, lastName, status, address, telephoneNumber, hasPet)
        {
        }

        public override string ToString()
        {
            return string.Format("{0} " + "{1} " + "{2}",
                       this.FirstName, this.LastName, this.DateOfElection.ToString("dd.MM.yyyy"));
        }
    }
}
