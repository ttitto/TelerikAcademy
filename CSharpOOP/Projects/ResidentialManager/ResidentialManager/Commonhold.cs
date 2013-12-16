using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentialManager
{
    public sealed class Commonhold
    {
        private static volatile Commonhold myCommonhold;
        private static object syncRoot = new Object();

        private  string address;
        private  Cashier myCashier;
        private  AdministrativeBoard board;
        private  HouseKeeper keeper;
        private  SupervisoryCommittee supervisor;
        private  List<Inhabitant> inhabitants;
        private List<Inhabitant> inhabitantsArchive;
        private  List<BlockObject> commonholdObjects;
        private DocArchive commonholdDocArchive;

        /// <summary>
        /// Holds the address of the commonhold
        /// </summary>
        public  string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }
        /// <summary>
        /// Holds the cashier of the commonhold
        /// </summary>
        public  Cashier MyCashier
        {
            get { return this.myCashier; }
            set { this.myCashier = value; }
        }
        /// <summary>
        /// Holds the members of the management board of the commonhold
        /// </summary>
        public  AdministrativeBoard Board
        {
            get { return this.board; }
            set { this.board = value; }
        }
        /// <summary>
        /// Holds the housekeeper of the commonhold
        /// </summary>
        public  HouseKeeper Keeper
        {
            get { return this.keeper; }
            set { this.keeper = value; }
        }
        /// <summary>
        /// Holds the Supervisor of the commonhold
        /// </summary>
        public  SupervisoryCommittee Supervisor
        {
            get { return this.supervisor; }
            set { this.supervisor = value; }
        }
        /// <summary>
        /// Holds all current inhabitants of the commonhold
        /// </summary>
        public  IEnumerable<Inhabitant> Inhabitants
        {
            get { return this.inhabitants.AsEnumerable(); }
            set { this.inhabitants = value.ToList(); }
        }
        /// <summary>
        /// Holds all past and current inhabitants of the commonhold
        /// </summary>
        public IEnumerable<Inhabitant> InhabitantsArchive
        {
            get { return this.inhabitantsArchive.AsEnumerable(); }
            set { this.inhabitantsArchive = value.ToList(); }
        }
        /// <summary>
        /// Holds all the objects that the commonhold contains - apartments, garages, buildings etc.
        /// </summary>
        public  IEnumerable<BlockObject> CommonholdObjects
        {
            get { return this.commonholdObjects.AsEnumerable(); }
            set { this.commonholdObjects = value.ToList(); }
        }
        /// <summary>
        /// Holds the document archive of the commonhold
        /// </summary>
        public DocArchive CommonholdDocArchive
        {
            get {return this.commonholdDocArchive;}
            set { this.commonholdDocArchive = value; }
        }
        /// <summary>
        /// Creates an instance of the commonhold if none already exist
        /// </summary>
        public static Commonhold MyCommonhold
        {
            get
            {
                if (myCommonhold == null)
                {
                    lock (syncRoot)
                    {
                        if (myCommonhold == null)
                        {
                            myCommonhold = new Commonhold();
                        }
                    }
                }
                return myCommonhold;
            }
        }

        private Commonhold()
        {
            Inhabitants = GetInhabitants();
            InhabitantsArchive = GetInhabitantsArchive();
            CommonholdObjects = GetCommonholdObjects();
        }
        /// <summary>
        /// Loads the current list of inhabitants in the commonhold from a database/file
        /// </summary>
        /// <returns>a list of all current inhabitants</returns>
        public static IEnumerable<Inhabitant> GetInhabitants()
        {
            return GetInhabitants(@"..\..\data\inhabitants.txt");
        }
        /// <summary>
        /// Loads the list of all past and current inhabitants of the commonhold from a database/file
        /// </summary>
        /// <returns>a list of all past and current inhabitants</returns>
        public static IEnumerable<Inhabitant> GetInhabitantsArchive()
        {
            return GetInhabitants(@"..\..\data\inhabitantsArchive.txt");
        }
        
        private static IEnumerable<Inhabitant> GetInhabitants(string file)
        {
            List<Inhabitant> inhabitants = new List<Inhabitant>();
            //Get data from database or file
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                string[] inhabitantProperties;
                while ((line = sr.ReadLine()) != null)
                {
                    inhabitantProperties = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    inhabitants.Add(new Inhabitant(
                        inhabitantProperties[0],
                        inhabitantProperties[1],
                       (InhabitantType)Enum.Parse(typeof(InhabitantType), inhabitantProperties[2]),
                        inhabitantProperties[3],
                        inhabitantProperties[4],
                       Convert.ToBoolean(inhabitantProperties[5])
                        ));
                }
            }

            return inhabitants as IEnumerable<Inhabitant>;
        }
        /// <summary>
        /// Loads the housekeeper from a database/file
        /// </summary>
        /// <returns>a string with the Housekeeper's data</returns>
        public static string GetHouseKeeper()
        {
            return GetHouseAndCashier(@"..\..\data\houseKeepers.txt");
        }
        /// <summary>
        /// Loads the cashier from a database/file
        /// </summary>
        /// <returns>a string with the Cashier's data</returns>
        public static string GetCashier()
        {
            return GetHouseAndCashier(@"..\..\data\cashiers.txt");
        }

        private static string GetHouseAndCashier(string file)
        {
            string getInfo = String.Empty;
            //Get data from database or file
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    getInfo = line; 
                }
            }

            return getInfo;
        }
        /// <summary>
        /// Loads the Supervisor from a database/file
        /// </summary>
        /// <returns>a string with the supervisor's data</returns>
        public static string GetSupervisors()
        {
            return GetCommissions(@"..\..\data\supervisors.txt");
        }
        /// <summary>
        /// Loads the members of the administrative board from a database/file
        /// </summary>
        /// <returns></returns>
        public static string GetAdministrativeBoard()
        {
            return GetCommissions(@"..\..\data\administrativeBoard.txt");
        }

        private static string GetCommissions(string file)
        {
            StringBuilder info = new StringBuilder();
            //Get data from database or file
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    info.Append(line);
                    info.Append(", ");
                }
            }

            info.Remove(info.Length - 2, 2);

            return info.ToString();
        }

        /// <summary>
        /// Loads the current list of Objects in the commonhold from a database/file
        /// </summary>
        /// <returns>a list of all commonhold's objects with their properties</returns>
        public static IEnumerable<BlockObject> GetCommonholdObjects()
        {
            return GetCommonholdObjects(@"..\..\data\commonholdObjects.txt");
        }
        private static IEnumerable<BlockObject> GetCommonholdObjects(string file)
        {

            List<BlockObject> commonholdObjects = new List<BlockObject>();
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                string[] commonholdProperties;
                while ((line = sr.ReadLine()) != null)
                {
                    commonholdProperties = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                }


                return commonholdObjects as IEnumerable<BlockObject>;
            }
        }


    }
}