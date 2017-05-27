using HCI_Manifestations.dialogs;
using HCI_Manifestations.Help;
using HCI_Manifestations.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Xceed.Wpf.Toolkit;

namespace HCI_Manifestations.Dialogs
{
    public partial class EditManifestation : Window
    {
        #region Attributes
        private bool hasError;
        private string oldId;
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
            oldId = manifestationId;

            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            Manifestation = new Manifestation(Database.GetManifestation(manifestationId));
            DataContext = Manifestation;

            autoCompleteBoxTypes.DataContext = Database.getInstance();
            comboBoxTags.DataContext = Database.getInstance();

            var selectedItems = new List<ManifestationTag>();

            foreach (var tag in Manifestation.Tags)
            {
                foreach (var tagDatabase in Database.getInstance().Tags)
                {
                    if (tag.Id.Equals(tagDatabase.Id))
                    {
                        selectedItems.Add(tagDatabase);
                    }
                }
            }

            comboBoxTags.SelectedItemsOverride = selectedItems;

            foreach (var typeDatabase in Database.getInstance().Types)
            {
                if (Manifestation.Type.Id != null)
                {
                    if (Manifestation.Type.Id.Equals(typeDatabase.Id))
                    {
                        autoCompleteBoxTypes.Text = typeDatabase.Id;
                    }
                }
            }
            
            hasError = false;

        }
        #endregion
        
        #region Event handlers
        private void loadIcon_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg";
            dialog.ShowDialog();
            textBoxIconPath.Text = dialog.FileName;
        }

        private void buttonAddNewType_Click(object sender, RoutedEventArgs e)
        {
            if (Database.GetManifestation(autoCompleteBoxTypes.Text) == null)
            {
                AddType addType = new AddType(autoCompleteBoxTypes.Text);
                addType.ShowDialog();
            }
            else
            {
                AddType addType = new AddType();
                addType.ShowDialog();
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(autoCompleteBoxTypes.Text)
                || Database.GetType(autoCompleteBoxTypes.Text) == null)
            {
                System.Windows.MessageBox.Show("Odabir tipa je obavezan!");
                autoCompleteBoxTypes.Text = "";
                autoCompleteBoxTypes.Focus();
                return;
            }

            if (!hasError)
            {
                manifestation.Type = Database.GetType(autoCompleteBoxTypes.Text);

                // Set the default type icon
                if (textBoxIconPath.Text == null || string.IsNullOrWhiteSpace(textBoxIconPath.Text))
                {
                    manifestation.IconPath = manifestation.Type.IconPath;
                }

                Database.UpdateManifestation(oldId, manifestation);
                Close();
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
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Izmene nisu sačuvane, da li želite izaći?", "Potvrda odustajanja", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void buttonAddNewTag_Click(object sender, RoutedEventArgs e)
        {
            if (Database.GetManifestation(autoCompleteBoxTypes.Text) == null)
            {
                AddType addType = new AddType(autoCompleteBoxTypes.Text);
                addType.Show();
            }
            else
            {
                AddType addType = new AddType();
                addType.Show();
            }
        }

        private void comboBoxTags_ItemSelectionChanged(object sender, Xceed.Wpf.Toolkit.Primitives.ItemSelectionChangedEventArgs e)
        {
            var selectedTags = comboBoxTags.SelectedItems;
            Manifestation.Tags.Clear();

            foreach (var selectedTag in selectedTags)
            {
                Manifestation.Tags.Add(new ManifestationTag((ManifestationTag)selectedTag));
            }
        }

        private void comboBoxTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Manifestation.Type = new ManifestationType((ManifestationType)autoCompleteBoxTypes.SelectedItem);
        }
        
        private bool Fields_Empty()
        {
            if (string.IsNullOrWhiteSpace(textBoxId.Text) &&
                string.IsNullOrWhiteSpace(textBoxDescription.Text) && 
                string.IsNullOrWhiteSpace(textBoxIconPath.Text) && 
                string.IsNullOrWhiteSpace(textBoxName.Text) && 
                string.IsNullOrWhiteSpace(textBoxPublic.Text) &&
                string.IsNullOrWhiteSpace(comboBoxAlcohol.Text) &&
                string.IsNullOrWhiteSpace(comboBoxPrices.Text) && 
                string.IsNullOrWhiteSpace(autoCompleteBoxTypes.Text) &&
                checkBoxHandicap.IsChecked == false &&
                checkBoxInside.IsChecked == false &&
                checkBoxOutside.IsChecked == false)
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

        private void textBoxName_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                hasError = true;
            else
                hasError = false;

            buttonSave.IsEnabled = !hasError;
        }

        private void textBoxDescription_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                hasError = true;
            else
                hasError = false;

            buttonSave.IsEnabled = !hasError;
        }

        private bool Data_Modified()
        {
            var compareManifestation = Database.GetManifestation(Manifestation.Id);
            /*
            if (Manifestation.Name.Equals(compareManifestation.Name) &&
                Manifestation.Description.Equals(compareManifestation.Description) &&
                Manifestation.Date.Equals(compareManifestation.Date) &&
                Manifestation.Alcohol.Equals(compareManifestation.Alcohol) &&
                Manifestation.ExpectedPublic.Equals(compareManifestation.ExpectedPublic) &&
                Manifestation.Handicap == compareManifestation.Handicap &&
                Manifestation.SmokingInside == compareManifestation.SmokingInside &&
                Manifestation.SmokingOutside == compareManifestation.SmokingOutside &&
                -- TODO
                Manifestation.Tags.Equals(compareManifestation.Tags) &&
                Manifestation.Type.Id.Equals(compareManifestation.Type.Id) &&
                -- 
                Manifestation.Price.Equals(compareManifestation.Price)
                )
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

        private void autoCompleteBoxName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (Database.GetType(autoCompleteBoxTypes.Text) == null)
                {
                    buttonAddNewType_Click(null, null);
                }
            }
        }
        #endregion

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
            else
            {
                HelpProvider.ShowHelp("Manifestation", this);
            }
        }
    }
}
