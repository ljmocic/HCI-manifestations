using HCI_Manifestations.Dialogs;
using HCI_Manifestations.Dialogs.Type;
using HCI_Manifestations.Help;
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
    public partial class ShowTypes : Window, INotifyPropertyChanged
    {
        #region Attributes
        public ManifestationType SelectedType { get; set; }
        private ObservableCollection<ManifestationType> types;
        public ObservableCollection<ManifestationType> Types
        {
            get { return types; }
            set
            {
                if (value != types)
                {
                    types = value;
                    OnPropertyChanged("Types");
                }
            }
        }
        #endregion

        #region Constructors
        public ShowTypes()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            SelectedType = null;
            DataContext = this;
            Types = Database.getInstance().Types;
        }
        #endregion

        #region Event handlers
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddType addType = new AddType();
            addType.Show();
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedType != null) {
                EditType editType = new EditType(SelectedType.Id);
                editType.Show();
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            int counter = 0;
            ObservableCollection<Manifestation> manifestations = Database.getInstance().Manifestations;
            foreach (Manifestation manifestation in manifestations)
            {
                if (manifestation.Type.Id.Equals(SelectedType.Id))
                {
                    counter++;
                }
            }

            if (counter > 0)
            {
                DeleteActionHandler handler = new DeleteActionHandler(SelectedType);
                handler.ShowDialog();
            }
            else
            {
                Database.DeleteType(SelectedType);
            }

        }

        

        private void typesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedType != null)
            {
                buttonEdit.IsEnabled = true;
                buttonDelete.IsEnabled = true;
            }
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxId.Text))
            {
                var replace = new ObservableCollection<ManifestationType>();

                foreach (var data in Database.getInstance().Types)
                {
                    if (data.Id.Contains(textBoxId.Text))
                    {
                        replace.Add(new ManifestationType(data));
                    }
                }
                Types = replace;
            }
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            Types = new ObservableCollection<ManifestationType>();
            foreach (var type in Database.getInstance().Types)
            {
                Types.Add(new ManifestationType(type));
            }
            textBoxId.Text = "";
        }
        #endregion

        #region PropertyChangedNotifier
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        private void textBoxId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                buttonSearch_Click(null, null);
            }
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
                HelpProvider.ShowHelp("ShowTypes", this);
            }
        }
    }
}
