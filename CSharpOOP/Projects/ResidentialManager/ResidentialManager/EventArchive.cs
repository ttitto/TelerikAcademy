using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentialManager
{
    static class EventArchive
    {
        public delegate void ChangedEventHandler(EventArgs e);
        static private List<IEvent> events = new List<IEvent>();
        static public event ChangedEventHandler OnChange;

        static public IEnumerable<IEvent> Events
        {
            get { return new List<IEvent>(events); }
        }

        static public List<T> GetEvents<T>()
            where T : IEvent
        {
            List<T> result = new List<T>();
            foreach (var e in events)
            {
                if (e is T) result.Add((T)e);
            }

            return result;
        }

        static public void AddEvent(IEvent eventToAdd)
        {
            events.Add(eventToAdd);
            EventsChanged(EventArgs.Empty);
        }

        static public IEvent GetEvent(int id)
        {
            throw new NotImplementedException();
        }

        static public void SaveContent()
        {
            GeneralMeeting.SaveContent(GetEvents<GeneralMeeting>());
        }

        static public void LoadContent()
        {
            events = new List<IEvent>(GeneralMeeting.LoadContent());
            EventsChanged(EventArgs.Empty);
        }

        static private void EventsChanged(EventArgs e)
        {
            if (OnChange != null)
            {
                OnChange(e);
            }
        }
    }
}
