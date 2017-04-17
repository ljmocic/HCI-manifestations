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

    public partial class AddManifestation : Window
    {

        #region Attributes
        bool saved;
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
            comboBoxTags.DataContext = Database.getInstance();

            DataContext = manifestation;

            saved = false;
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
            AddType addType = new AddType();
            addType.Show();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            // TODO validation later
            bool validated = true;
            if (validated)
            {
                manifestation.Type = Database.GetType(comboBoxTypes.Text);

                // Set the default type icon
                if (textBoxIconPath.Text == null)
                {
                    manifestation.IconPath = manifestation.Type.IconPath;
                }

                Database.AddManifestation(manifestation);
                saved = true;
                Close();
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
                MessageBoxResult messageBoxResult = MessageBox.Show("Izmene nisu sačuvane, da li želite izaći ? ", "Potvrda odustajanja", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion

        private bool Fields_Empty()
        {
            if (string.IsNullOrWhiteSpace(textBoxId.Text) &&
                string.IsNullOrWhiteSpace(textBoxDescription.Text) &&
                string.IsNullOrWhiteSpace(textBoxIconPath.Text) &&
                string.IsNullOrWhiteSpace(textBoxName.Text) &&
                string.IsNullOrWhiteSpace(textBoxPublic.Text) &&
                string.IsNullOrWhiteSpace(comboBoxAlcohol.Text) &&
                string.IsNullOrWhiteSpace(comboBoxPrices.Text) &&
                string.IsNullOrWhiteSpace(comboBoxTypes.Text) &&
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

        private void buttonAddNewTag_Click(object sender, RoutedEventArgs e)
        {
            AddTag addTag = new AddTag();
            addTag.Show();
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
            Manifestation.Type = new ManifestationType((ManifestationType)comboBoxTypes.SelectedItem);
        }

    }
}
