using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Manifestations.Models
{
    class Database : INotifyPropertyChanged
    {
        #region Attributes
        private static Database instance = null;

        public ObservableCollection<Manifestation> manifestations { get; set; }
        public ObservableCollection<ManifestationType> types { get; set; }
        public ObservableCollection<ManifestationTag> tags { get; set; }
        #endregion

        #region Singleton
        private Database()
        {
            manifestations = new ObservableCollection<Manifestation>();
            types = new ObservableCollection<ManifestationType>();
            tags = new ObservableCollection<ManifestationTag>();
        }

        public static Database getInstance()
        {
            if (instance == null)
            {
                instance = new Database();
            }
            return instance;
        }
        #endregion

        #region Adding content to the database
        public static bool AddManifestation(Manifestation manifestation)
        {
            getInstance().manifestations.Add(manifestation);
            return true;
        }

        public static bool AddType(ManifestationType type)
        {
            getInstance().types.Add(type);
            return true;
        }

        public static bool AddTag(ManifestationTag tag)
        {
            getInstance().tags.Add(tag);
            return true;
        }
        #endregion

        #region PropertyChangedNotifier
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
