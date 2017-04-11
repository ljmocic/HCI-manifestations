using HCI_Manifestations.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace HCI_Manifestations.dialogs
{

    public partial class AddManifestation : Window
    {

        #region Attributes
        private Manifestation manifestation;
        public Manifestation Manifestation
        {
            get { return manifestation; }
            set { manifestation = value; }
        }
        #endregion

        #region Constructors
        public AddManifestation()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            manifestation = new Manifestation();
            comboBoxTypes.DataContext = Database.getInstance();
            DataContext = manifestation;
            
        }
        #endregion

        #region Event handlers
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            // TODO validation later
            bool validated = true;
            if (validated)
            {
                manifestation.Type = Database.GetType(comboBoxTypes.Text);
                Database.AddManifestation(manifestation);
                Close();
            }
            
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            // TODO warn user about losing data
            Close();
        }

        private void loadIcon_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.ShowDialog();
            textBoxIconPath.Text = dialog.FileName;
            // TODO add copying icon to resources and updating path to local resource
        }

        private void buttonAddNewType_Click(object sender, RoutedEventArgs e)
        {
            AddType addType = new AddType();
            addType.Show();
        }
        #endregion
    }
}
