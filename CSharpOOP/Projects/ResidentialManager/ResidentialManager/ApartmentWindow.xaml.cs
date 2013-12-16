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
    /// Interaction logic for ApartmentWindow.xaml
    /// </summary>
    public partial class ApartmentWindow : Window
    {
        private IEnumerable<Apartment> apartments = Building.GetApartments();
        private List<Apartment> apartmentsList;
        private Apartment apartmentToDelete;
        private Apartment apartmentToEdit;
        private AddNewApartmentWindow editWindow;
        private string path = System.IO.Path.GetFullPath("../../data/apartments.txt");

        public ApartmentWindow()
        {
            InitializeComponent();
            this.AW.ItemsSource = apartments;
            apartmentsList = apartments.ToList();
            this.Closing += new CancelEventHandler(this.Window_Closing);
        }

        private void ButtonDeleteClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete selected apartment?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                apartmentToDelete = AW.SelectedItem as Apartment;
                apartmentsList.Remove(apartmentToDelete);
                this.Close();
                MessageBox.Show("Selected apartment is deleted");
                var sameWindow = new ApartmentWindow();
                sameWindow.Left = this.Left;
                sameWindow.Show();
            }
        }

        private void ButtonEditClick(object sender, RoutedEventArgs e)
        {
            apartmentToEdit = AW.SelectedItem as Apartment;
            editWindow = new AddNewApartmentWindow();
            editWindow.ChangeButton.Content = "Edit";
            editWindow.ChangeButton.Click += EditButtonClick;
            editWindow.Title = "EditSelectedItem";
            editWindow.Area.Text = apartmentToEdit.Area.ToString();
            editWindow.Floor.Text = apartmentToEdit.Floor.ToString();
            editWindow.Number.Text = apartmentToEdit.Number.ToString();
            editWindow.NumPeople.Text = apartmentToEdit.NumPeople.ToString();
            editWindow.Show();

        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            apartmentToEdit = AW.SelectedItem as Apartment;
            
            apartmentToEdit.Area = double.Parse(editWindow.Area.Text);
            apartmentToEdit.Floor = int.Parse(editWindow.Floor.Text);
            apartmentToEdit.Number = int.Parse(editWindow.Number.Text);
            apartmentToEdit.NumPeople = int.Parse(editWindow.NumPeople.Text);
            this.Close();
            MessageBox.Show("Selected apartment is updated");
            var sameWindow = new ApartmentWindow();
            sameWindow.Left = this.Left;
            sameWindow.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StreamWriter writer = new StreamWriter(path, false);
            using (writer)
            {
                foreach (var item in apartmentsList)
                {
                    writer.Write(item.ToString());
                    writer.Write(Environment.NewLine);
                }
            }
        }
    }
}
