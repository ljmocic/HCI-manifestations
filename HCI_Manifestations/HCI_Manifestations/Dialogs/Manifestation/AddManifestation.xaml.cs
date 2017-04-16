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
                Close();
            }

        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (!Fields_Empty())
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Da li ste sigurni?", "Potvrda brisanja", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion

        private bool Fields_Empty()
        {
            if ((string.IsNullOrWhiteSpace(textBoxId.Text) && string.IsNullOrWhiteSpace(textBoxDescription.Text) && string.IsNullOrWhiteSpace(textBoxIconPath.Text) && string.IsNullOrWhiteSpace(textBoxName.Text) && string.IsNullOrWhiteSpace(textBoxPublic.Text)
                && string.IsNullOrWhiteSpace(comboBoxAlcohol.Text) && string.IsNullOrWhiteSpace(comboBoxPrices.Text) && string.IsNullOrWhiteSpace(comboBoxTypes.Text)
                ) || (checkBoxHandicapable.IsChecked == true || RadioButtonInside.IsChecked == true || RadioButtonOutside.IsChecked == true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
