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
    /// Interaction logic for CashierSelectWindow.xaml
    /// </summary>
    public partial class CashierSelectWindow : Window
    {
        private IEnumerable<Inhabitant> inhabitants = Commonhold.GetInhabitants();
        private string path = System.IO.Path.GetFullPath("../../data/cashiers.txt");
        private Cashier cashier;

        public CashierSelectWindow()
        {
            InitializeComponent();
            this.DG.ItemsSource = inhabitants;
        }

        private void ChooseButtonClick(object sender, RoutedEventArgs e)
        {
            if (cashier != null)
            {
                StreamWriter writer = new StreamWriter(path, false);
                using (writer)
                {
                    writer.Write(cashier.ToString());
                }
                MessageBox.Show("Касиерът е избран");
                this.Close();
            }
            else
            {
                MessageBox.Show("Изберете касиер");
            }
        }

        private void ChooseCashierButtonClick(object sender, RoutedEventArgs e)
        {
            string selectCashier = (DG.SelectedItem).ToString();
            string[] splittedCashier = selectCashier.Split();
            cashier = new Cashier(splittedCashier[0],
                        splittedCashier[1],
                       (InhabitantType)Enum.Parse(typeof(InhabitantType), splittedCashier[2]),
                        splittedCashier[3],
                        splittedCashier[4],
                       Convert.ToBoolean(splittedCashier[5]));
        }
    }
}
