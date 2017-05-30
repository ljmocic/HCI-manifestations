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

namespace HCI_Manifestations.Dialogs.Tag
{
    public partial class DeleteTag : Window
    {
        private ObservableCollection<Manifestation> manifestations;
        public ObservableCollection<Manifestation> Manifestations
        {
            get { return manifestations; }
            set { manifestations = value; }
        }

        private ObservableCollection<Manifestation> manifestationsWithTag;
        public ObservableCollection<Manifestation> ManifestationsWithTag
        {
            get { return manifestationsWithTag; }
            set { manifestationsWithTag = value; }
        }

        private ManifestationTag tag;
        public ManifestationTag mTag
        {
            get { return tag; }
            set { tag = value; }
        }

        public DeleteTag(string tagId)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            Manifestations = Database.getInstance().Manifestations;
            mTag = Database.GetTag(tagId);

            manifestationsWithTag = new ObservableCollection<Manifestation>();

            foreach (var manifestation in Manifestations)
            {
                foreach (var tag in manifestation.Tags)
                {
                    if (tag.Id.Equals(mTag.Id))
                    {
                        manifestationsWithTag.Add(manifestation);
                    }
                }
            }
            DataContext = this;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Database.DeleteTag(mTag);

            for (int i = Manifestations.Count - 1; i >= 0; i--)
            {
                for (int j = Manifestations[i].Tags.Count - 1; j >= 0; j--)
                {
                    if (Manifestations[i].Tags[j].Id.Equals(mTag.Id))
                    {
                        Manifestations[i].Tags.RemoveAt(j);
                    }
                }
            }

            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
