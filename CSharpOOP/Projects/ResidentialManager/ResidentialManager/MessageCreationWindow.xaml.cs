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
using System.Collections;

namespace ResidentialManager
{
    /// <summary>
    /// Interaction logic for MessageCreationWindow.xaml
    /// </summary>
    public partial class MessageCreationWindow : Window
    {
        public MessageCreationWindow()
        {
            InitializeComponent();
            this.creationDate.Text = DateTime.Now.ToString();
            this.lastChangeDate.Text = DateTime.Now.ToString();
            lstbReceivers.ItemsSource = Commonhold.MyCommonhold.InhabitantsArchive;
            lstbSenders.ItemsSource = Commonhold.MyCommonhold.InhabitantsArchive;
        }

        private void OnBtnSaveClick(object sender, RoutedEventArgs e)
        {

            Document myMessage = new Message(this.id.Text, this.name.Text, DateTime.Parse(this.creationDate.Text),
                DateTime.Parse(this.lastChangeDate.Text), this.content.Text, this.theme.Text,
               InhabitantList.DeserializeInhabitants(this.senders.Text), InhabitantList.DeserializeInhabitants(this.receivers.Text));
            DocArchive.MyDocArchive.AddDocument(myMessage);

            //TODO: call Message's save method
        }

        private void lstbSenders_MouseEnter(object sender, MouseEventArgs e)
        {
            this.lstbSenders.Height = 150;
            this.lstbSenders.Focus();
        }

        private void lstbSenders_MouseLeave(object sender, MouseEventArgs e)
        {
            this.lstbSenders.Height = 20;

            System.Collections.IList collection = this.lstbSenders.SelectedItems;
            var mylist = collection.Cast<Inhabitant>();
            this.senders.Text = InhabitantList.SerializeInhabitants(mylist);
        }

        private void lstbReceivers_MouseEnter(object sender, MouseEventArgs e)
        {
            this.lstbReceivers.Height = 150;
            this.lstbReceivers.Focus();
        }

        private void lstbReceivers_MouseLeave(object sender, MouseEventArgs e)
        {
            this.lstbReceivers.Height = 20;
            System.Collections.IList collection = this.lstbReceivers.SelectedItems;
            var myList = collection.Cast<Inhabitant>();
            this.receivers.Text = InhabitantList.SerializeInhabitants(myList);
        }

        private void myMessageCreationWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DocArchive.MyDocArchive.SaveDocuments();
        }





    }
}
