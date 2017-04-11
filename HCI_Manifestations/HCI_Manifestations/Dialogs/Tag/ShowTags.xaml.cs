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
    public partial class ShowTags : Window
    {
        #region Attributes
        public ManifestationTag SelectedTag { get; set; }
        public ObservableCollection<ManifestationTag> tags { get; set; }
        #endregion

        #region Constructors
        public ShowTags()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            SelectedTag = null;
            DataContext = this;
            tags = Database.getInstance().tags;
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
            EditTag editTag = new EditTag(SelectedTag.Id);
            editTag.Show();
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
            }
        }
        #endregion
    }
}
