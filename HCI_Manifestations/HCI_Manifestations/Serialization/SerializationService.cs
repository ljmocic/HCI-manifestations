using HCI_Manifestations.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HCI_Manifestations.Serialization
{
    public class SerializationService
    {
        public static void serializeManifestations(ObservableCollection<Manifestation> manifestations)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            try
            {
                stream = File.Open(Config.MANIFESTATIONS_DATA, FileMode.OpenOrCreate);
                formatter.Serialize(stream, manifestations);
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

        public static void serializeTypes(ObservableCollection<ManifestationType> types)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            try
            {
                stream = File.Open(Config.TYPES_DATA, FileMode.OpenOrCreate);
                formatter.Serialize(stream, types);
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

        public static void serializeTags(ObservableCollection<ManifestationTag> tag)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            try
            {
                stream = File.Open(Config.TAGS_DATA, FileMode.OpenOrCreate);
                formatter.Serialize(stream, tag);
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
