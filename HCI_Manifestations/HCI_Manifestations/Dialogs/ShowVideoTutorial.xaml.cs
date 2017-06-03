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

namespace HCI_Manifestations.Dialogs
{
    public partial class ShowVideoTutorial : Window
    {
        public ShowVideoTutorial()
        {
            InitializeComponent();
        }

        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            player.Play();
        }

        private void buttonPause_Click(object sender, RoutedEventArgs e)
        {
            player.Pause();
        }

        private void buttonStop_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
        }
    }
}
