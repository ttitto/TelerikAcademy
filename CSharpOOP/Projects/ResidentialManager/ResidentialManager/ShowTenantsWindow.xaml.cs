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

namespace ResidentialManager
{
    /// <summary>
    /// Interaction logic for ShowTenantsWindow.xaml
    /// </summary>
    public partial class ShowTenantsWindow : Window
    {
        public ShowTenantsWindow()
        {
            InitializeComponent();
            InitializeComponent();
            IEnumerable<Inhabitant> inhabitants = Commonhold.GetInhabitants();
            this.DG.ItemsSource = inhabitants.Where(inhabitantStatus => inhabitantStatus.Status == InhabitantType.Tenant);
        }
    }
}
