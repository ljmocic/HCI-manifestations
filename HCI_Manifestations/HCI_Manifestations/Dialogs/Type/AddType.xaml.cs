using HCI_Manifestations.Models;
using System;
using System.Collections.Generic;
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
    public partial class AddType : Window
    {

        #region Attributes
        private ManifestationType type;
        public ManifestationType Type // Tag name Overshadows Tag from .NET library
        {
            get { return type; }
            set { type = value; }
        }
        #endregion

        #region Constructors
        public AddType()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            type = new ManifestationType();
            DataContext = type;
        }
        #endregion

        #region Event handlers
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            // TODO validation later
            bool validated = true;
            if (validated)
            {
                Database.AddType(type);
                Close();
            }
            else
            {
                // If data is not validated
            }

        }
        #endregion
    }
}
