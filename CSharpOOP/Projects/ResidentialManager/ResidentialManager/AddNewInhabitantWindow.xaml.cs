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

namespace ResidentialManager
{
    /// <summary>
    /// Interaction logic for AddNewInhabitantWindow.xaml
    /// </summary>
    public partial class AddNewInhabitantWindow : Window
    {
        private List<Inhabitant> inhabitantToAdd;
        private List<Inhabitant> inhabitantsArchiveUpdate;
        private string path = System.IO.Path.GetFullPath("../../data/inhabitants.txt");
        private string archivePath = System.IO.Path.GetFullPath("../../data/inhabitantsArchive.txt");
        Regex namesCheck = new Regex("^[а-яА-Я]+$");
        Regex adressCheck = new Regex("^[а-яА-Я0-9,.-]+$");
        Regex telephoneCheck = new Regex("^08([0-9]{8}$)");
        MessageBoxResult result;

        public AddNewInhabitantWindow()
        {
            IEnumerable<Inhabitant> inhabitants = Commonhold.GetInhabitants();
            IEnumerable<Inhabitant> inhabitantsArchive = Commonhold.GetInhabitantsArchive();
            inhabitantToAdd = inhabitants.ToList();
            inhabitantsArchiveUpdate = inhabitantsArchive.ToList();
            this.Closing += new CancelEventHandler(this.Window_Closing);            
            InitializeComponent();
            this.ChangeButton.Content = "Add";
        }
        
        private void AddButtonClick(object sender, RoutedEventArgs e)
        {                        
            string firstName = this.FirstName.Text;
            string lastName = this.LastName.Text;
            InhabitantType status;
            if (this.Radio1.IsChecked == true)
            {
                status = InhabitantType.Owner;
            }
            else
            {
                status = InhabitantType.Tenant;
            }
            string address = this.Address.Text;
            string telephoneNumber = this.Telephone.Text;
            bool hasPet;
            if (this.Radio2.IsChecked == true)
            {
                hasPet = true;
            }
            else
            {
                hasPet = false;
            }
            if (namesCheck.IsMatch(this.FirstName.Text))
            {
                if (namesCheck.IsMatch(this.LastName.Text))
                {
                    if (adressCheck.IsMatch(this.Address.Text))
                    {
                        if (telephoneCheck.IsMatch(this.Telephone.Text))
                        {
                            if (ChangeButton.Content == "Add")
                            {
                                result = MessageBox.Show("Do you want to add new inhabitant?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                if (result == MessageBoxResult.Yes)
                                {
                                    Inhabitant newInhabitant = new Inhabitant(firstName, lastName, status, address, telephoneNumber, hasPet);
                                    this.inhabitantToAdd.Add(newInhabitant);
                                    this.inhabitantsArchiveUpdate.Add(newInhabitant);
                                    this.Close();
                                    if (ChangeButton.Content == "Add")
                                    {
                                        MessageBox.Show("Добавен е нов ползвател");
                                    }
                                }
                            }
                            else if (ChangeButton.Content == "Edit")
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
                            MessageBox.Show("Грешен телефон, формата трябва да бъде : 08xxxxxxxx");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Грешен адрес, позволените символи са: (Кирилица0-9,.-)");
                    }
                }
                else
                {
                    MessageBox.Show("Грешна фамилия, позволените символи са: (Букви на Кирилица)");
                }
            }
            else
            {
                MessageBox.Show("Грешно собствено име, позволените символи са: (Букви на Кирилица)");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            InhabitantList.WriteToFile(path, inhabitantToAdd);
            InhabitantList.WriteToFile(archivePath, inhabitantsArchiveUpdate);
        }
    }
}
