using HCI_Manifestations.Models;
using Microsoft.Win32;
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

namespace HCI_Manifestations.Dialogs
{
    public partial class EditType : Window
    {
        #region Attributes
        private ManifestationType type;
        public ManifestationType Type
        {
            get { return type; }
            set { type = value; }
        }
        #endregion

        #region Constructors
        public EditType(string typeId)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            type = new ManifestationType(Database.GetType(typeId));
            DataContext = type;
        }
        #endregion

        #region Event handlers
        private void buttonBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg";
            dialog.ShowDialog();
            textBoxIconPath.Text = dialog.FileName;
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            // TODO validation later
            bool validated = true;
            if (validated)
            {
                Database.UpdateType(type);
                Close();
            }
            else
            {
                // If data is not validated
            }
        }
        
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (!Fields_Empty() && Data_Modified())
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Izmene nisu sačuvane, da li želite izaći?", "Potvrda odustajanja", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private bool Fields_Empty()
        {
            if (string.IsNullOrWhiteSpace(textBoxId.Text) && string.IsNullOrWhiteSpace(textBoxName.Text) && string.IsNullOrWhiteSpace(textBoxDescription.Text) && string.IsNullOrWhiteSpace(textBoxIconPath.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Data_Modified()
        {
            // TODO
            /*
            var compareType = Database.GetType(type.Id);
            if (Type.Description.Equals(compareType.Description) && Type.IconPath.Equals(compareType.IconPath) && Type.Name.Equals(compareType.Name))
            {
                return false;
            }
            else
            {
                return true;
            }
            */
            return false;
        }
        #endregion
    }
}
