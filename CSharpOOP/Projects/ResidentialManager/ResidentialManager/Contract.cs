using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentialManager
{
    class Contract : TextDocument
    {
        private List<Inhabitant> contragentFirst;
        private List<Inhabitant> contragentSecond;
        private DateTime startingDate;
        private DateTime endingDate;
        //TODO: 
        //private List<InOutCome> relatedInOutCome;
        /// <summary>
        /// Holds the first side of the contract
        /// </summary>
        public IEnumerable<Inhabitant> ContragentFirst
        {
            get { return this.contragentFirst.AsEnumerable(); }
            set { this.contragentFirst = value.ToList(); }
        }
        /// <summary>
        /// Holds the second side of the contract
        /// </summary>
        public IEnumerable<Inhabitant> ContragentSecond
        {
            get { return this.contragentSecond.AsEnumerable(); }
            set { this.contragentSecond = value.ToList(); }
        }
        /// <summary>
        /// Holds the starting date of the validity of the contract
        /// </summary>
        public DateTime StartingDate
        {
            get { return this.startingDate; }
            set { this.startingDate = value; }
        }
        /// <summary>
        /// Holds the ending date of the validity of the contract
        /// </summary>
        public DateTime EndingDate
        {
            get { return this.endingDate; }
            set { this.endingDate = value; }
        }
        /// <summary>
        /// Constructs a contract document
        /// </summary>
        /// <param name="id">identification of the contract document</param>
        /// <param name="name">short name for the contract</param>
        /// <param name="creationDate">date of creation of the document</param>
        /// <param name="lastChangeDate">date of the last change</param>
        /// <param name="content">content of the document</param>
        /// <param name="contragentFirst">a side of the contract</param>
        /// <param name="contragentSecond">a side of the contract</param>
        /// <param name="startingDate">date of the start of the validity of the contract</param>
        /// <param name="endingDate">date of the end of the validity of the contract</param>
        public Contract(string id, string name, DateTime creationDate, DateTime lastChangeDate, string content, IEnumerable<Inhabitant> contragentFirst, IEnumerable<Inhabitant> contragentSecond, DateTime startingDate, DateTime endingDate)
            : base(id, name, creationDate, lastChangeDate, content)
        {
            this.ContragentFirst = contragentFirst;
            this.ContragentSecond = contragentSecond;
            this.StartingDate = startingDate;
            this.EndingDate = endingDate;
        }

        /// <summary>
        /// Holds a string of a contract's data
        /// </summary>
        /// <returns>a string with all the data of a contract</returns>
        public override string ToString()
        {
            return base.ToString() + ";," + InhabitantList.SerializeInhabitants(this.ContragentFirst) + ";," + InhabitantList.SerializeInhabitants(this.ContragentSecond) + ";," + this.StartingDate.ToString() + ";," + this.EndingDate.ToString();
        }
    }
}
