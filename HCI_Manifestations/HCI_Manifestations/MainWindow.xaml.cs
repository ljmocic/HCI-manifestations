using HCI_Manifestations.dialogs;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Add_manifestation_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Add_manifestation_Click");
            AddManifestationDialog addManifestation = new AddManifestationDialog();
            addManifestation.Show();
        }

        private void Show_manifestations_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Show_manifestations_Click");
            ShowManifestationsDialog showManifestations = new ShowManifestationsDialog();
            showManifestations.Show();
        }

        private void Add_manifestation_type_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Add_manifestation_type_Click");
            AddManifestationTypeDialog addManifestationType = new AddManifestationTypeDialog();
            addManifestationType.Show();
        }

        private void Show_manifestation_types_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Show_manifestation_types_Click");
            ShowManifestationTypesDialog addManifestationType = new ShowManifestationTypesDialog();
            addManifestationType.Show();
        }

        private void Add_tag_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Add_manifestation_type_Click");
            AddTagDialog addTag = new AddTagDialog();
            addTag.Show();
        }

        private void Show_tags_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Show_manifestation_types_Click");
            ShowTagsDialog showTagsDialog = new ShowTagsDialog();
            showTagsDialog.Show();
        }

        private void Show_help_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Show_help_Click");
            ShowHelpDialog showHelp = new ShowHelpDialog();
            showHelp.Show();
        }
    }
}
