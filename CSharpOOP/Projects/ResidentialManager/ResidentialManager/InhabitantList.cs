using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentialManager
{
    public abstract class InhabitantList : IElection, IMember
    {
        public DateTime DateOfElection
        {
            get
            {
                return DateTime.Now;
            }
        }

        public IList<Inhabitant> MembersOfInhabitantList { get; protected set; }

        public InhabitantList()
        {
            this.MembersOfInhabitantList = new List<Inhabitant>();
        }

        public void AddMember(Inhabitant inhabitant)
        {
            this.MembersOfInhabitantList.Add(inhabitant);
        }

        public override string ToString()
        {
            StringBuilder print = new StringBuilder();
            foreach (var item in MembersOfInhabitantList)
            {
                print.Append(item.FirstName + " " + item.LastName);
                print.Append(Environment.NewLine);
            }
            print.Append(this.DateOfElection.ToString("dd.MM.yyyy"));

            return print.ToString();
        }

        public static void WriteToFile(string path, List<Inhabitant> inhabitants)
        {
            StreamWriter writer = new StreamWriter(path, false);
            using (writer)
            {
                foreach (var item in inhabitants)
                {
                    writer.Write(item.ToString());
                    writer.Write(Environment.NewLine);
                }
            }
        }

        /// <summary>
        /// Concatenates the first, last name and the phone number of the inhabitants in a givent list to create an unique identifier
        /// </summary>
        /// <param name="members">a list of Inhabitants</param>
        /// <returns>a string with the identifiers of the inhabitants, separated by double comma ",,"</returns>
        public static string SerializeInhabitants(IEnumerable<Inhabitant> members)
        {
            StringBuilder sb = new StringBuilder();
            int cnt = members.Count();
            int i = 1;
            members.ToList().ForEach(sndr =>
            {
                sb.Append(sndr.FirstName);
                sb.Append(sndr.LastName);
                sb.Append(sndr.TelephoneNumber);
                if (i != cnt)
                {
                    sb.Append(",,");
                }
                i++;
            });
            return sb.ToString();
        }
        /// <summary>
        /// Restores the full information for every Inhabitant in a given list having the identifiers
        /// </summary>
        /// <param name="myInhabitantIDs"> an array of the Inhabitants identifiers</param>
        /// <returns>a List with Inhabitant objects</returns>
        public static List<Inhabitant> DeserializeInhabitants(string InhabitantIDs)
        {
            List<Inhabitant> recalled = new List<Inhabitant>();
            string[] myInhabitantIDs = InhabitantIDs.Split(new string[] { ",," }, StringSplitOptions.None);
            string[] allInhabitantIDs = Commonhold.MyCommonhold.InhabitantsArchive.Select(inh => inh.FirstName + inh.LastName + inh.TelephoneNumber).ToArray();
            foreach (var item in myInhabitantIDs)
            {
                int indx = Array.IndexOf(allInhabitantIDs, item);
                if (indx >= 0 && indx < allInhabitantIDs.Count())
                {
                    recalled.Add(Commonhold.MyCommonhold.InhabitantsArchive.ToList()[indx]);
                }
            }

            return recalled;
        }
    }
}
