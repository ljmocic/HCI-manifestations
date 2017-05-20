using System;
using System.Collections.Generic;
using System.IO;
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

namespace HCI_Manifestations.Dialogs
{
    /// <summary>
    /// Interaction logic for ShowHelp.xaml
    /// </summary>
    public partial class ShowHelp : Window
    {
        public ShowHelp(string key, Window originator)
        {
            InitializeComponent();
            
            string path = String.Format("{0}/Resources/Documentation/{1}.html", Directory.GetCurrentDirectory(), key);

            if (!File.Exists(path))
                key = "error";
            
            Uri url = new Uri(String.Format("file:///{0}/Resources/Documentation/{1}.html", Directory.GetCurrentDirectory(), key));

            HelpBrowser.Navigate(url);
        }
    }
}
