using HCI_Manifestations.Dialogs;
using HCI_Manifestations.Dialogs.Tag;
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
    public partial class ShowTags : Window, INotifyPropertyChanged
    {
        #region Attributes
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

        public ManifestationTag SelectedTag { get; set; }
        #endregion

        #region Constructors
        public ShowTags()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            SelectedTag = null;
            DataContext = this;
            Tags = Database.getInstance().Tags;
        }

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
            DeleteTag dialog = new DeleteTag(SelectedTag.Id);
            dialog.ShowDialog();
        }

        private void tagsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedTag != null)
            {
                buttonEdit.IsEnabled = true;
                buttonDelete.IsEnabled = true;
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
            Tags = Database.getInstance().Tags;
            textBoxId.Text = "";
        }

        private void textBoxId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                buttonSearch_Click(null, null);
            }
        }

        private void Help_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            HelpProvider.ShowHelp("ShowTags", this);
        }
        #endregion

        #region PropertyChangedHandler
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
