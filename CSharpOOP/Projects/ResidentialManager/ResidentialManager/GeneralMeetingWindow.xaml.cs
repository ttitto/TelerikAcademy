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
    /// Interaction logic for GeneralMeetingWindow.xaml
    /// </summary>
    public partial class GeneralMeetingWindow : Window
    {
        public GeneralMeetingWindow()
        {
            InitializeComponent();
        }

        internal GeneralMeetingWindow(GeneralMeeting eventToView)
            : this()
        {
            Conveners.ItemsSource = eventToView.Conveners;
            Attendees.ItemsSource = eventToView.Attendees;
            Agenda.ItemsSource = eventToView.Agenda;
            Votings.ItemsSource = eventToView.Votings;
        }

        public GeneralMeetingWindow(string title)
            : this()
        {
            this.Title = title;
        }

        private void ConvenersButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AttendeesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AgendaButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void VotingsButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
