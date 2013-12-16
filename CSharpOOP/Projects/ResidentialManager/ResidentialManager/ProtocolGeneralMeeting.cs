using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentialManager
{
    class ProtocolGeneralMeeting : Protocol
    {
        private GeneralMeeting meeting;
        /// <summary>
        /// Holds a general meeting
        /// </summary>
        public GeneralMeeting Meeting
        {
            get { return this.meeting; }
            set { this.meeting = value; }
        }
        /// <summary>
        /// Constructs a general meeting message
        /// </summary>
        /// <param name="name"></param>
        /// <param name="content"></param>
        /// <param name="id"></param>
        /// <param name="creationDate"></param>
        /// <param name="lastChangeDate"></param>
        /// <param name="protocolWriter"></param>
        /// <param name="signers"></param>
        public ProtocolGeneralMeeting(string name, string content, string id, DateTime creationDate, DateTime lastChangeDate, Inhabitant protocolWriter, IEnumerable<Inhabitant> signers)
            : base(id, name, creationDate, lastChangeDate, content, protocolWriter, signers)
        {
            this.Meeting = meeting;
            //TODO: Add data from meetings
        }
    }
}
