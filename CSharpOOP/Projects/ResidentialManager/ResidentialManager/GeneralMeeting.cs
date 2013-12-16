using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentialManager
{
    class GeneralMeeting : IEvent
    {
        #region Fields

        private DateTime time;
        private string place;
        private List<Inhabitant> conveners;
        private List<Inhabitant> attendees;
        private List<string> agenda;
        private List<Voting> votings;
        // private List<string> documents;

        #endregion

        #region Properties

        //public List<string> Documents
        //{
        //    get { return this.documents; }
        //    set { this.documents = value; }
        //}

        public List<Voting> Votings
        {
            get { return this.votings; }
            set { this.votings = value; }
        }

        public List<string> Agenda
        {
            get { return new List<string>(agenda); }
            set { this.agenda = value; }
        }

        public List<Inhabitant> Attendees
        {
            get { return this.attendees; }
            set { this.attendees = value; }
        }

        public List<Inhabitant> Conveners
        {
            get { return this.conveners; }
            set { this.conveners = value; }
        }

        public string Place
        {
            get { return this.place; }
            set { this.place = value; }
        }

        public DateTime Time
        {
            get { return this.time; }
            set { this.time = value; }
        }

        #endregion

        #region Constructors

        public GeneralMeeting(DateTime time, string place, List<Inhabitant> conveners,
            List<Inhabitant> attendees, List<string> agenda, List<Voting> votings)
            : this(time, place, conveners, agenda)
        {
            this.Attendees = attendees;
            this.Votings = votings;
        }

        public GeneralMeeting(DateTime time, string place, List<Inhabitant> conveners, List<string> agenda)
        {
            this.Time = time;
            this.Place = place;
            this.Conveners = new List<Inhabitant>(conveners);
            this.Agenda = new List<string>(agenda);
        }

        public GeneralMeeting(List<Inhabitant> conveners, List<string> agenda)
            : this(DateTime.Now, "Hallway - ground floor", conveners, agenda)
        {
        }

        public GeneralMeeting(GeneralMeeting meeting)
        {
            this.Time = meeting.Time;
            this.Place = meeting.Place;
            this.Conveners = new List<Inhabitant>(meeting.Conveners);
            this.Attendees = new List<Inhabitant>(meeting.Attendees);
            this.Agenda = new List<string>(meeting.Agenda);
            this.Votings = new List<Voting>(meeting.Votings);
        }

        #endregion

        #region Methods

        public static void SaveContent(List<GeneralMeeting> meetings, string file = @"..\..\data\generalMeetings.txt")
        {
            using (StreamWriter sw = new StreamWriter(file))
            {
                foreach (var meeting in meetings)
                {
                    StringBuilder serialized = new StringBuilder();
                    serialized.AppendFormat("{0}\t", meeting.Time);
                    serialized.AppendFormat("{0}\t", meeting.Place);
                    serialized.AppendFormat("{0}\t", SerializeInhabitantList(meeting.Conveners));
                    serialized.AppendFormat("{0}\t", SerializeInhabitantList(meeting.Attendees));
                    serialized.AppendFormat("{0}\t", SerializeAgendaList(meeting.Agenda));
                    serialized.AppendFormat("{0}", meeting.Votings);
                    sw.WriteLine(serialized);
                }
            }
        }

        public static List<GeneralMeeting> LoadContent(string file = @"..\..\data\generalMeetings.txt")
        {
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                string[] meeting;
                List<GeneralMeeting> meetings = new List<GeneralMeeting>();
                while ((line = sr.ReadLine()) != null)
                {
                    meeting = line.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);

                    switch (meeting.Length)
                    {
                        case 4:
                            meetings.Add(new GeneralMeeting(
                                DateTime.Parse(meeting[0]),
                                meeting[1],
                                DeserializeInhabitantList(meeting[2]),
                                DeserializeAgendaList(meeting[3])
                            ));
                            break;
                        case 6:
                            meetings.Add(new GeneralMeeting(
                                DateTime.Parse(meeting[0]),
                                meeting[1],
                                DeserializeInhabitantList(meeting[2]),
                                DeserializeInhabitantList(meeting[3]),
                                DeserializeAgendaList(meeting[4]),
                                new List<Voting>()
                            ));
                            break;
                        default:
                            throw new InvalidDataException("GeneralMeeting data must be formatted with 3 or 5 tabs between objects");
                    }
                }

                return meetings;
            }
        }

        public override string ToString()
        {
            return time.ToString() + " : " + place.ToString() + Environment.NewLine;
        }

        #endregion

        #region Private Methods

        private static string SerializeInhabitantList(List<Inhabitant> inhabitants)
        {
            if (inhabitants == null) return null;

            List<string> encodedInhabitants = new List<string>();
            foreach (Inhabitant inhabitant in inhabitants)
            {
                StringBuilder serialized = new StringBuilder();
                serialized.AppendFormat("{0}\t", inhabitant.FirstName);
                serialized.AppendFormat("{0}\t", inhabitant.LastName);
                serialized.AppendFormat("{0}\t", inhabitant.Status);
                serialized.AppendFormat("{0}\t", inhabitant.Address);
                serialized.AppendFormat("{0}\t", inhabitant.TelephoneNumber);
                serialized.AppendFormat("{0}", inhabitant.HasPet);
                encodedInhabitants.Add(Convert.ToBase64String(Encoding.UTF8.GetBytes(serialized.ToString())));
            }

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Join("\t", encodedInhabitants)));
        }

        private static List<Inhabitant> DeserializeInhabitantList(string inhabitantsString)
        {
            if (inhabitantsString == null) return null;
            string[] encodedInhabitants = Encoding.UTF8.GetString(Convert.FromBase64String(inhabitantsString)).Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            List<Inhabitant> inhabitants = new List<Inhabitant>();

            foreach (var encodedInhabitant in encodedInhabitants)
            {
                string[] inhabitantProperties = Encoding.UTF8.GetString(Convert.FromBase64String(encodedInhabitant)).Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                inhabitants.Add(new Inhabitant(
                    inhabitantProperties[0],
                    inhabitantProperties[1],
                    (InhabitantType)Enum.Parse(typeof(InhabitantType), inhabitantProperties[2]),
                    inhabitantProperties[3],
                    inhabitantProperties[4],
                    Boolean.Parse(inhabitantProperties[5])
                ));
            }

            return inhabitants;
        }

        private static string SerializeAgendaList(List<string> agenda)
        {
            if (agenda == null) return null;
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Join("\t", agenda)));
        }

        private static List<string> DeserializeAgendaList(string agendaString)
        {
            //byte[] barr = Convert.FromBase64String(agenda);
            //string decodedStr = Encoding.UTF8.GetString(barr);
            if (agendaString == null) return null;
            return Encoding.UTF8.GetString(Convert.FromBase64String(agendaString)).Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        #endregion

    }
}
