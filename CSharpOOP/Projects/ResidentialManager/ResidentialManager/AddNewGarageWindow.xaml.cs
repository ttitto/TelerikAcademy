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
    /// Interaction logic for AddNewGarageWindow.xaml
    /// </summary>
    public partial class AddNewGarageWindow : Window
    {
        private List<Garage> garageToAdd;
        private string path = System.IO.Path.GetFullPath("../../data/garages.txt");
        MessageBoxResult result;

        public AddNewGarageWindow()
        {
            IEnumerable<Garage> garages = Building.GetGarages();
            garageToAdd = garages.ToList();
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
            string height = this.Height.Text;
            string depth = this.Depth.Text;

            if (!area.Contains('.'))
            {
                if (!width.Contains('.'))
                {
                    if (!height.Contains('.'))
                    {
                        if (!depth.Contains('.'))
                        {
                            if (ChangeButton.Content.ToString() == "Add")
                            {
                                result = MessageBox.Show("Do you want to add new garage?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (result == MessageBoxResult.Yes)
                                {
                                    this.garageToAdd.Add(new Garage(double.Parse(area), int.Parse(floor), int.Parse(number), double.Parse(width),
                                        double.Parse(height), double.Parse(depth)));
                                    this.Close();
                                    if (ChangeButton.Content.ToString() == "Add")
                                    {
                                        MessageBox.Show("Добавен е нов гараж");
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
                        MessageBox.Show("Моля, въведете височината със запетая");
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
                foreach (var garage in garageToAdd)
                {
                    writer.Write(garage.ToString());
                    writer.Write(Environment.NewLine);
                }
            }
        }
    }
}
