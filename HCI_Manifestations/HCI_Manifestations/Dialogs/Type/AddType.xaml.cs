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

namespace HCI_Manifestations.dialogs
{
    public partial class AddType : Window
    {

        #region Attributes
        bool saved;
        bool hasError;
        private ManifestationType type;
        public ManifestationType Type
        {
            get { return type; }
            set { type = value; }
        }
        #endregion

        #region Constructors
        public AddType()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            type = new ManifestationType();
            DataContext = type;
            saved = false;
            hasError = false;
        }

        public AddType(string id)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            type = new ManifestationType();
            type.Id = id;
            DataContext = type;
            saved = false;
            hasError = false;
        }
        #endregion

        #region Event handlers
        private void buttonBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg";
            dialog.ShowDialog();
            textBoxIconPath.Text = dialog.FileName;
            Type.IconPath = dialog.FileName;
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            // TODO validation later
            bool validated = true;
            if (validated)
            {
                Database.AddType(type);
                saved = true;
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
            if (!Fields_Empty() && !saved)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Izmene nisu sačuvane, da li želite izaći?", "Potvrda odustajanja", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion

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

        private void textBoxId_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                hasError = true;
            else
                hasError = false;

            buttonSave.IsEnabled = !hasError;
        }

        private void textBoxId_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxId.Text.Length > 0)
                buttonSave.IsEnabled = true;
            else
                buttonSave.IsEnabled = false;
        }

        private void Help_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(this);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp(str, this);
            }
        }
    }
}
