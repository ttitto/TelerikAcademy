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
using System.IO;
using System.ComponentModel;
using System.Globalization;
using System.Threading;

namespace ResidentialManager
{
    /// <summary>
    /// Interaction logic for AddNewApartmentWindow.xaml
    /// </summary>
    public partial class AddNewApartmentWindow : Window
    {
        private List<Apartment> apartmentToAdd;
        private string path = System.IO.Path.GetFullPath("../../data/apartments.txt");
        MessageBoxResult result;

        public AddNewApartmentWindow()
        {
            IEnumerable<Apartment> apartments = Building.GetApartments();
            apartmentToAdd = apartments.ToList();
            this.Closing += new CancelEventHandler(this.Window_Closing);
            InitializeComponent();
            this.ChangeButton.Content = "Add";
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            string area = this.Area.Text;
            string floor = this.Floor.Text;
            string number = this.Number.Text;
            string numPeople = this.NumPeople.Text;

            if (area.Contains('.'))
            {
                MessageBox.Show("Моля, въведете площта със запетая");
            }
            else
            {
                if (ChangeButton.Content.ToString() == "Add")
                {
                    result = MessageBox.Show("Do you want to add new apartment?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        this.apartmentToAdd.Add(new Apartment(double.Parse(area), int.Parse(floor), int.Parse(number), int.Parse(numPeople)));
                        this.Close();
                        if (ChangeButton.Content.ToString() == "Add")
                        {
                            MessageBox.Show("Добавен е нов апартамент");
                        }
                    }
                }
                else if (ChangeButton.Content.ToString() == "Edit")
                {
                    result = MessageBox.Show("Do you want edit now?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        this.Close();
                    }
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StreamWriter writer = new StreamWriter(path, false);
            using (writer)
            {
                foreach (var apartment in apartmentToAdd)
                {
                    writer.Write(apartment.ToString());
                    writer.Write(Environment.NewLine);
                }
            }
        }
    }
}
