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
    /// Interaction logic for CommissionsParticipantsWindow.xaml
    /// </summary>
    public partial class CommissionsParticipantsWindow : Window
    {
        private IEnumerable<Inhabitant> inhabitants = Commonhold.GetInhabitants();
        private InhabitantList supervisoryCommittee = new SupervisoryCommittee();
        private InhabitantList administrativeBoard = new AdministrativeBoard();
        private string supervisorPath = System.IO.Path.GetFullPath("../../data/supervisors.txt");
        private string administrativePath = System.IO.Path.GetFullPath("../../data/administrativeBoard.txt");

        public CommissionsParticipantsWindow()
        {
            InitializeComponent();
            this.DG.ItemsSource = inhabitants;
        }

        private void ChooseSupervisoryClick(object sender, RoutedEventArgs e)
        {
            CheckBox mycheckbox = new CheckBox();
            for (int i = 0; i < DG.Items.Count; i++)
            {
                mycheckbox = DG.Columns[6].GetCellContent(DG.Items[i]) as CheckBox;
                if (mycheckbox.IsChecked == true)
                {
                    supervisoryCommittee.AddMember(DG.Items[i] as Inhabitant);
                }

            }

            if (supervisoryCommittee.MembersOfInhabitantList.Count > 0 && supervisoryCommittee.MembersOfInhabitantList.Count < 4)
            {
                StreamWriter writer = new StreamWriter(supervisorPath, false);
                using (writer)
                {
                    writer.Write(supervisoryCommittee.ToString());
                }
                MessageBox.Show("Контролния огран е избран");
                this.Close();
            }
            else
            {
                MessageBox.Show("Изберете брой на членове от 1 до 3");
            }

        }

        private void ChooseAdministrativeBoardClick(object sender, RoutedEventArgs e)
        {
            CheckBox mycheckbox = new CheckBox();
            for (int i = 0; i < DG.Items.Count; i++)
            {
                mycheckbox = DG.Columns[6].GetCellContent(DG.Items[i]) as CheckBox;
                if (mycheckbox.IsChecked == true)
                {
                    administrativeBoard.AddMember(DG.Items[i] as Inhabitant);
                }

            }

            if (administrativeBoard.MembersOfInhabitantList.Count > 0 && administrativeBoard.MembersOfInhabitantList.Count < 4)
            {
                StreamWriter writer = new StreamWriter(administrativePath , false);
                using (writer)
                {
                    writer.Write(administrativeBoard.ToString());
                }
                MessageBox.Show("Управителния съвет е избран");
                this.Close();
            }
            else
            {
                MessageBox.Show("Изберете брой на членове от 1 до 3");
            }
        }

    }
}
