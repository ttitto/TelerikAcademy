using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ResidentialManager
{
    /// <summary>
    /// Interaction logic for EventArchiveWindow.xaml
    /// </summary>
    public partial class EventArchiveWindow : Window
    {
        private IEvent selectedEvent;
        private GeneralMeetingWindow editWindow;

        public EventArchiveWindow()
        {
            InitializeComponent();
            this.EventArchiveDG.ItemsSource = EventArchive.Events;
            EventArchive.OnChange += EventArchive_OnChange;
        }

        void EventArchive_OnChange(EventArgs e)
        {
            this.EventArchiveDG.ItemsSource = EventArchive.Events;
        }

        public EventArchiveWindow(string title)
            : this()
        {
            this.Title = title;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            selectedEvent = EventArchiveDG.SelectedItem as IEvent;
            editWindow = new GeneralMeetingWindow(selectedEvent as GeneralMeeting);
            editWindow.Show();

        }
    }
}
