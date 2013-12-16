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
    /// Interaction logic for AddNewAccommodationWindow.xaml
    /// </summary>
    public partial class AddNewAccommodationWindow : Window
    {
        private List<Accommodation> accommodationToAdd;
        private string path = System.IO.Path.GetFullPath("../../data/accommodations.txt");
        MessageBoxResult result;

        public AddNewAccommodationWindow()
        {
            IEnumerable<Accommodation> accommodations = Building.GetAccommodations();
            accommodationToAdd = accommodations.ToList();
            this.Closing += new CancelEventHandler(this.Window_Closing);
            InitializeComponent();
            this.ChangeButton.Content = "Add";
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            string area = this.Area.Text;
            string floor = this.Floor.Text;
            string number = this.Number.Text;
            string width = this.Width.Text;
            string depth = this.Depth.Text;

            if (!area.Contains('.'))
            {
                if (!width.Contains('.'))
                {
                    if (!depth.Contains('.'))
                    {
                        if (ChangeButton.Content.ToString() == "Add")
                        {
                            result = MessageBox.Show("Do you want to add new accommodation?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (result == MessageBoxResult.Yes)
                            {
                                this.accommodationToAdd.Add(new Accommodation(double.Parse(area), int.Parse(floor), int.Parse(number), double.Parse(width), double.Parse(depth)));
                                this.Close();
                                if (ChangeButton.Content.ToString() == "Add")
                                {
                                    MessageBox.Show("Добавено е ново помещение");
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
                    else
                    {
                        MessageBox.Show("Моля, въведете дълбочината със запетая");
                    }
                }
                else
                {
                    MessageBox.Show("Моля, въведете ширината със запетая");
                }
            }
            else
            {
                MessageBox.Show("Моля, въведете площта със запетая");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StreamWriter writer = new StreamWriter(path, false);
            using (writer)
            {
                foreach (var accommodation in accommodationToAdd)
                {
                    writer.Write(accommodation.ToString());
                    writer.Write(Environment.NewLine);
                }
            }
        }
    }
}
