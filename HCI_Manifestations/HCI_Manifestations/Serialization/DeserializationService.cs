using HCI_Manifestations.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Manifestations.Serialization
{
    public class DeserializationService
    {
        public static void deserializeManifestations()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            if (File.Exists(Config.MANIFESTATIONS_DATA))
            {
                try
                {
                    stream = File.Open(Config.MANIFESTATIONS_DATA, FileMode.Open);
                    var data = (ObservableCollection<Manifestation>) formatter.Deserialize(stream);
                    Database.getInstance().Manifestations = data;
                }
                catch
                {
                    // Add exceptions later
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }

            }
        }

        public static void deserializeTypes()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            if (File.Exists(Config.TYPES_DATA))
            {
                try
                {
                    stream = File.Open(Config.TYPES_DATA, FileMode.Open);
                    Database.getInstance().types = (ObservableCollection<ManifestationType>) formatter.Deserialize(stream);
                }
                catch
                {
                    // Add exceptions later
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }

            }
        }

        public static void deserializeTags()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            if (File.Exists(Config.TAGS_DATA))
            {
                try
                {
                    stream = File.Open(Config.TAGS_DATA, FileMode.Open);
                    Database.getInstance().tags = (ObservableCollection<ManifestationTag>) formatter.Deserialize(stream);
                }
                catch
                {
                    // Add exceptions later
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }

            }
        }
    }
}
