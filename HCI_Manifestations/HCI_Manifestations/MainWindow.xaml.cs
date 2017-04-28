using HCI_Manifestations.dialogs;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HCI_Manifestations
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Database.loadData();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void AddManifestation_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddManifestation addManifestation = new AddManifestation();
            addManifestation.Show();
        }

        private void ShowManifestations_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ShowManifestations showManifestations = new ShowManifestations();
            showManifestations.Show();
        }

        private void AddType_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddType addType = new AddType();
            addType.Show();
        }

        private void ShowTypes_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ShowTypes showTypes = new ShowTypes();
            showTypes.Show();
        }

        private void AddTag_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddTag addTag = new AddTag();
            addTag.Show();
        }

        private void ShowTags_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ShowTags showTags = new ShowTags();
            showTags.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Da li ste sigurni?", "Potvrda zatvaranja aplikacije", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.No)
            {
                e.Cancel = true;

            }
        }

        // TODO Drag and drop
        private void Canvas_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void Canvas_Drop(object sender, DragEventArgs e)
        {

        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
