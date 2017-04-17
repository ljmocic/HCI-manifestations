using HCI_Manifestations.Dialogs;
using HCI_Manifestations.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ShowManifestations: Window
    {
        #region Attributes
        public Manifestation SelectedManifestation { get; set; }
        public ObservableCollection<Manifestation> manifestations { get; set; }
        #endregion

        #region Constructor
        public ShowManifestations()
        {
            InitializeComponent();
            SelectedManifestation = null;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            DataContext = this;
            manifestations = Database.getInstance().Manifestations;
        }
        #endregion

        #region Event handlers
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddManifestation addManifestation = new AddManifestation();
            addManifestation.Show();
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedManifestation != null)
            {
                EditManifestation editManifestation = new EditManifestation(SelectedManifestation.Id);
                editManifestation.Show();
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            Database.DeleteManifestation(SelectedManifestation);
        }

        private void manifestationsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedManifestation != null)
            {
                buttonEdit.IsEnabled = true;
                buttonDelete.IsEnabled = true;
            }
        }
        #endregion
    }
}
