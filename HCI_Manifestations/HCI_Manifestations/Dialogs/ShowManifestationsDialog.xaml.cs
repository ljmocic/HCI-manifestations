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
    /// <summary>
    /// Interaction logic for ShowManifestationsDialog.xaml
    /// </summary>
    public partial class ShowManifestationsDialog : Window
    {
        public ObservableCollection<Manifestation> manifestations
        {
            get;
            set;
        }
        public ShowManifestationsDialog()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.DataContext = this;
            manifestations = new ObservableCollection<Manifestation>();
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            AddManifestationDialog addManifestation = new AddManifestationDialog();
            addManifestation.Show();
        }
    }
}
