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
    public partial class ShowTypes : Window
    {
        #region Attributes
        public ObservableCollection<ManifestationType> types
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public ShowTypes()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.DataContext = this;
            types = Database.getInstance().types;
        }
        #endregion

        #region Event handlers
        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            AddType addType = new AddType();
            addType.Show();
        }
        #endregion
    }
}
