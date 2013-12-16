using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentialManager
{
    class MessagePaymentRequest : Message
    {
        private uint dueTermDays;

        //TODO: Add information about due sums grouped by periods 
        //string debtInfo;

        public uint DueTermDays
        {
            get { return this.dueTermDays; }
            set { this.dueTermDays = value; }
        }

        public MessagePaymentRequest(string id, string name, string theme, DateTime creationDate, DateTime lastChangeDate, string content, List<Inhabitant> senders,
            List<Inhabitant> receivers, uint dueTermDays )
            :base(id,name,  creationDate,lastChangeDate,content, theme,senders, receivers)
        {

        }
    }
}
