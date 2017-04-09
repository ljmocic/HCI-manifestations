using HCI_Manifestations.Models;
using System;
using System.Collections.Generic;
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

    public partial class AddManifestation : Window
    {

        #region Attributes
        private Manifestation manifestation;
        public Manifestation Manifestation
        {
            get { return manifestation; }
            set { manifestation = value; }
        }
        #endregion

        #region Constructors
        public AddManifestation()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            manifestation = new Manifestation();
            DataContext = manifestation;
        }
        #endregion

        #region Event handlers
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            // TODO validation later
            bool validated = true;
            if (validated)
            {
                Database.AddManifestation(manifestation);
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
