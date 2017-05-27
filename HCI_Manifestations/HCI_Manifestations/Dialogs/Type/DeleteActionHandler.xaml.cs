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

namespace HCI_Manifestations.Dialogs.Type
{
    public partial class DeleteActionHandler : Window
    {
        private ManifestationType SelectedType;

        public DeleteActionHandler(ManifestationType SelectedType)
        {
            InitializeComponent();
            this.SelectedType = SelectedType;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Manifestation> manifestations = Database.getInstance().Manifestations;

            for (int i = manifestations.Count - 1; i >= 0; i--)
            {
                if (manifestations[i].Type.Id.Equals(SelectedType.Id))
                {
                    Database.DeleteManifestation(manifestations[i]);
                }
            }
            Database.DeleteType(SelectedType);
            Close();
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Manifestation> manifestations = Database.getInstance().Manifestations;
            for (int i = manifestations.Count - 1; i >= 0; i--)
            {
                if (manifestations[i].Type.Id.Equals(SelectedType.Id))
                {
                    EditManifestation em = new EditManifestation(manifestations[i].Id);
                    em.ShowDialog();
                }
            }
            Close();
        }
    }
}
