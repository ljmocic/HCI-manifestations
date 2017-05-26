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
                    OnPropertyChanged("Manifestations");
                }
            }
        }

        private ObservableCollection<ManifestationType> types;
        public ObservableCollection<ManifestationType> Types
        {
            get { return types; }
            set
            {
                if (value != types)
                {
                    types = value;
                    OnPropertyChanged("Types");
                }
            }
        }

        private ObservableCollection<ManifestationTag> tags;
        public ObservableCollection<ManifestationTag> Tags
        {
            get { return tags; }
            set
            {
                if (value != tags)
                {
                    tags = value;
                    OnPropertyChanged("Tags");
                }
            }
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

        #region Working with database content
        public static void SaveManifestations()
        {
            SerializationService.serializeManifestations(getInstance().manifestations);
        }

        public static void SaveTypes()
        {
            SerializationService.serializeTypes(getInstance().types);
        }

        public static void SaveTags()
        {
            SerializationService.serializeTags(getInstance().tags);
        }
        
        public static void AddManifestation(Manifestation manifestation)
        {
            getInstance().manifestations.Add(manifestation);
            SaveManifestations();
        }

        public static void AddType(ManifestationType type)
        {
            getInstance().types.Add(type);
            SaveTypes();
        }

        public static void AddTag(ManifestationTag tag)
        {
            getInstance().tags.Add(tag);
            SaveTags();
        }

        public static Manifestation GetManifestation(string id)
        {
            for (int i = 0; i < getInstance().Manifestations.Count; i++)
            {
                if (getInstance().Manifestations[i].Id.Equals(id))
                {
                    return getInstance().Manifestations[i];
                }
            }
            return null;
        }

        public static ManifestationType GetType(string id)
        {
            for (int i = 0; i < getInstance().Types.Count; i++)
            {
                if (getInstance().Types[i].Id.Equals(id))
                {
                    return getInstance().Types[i];
                }
            }
            return null;
        }

        public static ManifestationTag GetTag(string id)
        {
            for (int i = 0; i < getInstance().Tags.Count; i++)
            {
                if (getInstance().Tags[i].Id.Equals(id))
                {
                    return getInstance().Tags[i];
                }
            }
            return null;
        }

        public static void UpdateManifestation(string oldId, Manifestation manifestation)
        {
            for (int i = 0; i < getInstance().Manifestations.Count; i++)
            {
                if (oldId.Equals(getInstance().Manifestations[i].Id))
                {
                    getInstance().Manifestations[i] = manifestation;
                    SaveManifestations();
                    break;
                }
            }
        }

        public static void UpdateType(string oldId, ManifestationType type)
        {
            for (int i = 0; i < getInstance().Types.Count; i++)
            {
                if (oldId.Equals(getInstance().Types[i].Id))
                {
                    getInstance().Types[i] = type;
                    SaveTypes();
                    break;
                }
            }
        }

        public static void UpdateTag(string oldId, ManifestationTag tag)
        {
            for (int i = 0; i < getInstance().Tags.Count; i++)
            {
                if (oldId.Equals(getInstance().Tags[i].Id))
                {
                    getInstance().Tags[i] = tag;
                    SaveTags();
                    break;
                }
            }
        }

        public static void DeleteManifestation(Manifestation manifestation)
        {
            for (int i = 0; i < getInstance().Manifestations.Count; i++)
            {
                if (manifestation.Id.Equals(getInstance().Manifestations[i].Id))
                {
                    getInstance().Manifestations.RemoveAt(i);
                    SaveManifestations();
                    break;
                }
            }
        }

        public static void DeleteType(ManifestationType type)
        {
            for (int i = 0; i < getInstance().Types.Count; i++)
            {
                if (type.Id.Equals(getInstance().Types[i].Id))
                {
                    getInstance().Types.RemoveAt(i);
                    SaveTypes();
                    break;
                }
            }
        }

        public static void DeleteTag(ManifestationTag tag)
        {
            for (int i = 0; i < getInstance().Tags.Count; i++)
            {
                if (tag.Id.Equals(getInstance().Tags[i].Id))
                {
                    getInstance().Tags.RemoveAt(i);
                    SaveTags();
                    break;
                }
            }
        }
        #endregion

        #region Loading database
        public static void loadData()
        {
            DeserializationService.deserializeTags();
            DeserializationService.deserializeTypes();
            DeserializationService.deserializeManifestations();
        }
        #endregion

        
    }
}
