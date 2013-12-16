using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.IO;

namespace ResidentialManager
{
    /// <summary>
    /// Interaction logic for AccommodationWindow.xaml
    /// </summary>
    public partial class AccommodationWindow : Window
    {
        private IEnumerable<Accommodation> accommodations = Building.GetAccommodations();
        private List<Accommodation> accommodationsList;
        private Accommodation accommodationToDelete;
        private Accommodation accommodationToEdit;
        private AddNewAccommodationWindow editWindow;
        private string path = System.IO.Path.GetFullPath("../../data/accommodations.txt");

        public AccommodationWindow()
        {
            InitializeComponent();
            this.ACW.ItemsSource = accommodations;
            accommodationsList = accommodations.ToList();
            this.Closing += new CancelEventHandler(this.Window_Closing);
        }

        private void ButtonDeleteClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete selected accommodation?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                accommodationToDelete = ACW.SelectedItem as Accommodation;
                accommodationsList.Remove(accommodationToDelete);
                this.Close();
                MessageBox.Show("Selected accommodation is deleted");
                var sameWindow = new AccommodationWindow();
                sameWindow.Left = this.Left;
                sameWindow.Show();
            }
        }

        private void ButtonEditClick(object sender, RoutedEventArgs e)
        {
            accommodationToEdit = ACW.SelectedItem as Accommodation;
            editWindow = new AddNewAccommodationWindow();
            editWindow.ChangeButton.Content = "Edit";
            editWindow.ChangeButton.Click += EditButtonClick;
            editWindow.Title = "EditSelectedItem";
            editWindow.Area.Text = accommodationToEdit.Area.ToString();
            editWindow.Floor.Text = accommodationToEdit.Floor.ToString();
            editWindow.Number.Text = accommodationToEdit.Number.ToString();
            editWindow.Width.Text = accommodationToEdit.Width.ToString();
            editWindow.Depth.Text = accommodationToEdit.Depth.ToString();
            editWindow.Show();
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            accommodationToEdit = ACW.SelectedItem as Accommodation;
            
            accommodationToEdit.Area = double.Parse(editWindow.Area.Text);
            accommodationToEdit.Floor = int.Parse(editWindow.Floor.Text);
            accommodationToEdit.Number = int.Parse(editWindow.Number.Text);
            accommodationToEdit.Width = double.Parse(editWindow.Width.Text);
            accommodationToEdit.Depth = double.Parse(editWindow.Depth.Text);
            this.Close();
            MessageBox.Show("Selected accommodation is updated");
            var sameWindow = new AccommodationWindow();
            sameWindow.Left = this.Left;
            sameWindow.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StreamWriter writer = new StreamWriter(path, false);
            using (writer)
            {
                foreach (var accommodation in accommodationsList)
                {
                    writer.Write(accommodation.ToString());
                    writer.Write(Environment.NewLine);
                }
            }
        }
    }
}
