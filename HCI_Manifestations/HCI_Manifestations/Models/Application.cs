using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Manifestations.Models
{
    class Application : INotifyPropertyChanged
    {
        private static Application instance = null;

        private List<Manifestation> _manifestations;
        private List<ManifestationType> _types;
        private List<Tag> _tags;

        public event PropertyChangedEventHandler PropertyChanged;

        private Application()
        {
            this._manifestations = new List<Manifestation>();
            this._types = new List<ManifestationType>();
            this._tags = new List<Tag>();
        }

        public static Application getInstance()
        {
            if (instance == null)
            {
                instance = new Application();
            }
            return instance;
        }

        
        public List<Manifestation> manifestations
        {
            get
            {
                return _manifestations;
            }
            set
            {
                if (value != manifestations)
                {
                    manifestations = value;
                }
            }
        }

        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }
    }
}
