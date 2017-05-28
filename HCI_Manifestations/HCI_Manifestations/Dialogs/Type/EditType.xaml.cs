using HCI_Manifestations.Help;
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

        private string oldId;
        #endregion

        #region Constructors
        public EditType(string typeId)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            oldId = typeId;
            type = new ManifestationType(Database.GetType(typeId));
            DataContext = type;
        }
        #endregion

        #region Event handlers
        private void buttonBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png;*.jpeg,*.ico)|*.ico;*.png;*.jpeg";
            dialog.ShowDialog();
            textBoxIconPath.Text = dialog.FileName;
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            // TODO validation later
            bool validated = true;
            if (validated)
            {
                Database.UpdateType(oldId, type);
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

        private void Help_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(this);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp(str, this);
            }
            else
            {
                HelpProvider.ShowHelp("Type", this);
            }
        }
        #endregion
    }
}
