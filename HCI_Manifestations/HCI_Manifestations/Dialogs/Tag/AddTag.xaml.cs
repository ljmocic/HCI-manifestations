using HCI_Manifestations.Help;
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
    public partial class AddTag : Window
    {
        #region Attributes
        bool saved;
        bool hasError;
        private ManifestationTag tag;
        public ManifestationTag mTag // Tag name Overshadows Tag from .NET library
        {
            get { return tag; }
            set { tag = value; }
        }
        #endregion

        #region Constructors
        public AddTag()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            tag = new ManifestationTag();
            DataContext = tag;
            saved = false;
            hasError = false;
        }
        #endregion

        #region Event handlers
        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            tag.Color = ColorPicker.SelectedColor.ToString();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            // TODO validation later
            bool validated = true;
            if (validated)
            {
                Database.AddTag(mTag);
                saved = true;
                Close();
            }
            else
            {
                // If data is not valid
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
            if (string.IsNullOrWhiteSpace(textBoxId.Text) && string.IsNullOrWhiteSpace(mTag.Color) && string.IsNullOrWhiteSpace(textBoxDescription.Text))
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
            if(textBoxId.Text.Length > 0)
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
            else
            {
                HelpProvider.ShowHelp("Tag", this);
            }
        }
    }
}
