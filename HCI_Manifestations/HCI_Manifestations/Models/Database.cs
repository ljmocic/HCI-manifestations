using HCI_Manifestations.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Manifestations.Models
{
    public class Database : INotifyPropertyChanged
    {
        #region Attributes
        private static Database instance = null;

        private ObservableCollection<Manifestation> manifestations;
        public ObservableCollection<Manifestation> Manifestations
        {
            get { return manifestations; }
            set
            {
                if (value != manifestations)
                {
                    manifestations = value;
                    OnPropertyChanged("Name");
                }
            }
        }
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
        public static void AddManifestation(Manifestation manifestation)
        {
            getInstance().manifestations.Add(manifestation);
            SerializationService.serializeManifestations(getInstance().manifestations);
        }

        public static void AddType(ManifestationType type)
        {
            getInstance().types.Add(type);
            SerializationService.serializeTypes(getInstance().types);
        }

        public static void AddTag(ManifestationTag tag)
        {
            getInstance().tags.Add(tag);
            SerializationService.serializeTags(getInstance().tags);
        }
        #endregion

        public static void loadData()
        {
            DeserializationService.deserializeManifestations();
            DeserializationService.deserializeTypes();
            DeserializationService.deserializeTags();
        }

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
