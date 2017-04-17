using HCI_Manifestations.Dialogs;
using HCI_Manifestations.Models;
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

namespace HCI_Manifestations.dialogs
{
    public partial class ShowManifestations: Window, INotifyPropertyChanged
    {
        #region Attributes
        public Manifestation SelectedManifestation { get; set; }
        private ObservableCollection<Manifestation> manifestations;
        public ObservableCollection<Manifestation> Manifestations
        {
            get { return manifestations; }
            set
            {
                if (value != manifestations)
                {
                    manifestations = value;
                    OnPropertyChanged("Manifestations");
                }
            }
        }
        #endregion

        #region Constructor
        public ShowManifestations()
        {
            InitializeComponent();
            SelectedManifestation = null;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            DataContext = this;

            manifestations = new ObservableCollection<Manifestation>();
            foreach (var man in Database.getInstance().Manifestations)
            {
                Manifestations.Add(new Manifestation(man));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
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

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            var result = new ObservableCollection<Manifestation>();
                        
            if (checkBoxHandicap.IsChecked == true) {
                result = filterHandicap(manifestations);
            }
            if (checkBoxSmokingInside.IsChecked == true)
            {
                result = filterSmokingInside(result);
            }
            if (checkBoxSmokingOutside.IsChecked == true)
            {
                result = filterSmokingOutside(result);
            }
            if (!searchInputId.Text.Equals(""))
            {
                result = filterId(result);
            }
            if (!searchInputName.Text.Equals(""))
            {
                result = filterName(result);
            }

            Manifestations = result;
        }

        private ObservableCollection<Manifestation> filterHandicap(ObservableCollection<Manifestation> manifestations)
        {
            var replace = new ObservableCollection<Manifestation>();

            foreach (var data in manifestations)
            {
                if (data.Handicap == true)
                {
                    replace.Add(new Manifestation(data));
                }
            }
            return replace;
        }

        private ObservableCollection<Manifestation> filterSmokingInside(ObservableCollection<Manifestation> manifestations)
        {
            var replace = new ObservableCollection<Manifestation>();

            foreach (var data in manifestations)
            {
                if (data.SmokingInside == true)
                {
                    replace.Add(new Manifestation(data));
                }
            }
            return replace;
        }

        private ObservableCollection<Manifestation> filterSmokingOutside(ObservableCollection<Manifestation> manifestations)
        {
            var replace = new ObservableCollection<Manifestation>();

            foreach (var data in manifestations)
            {
                if (data.SmokingOutside == true)
                {
                    replace.Add(new Manifestation(data));
                }
            }
            return replace;
        }

        private ObservableCollection<Manifestation> filterId(ObservableCollection<Manifestation> manifestations)
        {
            var replace = new ObservableCollection<Manifestation>();

            foreach (var data in manifestations)
            {
                if (searchInputId.Text.Contains(data.Id))
                {
                    replace.Add(new Manifestation(data));
                }
            }
            return replace;
        }

        private ObservableCollection<Manifestation> filterName(ObservableCollection<Manifestation> manifestations)
        {
            var replace = new ObservableCollection<Manifestation>();

            foreach (var data in manifestations)
            {
                if (searchInputName.Text.Contains(data.Id))
                {
                    replace.Add(new Manifestation(data));
                }
            }
            return replace;
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
