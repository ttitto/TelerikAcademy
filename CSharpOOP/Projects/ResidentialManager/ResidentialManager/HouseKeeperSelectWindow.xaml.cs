using System;
using System.Collections.Generic;
using System.IO;
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

namespace ResidentialManager
{
    /// <summary>
    /// Interaction logic for HouseKeeperSelectWindow.xaml
    /// </summary>
    public partial class HouseKeeperSelectWindow : Window
    {
        private IEnumerable<Inhabitant> inhabitants = Commonhold.GetInhabitants();
        private string path = System.IO.Path.GetFullPath("../../data/houseKeepers.txt");
        private HouseKeeper houseKeeper;

        public HouseKeeperSelectWindow()
        {
            InitializeComponent();
            this.DG.ItemsSource = inhabitants;
        }

        private void ChooseButtonClick(object sender, RoutedEventArgs e)
        {
            if (houseKeeper != null)
            {
                StreamWriter writer = new StreamWriter(path, false);
                using (writer)
                {
                    writer.Write(houseKeeper.ToString());
                }
                MessageBox.Show("Домоуправителят е избран");
                this.Close();
            }
            else
            {
                MessageBox.Show("Изберете домоуправител");
            }
        }

        private void ChooseHouseKeeperButtonClick(object sender, RoutedEventArgs e)
        {
            string selectHouseKeeper = (DG.SelectedItem).ToString();
            string[] splittedHouseKeeper = selectHouseKeeper.Split();
            houseKeeper = new HouseKeeper(splittedHouseKeeper[0],
                        splittedHouseKeeper[1],
                       (InhabitantType)Enum.Parse(typeof(InhabitantType), splittedHouseKeeper[2]),
                        splittedHouseKeeper[3],
                        splittedHouseKeeper[4],
                       Convert.ToBoolean(splittedHouseKeeper[5]));
        }
    }
}
