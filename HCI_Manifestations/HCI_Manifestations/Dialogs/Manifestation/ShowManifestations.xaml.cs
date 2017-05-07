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
            
            comboBoxType.DataContext = Database.getInstance();

            Manifestations = Database.getInstance().Manifestations;
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
        
        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            Manifestations = Database.getInstance().Manifestations;

            searchInputId.Text = "";
            searchInputName.Text = "";
            comboBoxAlcohol.SelectedIndex = 3;
            comboBoxPrice.SelectedIndex = 4;
            comboBoxType.SelectedValue = null;
            checkBoxHandicap.IsChecked = false;
            checkBoxSmokingInside.IsChecked = false;
            checkBoxSmokingOutside.IsChecked = false;
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            var result = new ObservableCollection<Manifestation>();
            result = Database.getInstance().Manifestations;
            if (checkBoxHandicap.IsChecked == true)
            {
                result = filterHandicap(result, true);
            }
            if (checkBoxSmokingInside.IsChecked == true)
            {
                result = filterSmokingInside(result, true);
            }
            if (checkBoxSmokingOutside.IsChecked == true)
            {
                result = filterSmokingOutside(result, true);
            }
            if (checkBoxSmokingOutside.IsChecked == true)
            {
                result = filterSmokingOutside(result, true);
            }
            if (!searchInputId.Text.Equals(""))
            {
                result = filterId(result, true);
            }
            if (!searchInputName.Text.Equals(""))
            {
                result = filterName(result, true);
            }
            if (!comboBoxAlcohol.Text.Equals("Sve"))
            {
                result = filterAlcohol(result);
            }
            if (!comboBoxPrice.Text.Equals("Sve"))
            {
                result = filterPrice(result);
            }
            if (!string.IsNullOrEmpty(comboBoxType.Text))
            {
                result = filterType(result);
            }

            Manifestations = result;
        }
        #endregion

        #region Filters
        private ObservableCollection<Manifestation> filterHandicap(ObservableCollection<Manifestation> manifestations, bool value)
        {
            var replace = new ObservableCollection<Manifestation>();

            foreach (var data in manifestations)
            {
                if (data.Handicap == value)
                {
                    replace.Add(new Manifestation(data));
                }
            }
            return replace;
        }

        private ObservableCollection<Manifestation> filterSmokingInside(ObservableCollection<Manifestation> manifestations, bool value)
        {
            var replace = new ObservableCollection<Manifestation>();

            foreach (var data in manifestations)
            {
                if (data.SmokingInside == value)
                {
                    replace.Add(new Manifestation(data));
                }
            }
            return replace;
        }

        private ObservableCollection<Manifestation> filterSmokingOutside(ObservableCollection<Manifestation> manifestations, bool value)
        {
            var replace = new ObservableCollection<Manifestation>();

            foreach (var data in manifestations)
            {
                if (data.SmokingOutside == value)
                {
                    replace.Add(new Manifestation(data));
                }
            }
            return replace;
        }

        private ObservableCollection<Manifestation> filterId(ObservableCollection<Manifestation> manifestations, bool value)
        {
            var replace = new ObservableCollection<Manifestation>();

            foreach (var data in manifestations)
            {
                if (data.Id.Contains(searchInputId.Text) && value == true)
                {
                    replace.Add(new Manifestation(data));
                }
                if (!data.Id.Contains(searchInputId.Text) && value == false)
                {
                    replace.Add(new Manifestation(data));
                }
            }
            return replace;
        }

        private ObservableCollection<Manifestation> filterName(ObservableCollection<Manifestation> manifestations, bool value)
        {
            var replace = new ObservableCollection<Manifestation>();

            foreach (var data in manifestations)
            {
                if (data.Name.Contains(searchInputName.Text) && value == true)
                {
                    replace.Add(new Manifestation(data));
                }
                else if (!data.Name.Contains(searchInputName.Text) && value == false)
                {
                    replace.Add(new Manifestation(data));
                }
            }
            return replace;
        }

        private ObservableCollection<Manifestation> filterAlcohol(ObservableCollection<Manifestation> manifestations)
        {
            var replace = new ObservableCollection<Manifestation>();

            foreach (var data in manifestations)
            {
                if (data.Alcohol.Equals(comboBoxAlcohol.Text))
                {
                    replace.Add(new Manifestation(data));
                }
            }
            return replace;
        }

        private ObservableCollection<Manifestation> filterPrice(ObservableCollection<Manifestation> manifestations)
        {
            var replace = new ObservableCollection<Manifestation>();

            foreach (var data in manifestations)
            {
                if (data.Price.Equals(comboBoxPrice.Text))
                {
                    replace.Add(new Manifestation(data));
                }
            }
            return replace;
        }

        private ObservableCollection<Manifestation> filterType(ObservableCollection<Manifestation> manifestations)
        {
            var replace = new ObservableCollection<Manifestation>();

            foreach (var data in manifestations)
            {
                if (data.Type.Id.Equals(comboBoxType.Text))
                {
                    replace.Add(new Manifestation(data));
                }
            }
            return replace;
        }
        #endregion

        #region PropertyChangedNotifier
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        private void searchInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                buttonSearch_Click(null, null);
            }
        }
    }
}
