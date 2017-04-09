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
    /// Interaction logic for ShowTagsDialog.xaml
    /// </summary>
    public partial class ShowTags : Window
    {
        #region Attributes
        public ObservableCollection<ManifestationTag> tags
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public ShowTags()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            this.DataContext = this;
            tags = Database.getInstance().tags;
        }
        #endregion

        #region Event handlers
        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            AddTag addTag = new AddTag();
            addTag.Show();
        }
        #endregion
    }
}
