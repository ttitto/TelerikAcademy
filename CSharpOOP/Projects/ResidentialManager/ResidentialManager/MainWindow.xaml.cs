using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml;
using System.Threading;
using System.Globalization;

namespace ResidentialManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Commonhold.MyCommonhold.Address = "София, Младост 4, вх.В, ап.3";
            EventArchive.LoadContent();

            //MessageBox.Show(DocArchive.MyDocArchive.Documents.ToList()[0].GetType().Name+ ";,"+DocArchive.MyDocArchive.Documents.ToList()[0].ToString());
            //DocArchive.MyDocArchive.SaveDocuments();
            TestGM(); 
        }
        #region Inhabitants Functionality

        private void ShowInhabitantsFunctionality(object sender, RoutedEventArgs e)
        {
            leftStack.Children.Clear();
            Button showAllButton = new Button();
            showAllButton.Content = "Всички ползватели";
            leftStack.Children.Add(showAllButton);
            Button showOwnersButton = new Button();
            showOwnersButton.Content = "Собственици";
            leftStack.Children.Add(showOwnersButton);
            Button showTenantsButton = new Button();
            showTenantsButton.Content = "Наематели";
            leftStack.Children.Add(showTenantsButton);
            Button chooseHouseKeeperButton = new Button();
            chooseHouseKeeperButton.Content = "Избери домоуправител";
            leftStack.Children.Add(chooseHouseKeeperButton);
            Button chooseCashierButton = new Button();
            chooseCashierButton.Content = "Избери касиер";
            leftStack.Children.Add(chooseCashierButton);
            Button chooseCommissionsParticipants = new Button();
            chooseCommissionsParticipants.Content = "Избери комисия";
            leftStack.Children.Add(chooseCommissionsParticipants);
            Button addButton = new Button();
            addButton.Content = "Добави ползвател";
            leftStack.Children.Add(addButton);
            showAllButton.Click += new RoutedEventHandler(ShowAllButtonClick);
            showOwnersButton.Click += new RoutedEventHandler(ShowAllOwnerButtonClick);
            showTenantsButton.Click += new RoutedEventHandler(ShowAllTenantButtonClick);
            chooseHouseKeeperButton.Click += new RoutedEventHandler(ChooseHouseKeeperButtonClick);
            chooseCashierButton.Click += new RoutedEventHandler(ChooseCashierButtonClick);
            chooseCommissionsParticipants.Click += new RoutedEventHandler(ChooseCommissionsParticipantsClick);
            addButton.Click += new RoutedEventHandler(AddButtonClick);
        }

        private void ShowAllButtonClick(object sender, RoutedEventArgs e)
        {
            var newInhabitantWindow = new InhabitantWindow();
            newInhabitantWindow.Show();
        }

        private void ShowAllOwnerButtonClick(object sender, RoutedEventArgs e)
        {
            var newShowOwnersWindow = new ShowOwnersWindow();
            newShowOwnersWindow.Show();
        }

        private void ShowAllTenantButtonClick(object sender, RoutedEventArgs e)
        {
            var newShowTenantsWindow = new ShowTenantsWindow();
            newShowTenantsWindow.Show();
        }

        private void ChooseHouseKeeperButtonClick(object sender, RoutedEventArgs e)
        {
            var newHouseKeeperSelectWindow = new HouseKeeperSelectWindow();
            newHouseKeeperSelectWindow.Show();
        }

        private void ChooseCashierButtonClick(object sender, RoutedEventArgs e)
        {
            var newCashierSelectWindow = new CashierSelectWindow();
            newCashierSelectWindow.Show();
        }

        private void ChooseCommissionsParticipantsClick(object sender, RoutedEventArgs e)
        {
            var newCommissionParticipantsWindow = new CommissionsParticipantsWindow();
            newCommissionParticipantsWindow.Show();
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            var newAddInhabitantWindow = new AddNewInhabitantWindow();
            newAddInhabitantWindow.Show();
        }

        #endregion

        #region Objects Functionality

        private void ShowObjectsFunctionality(object sender, RoutedEventArgs e)
        {
            leftStack.Children.Clear();
            Button showAllApartmentsButton = new Button();
            showAllApartmentsButton.Content = "Покажи всички апартаменти";
            leftStack.Children.Add(showAllApartmentsButton);
            Button showAllGaragesButton = new Button();
            showAllGaragesButton.Content = "Покажи всички гаражи";
            leftStack.Children.Add(showAllGaragesButton);
            Button showAllAccommodationsButton = new Button();
            showAllAccommodationsButton.Content = "Покажи всички помещения";
            leftStack.Children.Add(showAllAccommodationsButton);
            Button addApartmentButton = new Button();
            addApartmentButton.Content = "Добави апартамент";
            leftStack.Children.Add(addApartmentButton);
            Button addGarageButton = new Button();
            addGarageButton.Content = "Добави гараж";
            leftStack.Children.Add(addGarageButton);
            Button addAccommodationButton = new Button();
            addAccommodationButton.Content = "Добави помещение";
            leftStack.Children.Add(addAccommodationButton);

            showAllApartmentsButton.Click += new RoutedEventHandler(ShowAllApartmentsButtonClick);
            showAllAccommodationsButton.Click += new RoutedEventHandler(ShowAllAccommodationsButtonClick);
            showAllGaragesButton.Click += new RoutedEventHandler(ShowAllGaragesButtonClick);
            addApartmentButton.Click += new RoutedEventHandler(AddApartmentButtonClick);
            addGarageButton.Click += new RoutedEventHandler(AddGarageButtonClick);
            addAccommodationButton.Click += new RoutedEventHandler(AddAccommodationButtonClick);
        }

        private void ShowAllApartmentsButtonClick(object sender, RoutedEventArgs e)
        {
            var newApartmentWindow = new ApartmentWindow();
            newApartmentWindow.Show();
        }

        private void ShowAllGaragesButtonClick(object sender, RoutedEventArgs e)
        {
            var newGarageWindow = new GarageWindow();
            newGarageWindow.Show();
        }

        private void ShowAllAccommodationsButtonClick(object sender, RoutedEventArgs e)
        {
            var newAccomodationWindow = new AccommodationWindow();
            newAccomodationWindow.Show();
        }

        private void AddApartmentButtonClick(object sender, RoutedEventArgs e)
        {
            var newApartmentWindow = new AddNewApartmentWindow();
            newApartmentWindow.Show();
        }

        private void AddGarageButtonClick(object sender, RoutedEventArgs e)
        {
            var newGarageWindow = new AddNewGarageWindow();
            newGarageWindow.Show();
        }

        private void AddAccommodationButtonClick(object sender, RoutedEventArgs e)
        {
            var newAccomodationWindow = new AddNewAccommodationWindow();
            newAccomodationWindow.Show();
        }


        #endregion

        #region Events tab
        private void ShowEvents(object sender, RoutedEventArgs e)
        {
            leftStack.Children.Clear();

            Button addEventButton = new Button();
            addEventButton.Content = "Ново събитие";
            addEventButton.Click += addEventButton_Click;
            leftStack.Children.Add(addEventButton);

            Button browseEventsButton = new Button();
            browseEventsButton.Content = "Архив събития";
            browseEventsButton.Click += browseEventsButton_Click;
            leftStack.Children.Add(browseEventsButton);
        }

        void addEventButton_Click(object sender, RoutedEventArgs e)
        {
            //GeneralMeetingWindow eventWindow = new GeneralMeetingWindow("Създаване на събитие");
            //eventWindow.Show();
            EventArchive.AddEvent(new GeneralMeeting(new List<Inhabitant>(), new List<string>(new string[] {"agenda1", "agenda2"})));
        }

        void browseEventsButton_Click(object sender, RoutedEventArgs e)
        {
            EventArchiveWindow eventArchiveWindow = new EventArchiveWindow("Архив на събитията");
            eventArchiveWindow.Show();
        }

        #endregion

        #region Commonhold tab
        //dynamically generated buttons functionality
        private void ShowCommonholdFunctionality(object sender, RoutedEventArgs e)
        {
            leftStack.Children.Clear();

            Grid commonInfoGrid = new Grid();
            RowDefinition row0 = new RowDefinition();
            RowDefinition row1 = new RowDefinition();
            RowDefinition row2 = new RowDefinition();
            RowDefinition row3 = new RowDefinition();
            RowDefinition row4 = new RowDefinition();
            ColumnDefinition labels = new ColumnDefinition();
            ColumnDefinition values = new ColumnDefinition();
            ColumnDefinition buttons = new ColumnDefinition();

            commonInfoGrid.RowDefinitions.Add(row0);
            commonInfoGrid.RowDefinitions.Add(row1);
            commonInfoGrid.RowDefinitions.Add(row2);
            commonInfoGrid.RowDefinitions.Add(row3);
            commonInfoGrid.RowDefinitions.Add(row4);
            commonInfoGrid.ColumnDefinitions.Add(labels);
            commonInfoGrid.ColumnDefinitions.Add(values);
            commonInfoGrid.ColumnDefinitions.Add(buttons);

            Label lblAddress = new Label();
            lblAddress.Content = "адрес на ЕС: ";
            lblAddress.FontWeight = FontWeights.ExtraBold;
            Grid.SetColumn(lblAddress, 0);
            Grid.SetRow(lblAddress, 0);
            commonInfoGrid.Children.Add(lblAddress);

            TextBox txtAddress = new TextBox();
            txtAddress.Text = "София, Младост 1, ул. \"Баба яга\" 15";
            Grid.SetColumn(txtAddress, 1);
            Grid.SetRow(txtAddress, 0);
            commonInfoGrid.Children.Add(txtAddress);

            Label lblHouseKeeper = new Label();
            lblHouseKeeper.Content = "домоуправител: ";
            lblHouseKeeper.FontWeight = FontWeights.ExtraBold;
            Grid.SetColumn(lblHouseKeeper, 0);
            Grid.SetRow(lblHouseKeeper, 1);
            commonInfoGrid.Children.Add(lblHouseKeeper);

            TextBox txtHouseKeeper = new TextBox();
            txtHouseKeeper.Text = Commonhold.GetHouseKeeper();
            Grid.SetColumn(txtHouseKeeper, 1);
            Grid.SetRow(txtHouseKeeper, 1);
            txtHouseKeeper.IsReadOnly = true;
            commonInfoGrid.Children.Add(txtHouseKeeper);

            Label lblBoard = new Label();
            lblBoard.Content = "управителен съвет: ";
            lblBoard.FontWeight = FontWeights.ExtraBold;
            Grid.SetColumn(lblBoard, 0);
            Grid.SetRow(lblBoard, 2);
            commonInfoGrid.Children.Add(lblBoard);

            TextBox txtBoard = new TextBox();
            txtBoard.Text = Commonhold.GetAdministrativeBoard();
            Grid.SetColumn(txtBoard, 1);
            Grid.SetRow(txtBoard, 2);
            Grid.SetColumnSpan(txtBoard, 2);
            txtBoard.IsReadOnly = true;
            commonInfoGrid.Children.Add(txtBoard);

            Label lblCashier = new Label();
            lblCashier.Content = "касиер: ";
            lblCashier.FontWeight = FontWeights.ExtraBold;
            Grid.SetColumn(lblCashier, 0);
            Grid.SetRow(lblCashier, 3);
            commonInfoGrid.Children.Add(lblCashier);

            TextBox txtCashier = new TextBox();
            txtCashier.Text = Commonhold.GetCashier();
            Grid.SetColumn(txtCashier, 1);
            Grid.SetRow(txtCashier, 3);
            txtCashier.IsReadOnly = true;
            commonInfoGrid.Children.Add(txtCashier);

            Label lblSupervisor = new Label();
            lblSupervisor.Content = "контролен орган: ";
            lblSupervisor.FontWeight = FontWeights.ExtraBold;
            Grid.SetColumn(lblSupervisor, 0);
            Grid.SetRow(lblSupervisor, 4);
            commonInfoGrid.Children.Add(lblSupervisor);

            TextBox txtSupervisor = new TextBox();
            txtSupervisor.Text = Commonhold.GetSupervisors();
            Grid.SetColumn(txtSupervisor, 1);
            Grid.SetRow(txtSupervisor, 4);
            Grid.SetColumnSpan(txtSupervisor, 2);
            txtSupervisor.IsReadOnly = true;
            commonInfoGrid.Children.Add(txtSupervisor);

            leftStack.Children.Add(commonInfoGrid);

        }
        #endregion

        #region Documents tab


        private void ShowDocumentsFunctionality(object sender, RoutedEventArgs e)
        {
            leftStack.Children.Clear();

            //Separators style
            Separator mySeparator = new Separator();
            mySeparator.HorizontalAlignment = HorizontalAlignment.Center;
            mySeparator.Height = 2;
            mySeparator.BorderBrush = Brushes.Black;
            mySeparator.BorderThickness = new Thickness(50);
            mySeparator.Width = 100;

            //Labels style
            Label lblCreateDocument = new Label();
            lblCreateDocument.Content = "НОВ ДОКУМЕНТ";
            lblCreateDocument.Padding = new Thickness(0, 0, 0, 0);
            lblCreateDocument.FontSize = 12;
            lblCreateDocument.Foreground = Brushes.DarkBlue;
            lblCreateDocument.HorizontalContentAlignment = HorizontalAlignment.Center;

            Label lblSpravka = (Label)DeepCopyUIElement(lblCreateDocument);
            lblSpravka.Content = "СПРАВКИ";

            //Buttons style
            Button myProtocol = new Button();
            myProtocol.Content = "протокол";
            Button myProtocolGeneralMeeting = (Button)DeepCopyUIElement(myProtocol);
            myProtocolGeneralMeeting.Content = "протокол от общо събрание";
            Button myMessage = (Button)DeepCopyUIElement(myProtocol);
            myMessage.Content = "съобщение";

            Button myMessagePaymentRequest = (Button)DeepCopyUIElement(myProtocol);
            myMessagePaymentRequest.Content = "съобщение за плащане";
            Button myMessageGeneralMeeting = (Button)DeepCopyUIElement(myProtocol);
            myMessageGeneralMeeting.Content = "съобщение за общо събрание";
            Button myContract = (Button)DeepCopyUIElement(myProtocol);
            myContract.Content = "договор";
            Button myLegalDocument = (Button)DeepCopyUIElement(myProtocol);
            myLegalDocument.Content = "нормативен документ";
            Button myScannedDocument = (Button)DeepCopyUIElement(myProtocol); ;
            myScannedDocument.Content = "сканиран документ";
            Button myDocuments = (Button)DeepCopyUIElement(myProtocol);
            myDocuments.Content = "архив";
            myDocuments.Click += myDocuments_Click;

            //Populate leftStack
            leftStack.Children.Add(mySeparator);
            leftStack.Children.Add(lblCreateDocument);
            leftStack.Children.Add((Separator)DeepCopyUIElement(mySeparator));
            leftStack.Children.Add(myProtocol);
            myProtocol.Click += myProtocol_Click;
            leftStack.Children.Add(myProtocolGeneralMeeting);
            leftStack.Children.Add(myMessage);
            myMessage.Click += myMessage_Click;
            leftStack.Children.Add(myMessageGeneralMeeting);
            leftStack.Children.Add(myMessagePaymentRequest);
            leftStack.Children.Add(myContract);
            leftStack.Children.Add(myLegalDocument);
            leftStack.Children.Add(myScannedDocument);
            leftStack.Children.Add((Separator)DeepCopyUIElement(mySeparator));
            leftStack.Children.Add(lblSpravka);
            leftStack.Children.Add((Separator)DeepCopyUIElement(mySeparator));
            leftStack.Children.Add(myDocuments);
        }

        void myDocuments_Click(object sender, RoutedEventArgs e)
        {
            if (!IsWindowOpen<DocumentsViewerWindow>("myDocumentsViewerWindow"))
            {
                var myDocumentsViewer = new DocumentsViewerWindow();
                myDocumentsViewer.Show();
            }
        }

        //dynamically generated buttons functionality
        private void myMessage_Click(object sender, RoutedEventArgs e)
        {
            if (!IsWindowOpen<MessageCreationWindow>("myMessageCreationWindow"))
            {
                var myMessageCreationWindow = new MessageCreationWindow();
                myMessageCreationWindow.Show();
            }
            //TODO:

        }

        private void myProtocol_Click(object sender, RoutedEventArgs e)
        {
            if (!IsWindowOpen<ProtocolCreationWindow>("myProtocolCreationWindow"))
            {
                var myProtocolCreationWindow = new ProtocolCreationWindow();
                myProtocolCreationWindow.Show();
            }

        }
        #endregion

        #region Helper methods

        /// <summary>
        /// Creates a deep copy of an UIElement to avoid repetitive initialization of identic properties
        /// </summary>
        /// <param name="myElement">an UIElement that will be copied</param>
        /// <returns>Returns a copy of the UIElement that has another reference in the memory</returns>
        public UIElement DeepCopyUIElement(UIElement myElement)
        {
            var xaml = XamlWriter.Save(myElement);
            var xamlString = new StringReader(xaml);
            var xmlTextReader = new XmlTextReader(xamlString);
            var deepCopyUIElement = (UIElement)XamlReader.Load(xmlTextReader);
            return deepCopyUIElement;
        }
        /// <summary>
        /// Checks if a window of a Window child class with a given title is already open
        /// </summary>
        /// <typeparam name="T">type of the Window class child</typeparam>
        /// <param name="name">the Name of the window</param>
        /// <returns></returns>
        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
               ? Application.Current.Windows.OfType<T>().Any()
               : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }

        #endregion

        #region Testing

        // GeneralMeeting testing
        private static void TestGM()
        {
            GeneralMeeting meeting1 = new GeneralMeeting(
                Commonhold.GetInhabitants().ToList(),
                new List<string>() { "Избор на фирма за смяна на топломерите" }
            );

            GeneralMeeting meeting2 = new GeneralMeeting(
                Commonhold.GetInhabitants().ToList(),
                new List<string>() { "Гласуване за нов домоуправител" }
            );

            //archive.AddEvent(meeting1);
            //archive.AddEvent(meeting2);
            //archive.SaveContent();
            //EventArchive.LoadContent();
        }
        // End testing

        #endregion
    }
}
