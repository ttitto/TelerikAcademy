using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentialManager
{
    class MessageGeneralMeeting : Message
    {
        private DateTime meetingDate;
        private string meetingPlace;
        private DateTime publishmentDate;
        private List<Inhabitant> convenants;

        /// <summary>
        /// Holds the date of the meeting
        /// </summary>
        public DateTime MeetingDate
        {
            get { return this.meetingDate; }
            set { this.meetingDate = value; }
        }
        /// <summary>
        /// Holds the place of the meeting
        /// </summary>
        public string MeetingPlace
        {
            get { return this.meetingPlace; }
            set { this.meetingPlace = value; }
        }
        /// <summary>
        /// Holds the date when the message has been published
        /// </summary>
        public DateTime PublishmentDate
        {
            get { return this.publishmentDate; }
            set { this.publishmentDate = value; }
        }
        /// <summary>
        /// Holds a list of inhabitants that requested a general meeting
        /// </summary>
        public IEnumerable<Inhabitant> Convenants
        {
            get { return this.convenants; }
            set { this.convenants = value.ToList(); }
        }
        /// <summary>
        /// Constructs a general meeting message
        /// </summary>
        /// <param name="id">identification of the message</param>
        /// <param name="name"> name of the message</param>
        /// <param name="creationDate">date of creation of the message</param>
        /// <param name="lastChangeDate">date of the last change of the message</param>
        /// <param name="content">the content of the message</param>
        /// <param name="theme"> the theme of the message</param>
        /// <param name="senders">a list of inhabitants that send the message</param>
        /// <param name="receivers">a list of inhabitants that should receive the message</param>
        /// <param name="meetingPlace">the place of the meeting</param>
        /// <param name="meetingDate">the date when the meeting took place</param>
        /// <param name="publishmentDate">date when the message has been published</param>
        /// <param name="convenants">a list of inhabitants that requested a general meeting</param>
        public MessageGeneralMeeting(string id, string name, DateTime creationDate, DateTime lastChangeDate, string content,
            string theme, IEnumerable<Inhabitant> senders, IEnumerable<Inhabitant> receivers, string meetingPlace, DateTime meetingDate, DateTime publishmentDate, IEnumerable<Inhabitant> convenants)
            : base(id, name, creationDate, lastChangeDate, content, theme, senders, receivers)
        {
            this.MeetingDate = meetingDate;
            this.MeetingPlace = meetingPlace;
            this.PublishmentDate = publishmentDate;
            this.Convenants = convenants;
            this.Theme = theme;
        }

        /// <summary>
        /// Generates a string that holds the data of a message for a requested general meeting
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString()+";,"+this.MeetingPlace+";,"+this.MeetingDate.ToString()+";,"+this.PublishmentDate.ToString()+";,"+InhabitantList.SerializeInhabitants(this.Convenants);
        }
    }
}
