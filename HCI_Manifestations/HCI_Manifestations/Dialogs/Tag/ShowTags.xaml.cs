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
    public partial class ShowTags : Window, INotifyPropertyChanged
    {
        #region Attributes
        public ManifestationTag SelectedTag { get; set; }
        private ObservableCollection<ManifestationTag> tags;
        public ObservableCollection<ManifestationTag> Tags
        {
            get { return tags; }
            set
            {
                if (value != tags)
                {
                    tags = value;
                    OnPropertyChanged("Tags");
                }
            }
        }
        #endregion

        #region Constructors
        public ShowTags()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            SelectedTag = null;
            DataContext = this;
            tags = Database.getInstance().tags;

            Tags = new ObservableCollection<ManifestationTag>();
            foreach (var tag in Database.getInstance().Tags)
            {
                Tags.Add(new ManifestationTag(tag));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Event handlers
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddTag addTag = new AddTag();
            addTag.Show();
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTag != null)
            {
                EditTag editTag = new EditTag(SelectedTag.Id);
                editTag.Show();
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            Database.DeleteTag(SelectedTag);
        }

        private void tagsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedTag != null)
            {
                buttonEdit.IsEnabled = true;
                buttonDelete.IsEnabled = true;
            }
        }
        #endregion

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxId.Text))
            {
                var replace = new ObservableCollection<ManifestationTag>();

                foreach (var data in Database.getInstance().Tags)
                {
                    if (data.Id.Contains(textBoxId.Text))
                    {
                        replace.Add(new ManifestationTag(data));
                    }
                }
                Tags = replace;
            }
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            Tags = new ObservableCollection<ManifestationTag>();
            foreach (var tag in Database.getInstance().Tags)
            {
                Tags.Add(new ManifestationTag(tag));
            }
            textBoxId.Text = "";
        }
    }
}
