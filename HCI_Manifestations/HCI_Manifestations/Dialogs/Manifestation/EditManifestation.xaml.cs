using HCI_Manifestations.dialogs;
using HCI_Manifestations.Models;
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

namespace HCI_Manifestations.Dialogs
{
    public partial class EditManifestation : Window
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
        public EditManifestation(string manifestationId)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            manifestation = Database.GetManifestation(manifestationId);
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
                Database.UpdateManifestation(manifestation);
                Close();
            }
            else
            {
                // If data is not validated
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
