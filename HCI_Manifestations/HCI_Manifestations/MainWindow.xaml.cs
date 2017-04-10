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

        private void Add_manifestation_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Add_manifestation_Click");
            AddManifestation addManifestation = new AddManifestation();
            addManifestation.Show();
        }

        private void Show_manifestations_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Show_manifestations_Click");
            ShowManifestations showManifestations = new ShowManifestations();
            showManifestations.Show();
        }

        private void Add_type_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Add_type_Click");
            AddType addType = new AddType();
            addType.Show();
        }

        private void Show_types_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Show_types_Click");
            ShowTypes showTypes = new ShowTypes();
            showTypes.Show();
        }

        private void Add_tag_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Add_tag_Click");
            AddTag addTag = new AddTag();
            addTag.Show();
        }

        private void Show_tags_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Show_tag_Click");
            ShowTags showTags = new ShowTags();
            showTags.Show();
        }

        private void Show_help_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Show_help_Click");
            ShowHelp showHelp = new ShowHelp();
            showHelp.Show();
        }
    }
}
