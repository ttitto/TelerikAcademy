using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ResidentialManager
{
    /// <summary>
    /// Interaction logic for InhabitantWindow.xaml
    /// </summary>
    public partial class InhabitantWindow : Window
    {
        private IEnumerable<Inhabitant> inhabitants = Commonhold.GetInhabitants();
        private List<Inhabitant>inhabitantsList;
        private Inhabitant inhabitantToDelete;
        private Inhabitant inhabitantToEdit;
        Regex namesCheck = new Regex("^[а-яА-Я]+$");
        Regex adressCheck = new Regex("^[а-яА-Я0-9,.-]+$");
        Regex telephoneCheck = new Regex("^08([0-9]{8}$)");
        private AddNewInhabitantWindow editWindow;
        private string path = System.IO.Path.GetFullPath("../../data/inhabitants.txt");
        private List<Inhabitant> inhabitantsArchiveUpdate;
        private string archivePath = System.IO.Path.GetFullPath("../../data/inhabitantsArchive.txt");

        public InhabitantWindow()
        {
            InitializeComponent();           
            this.DG.ItemsSource = inhabitants;
            inhabitantsList = inhabitants.ToList();
            IEnumerable<Inhabitant> inhabitantsArchive = Commonhold.GetInhabitantsArchive();
            inhabitantsArchiveUpdate = inhabitantsArchive.ToList();
            this.Closing += new CancelEventHandler(this.Window_Closing);
        }

        private void ButtonDeleteClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete selected inhabitant?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                inhabitantToDelete = DG.SelectedItem as Inhabitant;
                inhabitantsList.Remove(inhabitantToDelete);
                this.Close();
                MessageBox.Show("Selected inhabitant is deleted");
                var sameWindow = new InhabitantWindow();
                sameWindow.Left = this.Left;
                sameWindow.Show();
            }
        }

        private void ButtonEditClick(object sender, RoutedEventArgs e)
        {
            inhabitantToEdit = DG.SelectedItem as Inhabitant;
            editWindow = new AddNewInhabitantWindow();
            editWindow.ChangeButton.Content = "Edit";
            editWindow.ChangeButton.Click += EditButtonClick;
            editWindow.Title = "EditSelectedItem";
            editWindow.FirstName.Text = inhabitantToEdit.FirstName;
            editWindow.LastName.Text = inhabitantToEdit.LastName;
            editWindow.Address.Text = inhabitantToEdit.Address;
            editWindow.Telephone.Text = inhabitantToEdit.TelephoneNumber;
            editWindow.Pet.DataContext = inhabitantToEdit.HasPet;
            editWindow.Status.DataContext = inhabitantToEdit.Status;
            editWindow.Show();
            
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            inhabitantToEdit = DG.SelectedItem as Inhabitant;
            if (namesCheck.IsMatch(editWindow.FirstName.Text))
            {
                if (namesCheck.IsMatch(editWindow.LastName.Text))
                {
                    if (adressCheck.IsMatch(editWindow.Address.Text))
                    {
                        if (telephoneCheck.IsMatch(editWindow.Telephone.Text))
                        {
                            inhabitantToEdit.FirstName = editWindow.FirstName.Text;
                            inhabitantToEdit.LastName = editWindow.LastName.Text;
                            inhabitantToEdit.Address = editWindow.Address.Text;
                            inhabitantToEdit.TelephoneNumber = editWindow.Telephone.Text;
                            if (editWindow.Radio1.IsChecked == true)
                            {
                                inhabitantToEdit.Status = InhabitantType.Owner;
                            }
                            else
                            {
                                inhabitantToEdit.Status = InhabitantType.Tenant;
                            }
                            if (editWindow.Radio2.IsChecked == true)
                            {
                                inhabitantToEdit.HasPet = true;
                            }
                            else
                            {
                                inhabitantToEdit.HasPet = false;
                            }
                            inhabitantsArchiveUpdate.Add(new Inhabitant(inhabitantToEdit.FirstName, inhabitantToEdit.LastName, 
                                inhabitantToEdit.Status, inhabitantToEdit.Address, inhabitantToEdit.TelephoneNumber, inhabitantToEdit.HasPet));
                            this.Close();
                            MessageBox.Show("Selected inhabitant is updated");
                            var sameWindow = new InhabitantWindow();
                            sameWindow.Left = this.Left;
                            sameWindow.Show();
                        }
                    }
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            InhabitantList.WriteToFile(path, inhabitantsList);
            InhabitantList.WriteToFile(archivePath, inhabitantsArchiveUpdate);
        }

    }
}
