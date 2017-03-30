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
    /// Interaction logic for ShowManifestationTypesDialog.xaml
    /// </summary>
    public partial class ShowManifestationTypesDialog : Window
    {
        public ObservableCollection<Manifestation> manifestations
        {
            get;
            set;
        }
        public ShowManifestationTypesDialog()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.DataContext = this;
            manifestations = new ObservableCollection<Manifestation>();
            manifestations.Add(new Manifestation { Ime = "Exit Festival", Lokacija = "Novi Sad", Id = "1" });
            manifestations.Add(new Manifestation { Ime = "Sea Dance", Lokacija = "Budva", Id = "2" });
            manifestations.Add(new Manifestation { Ime = "Sea Star", Lokacija = "Omag", Id = "3" });
            manifestations.Add(new Manifestation { Ime = "Love Fest", Lokacija = "Vrnjacka Banja", Id = "4" });
            manifestations.Add(new Manifestation { Ime = "Demo Fest", Lokacija = "Banja Luka", Id = "5" });
        }
    }
}
