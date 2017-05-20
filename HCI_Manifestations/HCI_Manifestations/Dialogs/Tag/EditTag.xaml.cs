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

namespace HCI_Manifestations.Dialogs
{
    public partial class EditTag : Window
    {
        #region Attributes
        private string oldId;
        private ManifestationTag tag;
        public ManifestationTag mTag
        {
            get { return tag; }
            set { tag = value; }
        }
        #endregion

        #region Constructors
        public EditTag(string tagId)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            oldId = tagId;

            tag = new ManifestationTag(Database.GetTag(tagId));
            if(tag.Color != null)
                ColorPicker.SelectedColor = (Color)ColorConverter.ConvertFromString(tag.Color);
            DataContext = tag;
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
                Database.UpdateTag(oldId, mTag);
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
            if (!Fields_Empty() && Data_Modified())
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Izmene nisu sačuvane, da li želite izaći?", "Potvrda odustajanja", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        
        private void AreYouSureCheck()
        {
            if (!Fields_Empty() && Data_Modified())
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Da li ste sigurni?", "Potvrda brisanja", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    Close();
                }
            }
        }

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

        private bool Data_Modified()
        {
            /*
            var compareTag = Database.GetTag(tag.Id);
            if (tag.Description.Equals(compareTag.Description) && tag.Color.Equals(compareTag.Color))
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
                HelpProvider.ShowHelp(GetType().Name, this);
            }
        }
    }
}
