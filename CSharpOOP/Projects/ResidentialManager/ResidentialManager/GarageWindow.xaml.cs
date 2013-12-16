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

namespace ResidentialManager
{
    /// <summary>
    /// Interaction logic for GarageWindow.xaml
    /// </summary>
    public partial class GarageWindow : Window
    {
        private IEnumerable<Garage> garages = Building.GetGarages();
        private List<Garage> garagesList;
        private Garage garageToDelete;
        private Garage garageToEdit;
        private AddNewGarageWindow editWindow;
        private string path = System.IO.Path.GetFullPath("../../data/garages.txt");

        public GarageWindow()
        {
            InitializeComponent();
            this.GW.ItemsSource = garages;
            garagesList = garages.ToList();
            this.Closing += new CancelEventHandler(this.Window_Closing);
        }

        private void ButtonDeleteClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete selected garage?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                garageToDelete = GW.SelectedItem as Garage;
                garagesList.Remove(garageToDelete);
                this.Close();
                MessageBox.Show("Selected garage is deleted");
                var sameWindow = new GarageWindow();
                sameWindow.Left = this.Left;
                sameWindow.Show();
            }
        }

        private void ButtonEditClick(object sender, RoutedEventArgs e)
        {
            garageToEdit = GW.SelectedItem as Garage;
            editWindow = new AddNewGarageWindow();
            editWindow.ChangeButton.Content = "Edit";
            editWindow.ChangeButton.Click += EditButtonClick;
            editWindow.Title = "EditSelectedItem";
            editWindow.Area.Text = garageToEdit.Area.ToString();
            editWindow.Floor.Text = garageToEdit.Floor.ToString();
            editWindow.Number.Text = garageToEdit.Number.ToString();
            editWindow.Width.Text = garageToEdit.Width.ToString();
            editWindow.Height.Text = garageToEdit.Height.ToString();
            editWindow.Depth.Text = garageToEdit.Depth.ToString();
            editWindow.Show();
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            garageToEdit = GW.SelectedItem as Garage;
            
            garageToEdit.Area = double.Parse(editWindow.Area.Text);
            garageToEdit.Floor = int.Parse(editWindow.Floor.Text);
            garageToEdit.Number = int.Parse(editWindow.Number.Text);
            garageToEdit.Width = double.Parse(editWindow.Width.Text);
            garageToEdit.Height = double.Parse(editWindow.Height.Text);
            garageToEdit.Depth = double.Parse(editWindow.Depth.Text);
            this.Close();
            MessageBox.Show("Selected garage is updated");
            var sameWindow = new GarageWindow();
            sameWindow.Left = this.Left;
            sameWindow.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StreamWriter writer = new StreamWriter(path, false);
            using (writer)
            {
                foreach (var item in garagesList)
                {
                    writer.Write(item.ToString());
                    writer.Write(Environment.NewLine);
                }
            }
        }
    }
}
