using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentialManager
{
    class Message : TextDocument
    {
        private string theme;
        private List<Inhabitant> senders;
        private List<Inhabitant> receivers;

/// <summary>
/// Holds the theme of the message
/// </summary>
        public string Theme
        {
            get { return this.theme; }
            set { this.theme = value; }
        }
        /// <summary>
        /// Holds a list with Inhabitants that sends the message
        /// </summary>
        public IEnumerable<Inhabitant> Senders
        {
            get { return this.senders; }
            set { this.senders = value.ToList(); }
        }
        /// <summary>
        /// Holds a list of inhabitants that the message is addressed to
        /// </summary>
        public IEnumerable<Inhabitant> Receivers
        {
            get { return this.receivers; }
            set { this.receivers = value.ToList(); }
        }

        /// <summary>
        /// Constructs a message document
        /// </summary>
        /// <param name="id">identification</param>
        /// <param name="name">name of the document</param>
        /// <param name="creationDate">date of creation of the message</param>
        /// <param name="lastChangeDate">date of the last change of the message</param>
        /// <param name="content">the content of the message</param>
        /// <param name="theme">the theme of the message</param>
        /// <param name="senders">a list of inhabitants that send the message</param>
        /// <param name="receivers">a list of inhabitants that the message is addressed to</param>
        public Message(string id, string name, DateTime creationDate, DateTime lastChangeDate, string content, string theme, IEnumerable<Inhabitant> senders, IEnumerable<Inhabitant> receivers)
            : base(id, name, creationDate, lastChangeDate, content)
        {
            this.Senders = senders;
            this.Receivers = receivers;
            this.Theme = theme;
        }
        /// <summary>
        /// Generates a string with the message's data
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
           return base.ToString() + ";," + this.Theme + ";," + InhabitantList.SerializeInhabitants(this.Senders) + ";," + InhabitantList.SerializeInhabitants(this.Receivers);
        }

    }
}
