using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Manifestations.Models
{
    [Serializable]
    public class ManifestationTag : INotifyPropertyChanged
    {
        #region Attributes
        private string id;
        public string Id
        {
            get { return id; }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        private string color;
        public string Color
        {
            get { return color; }
            set
            {
                if (value != color)
                {
                    color = value;
                    OnPropertyChanged("Color");
                }
            }
        }

        private string descripton;
        public string Descripton
        {
            get { return descripton; }
            set
            {
                if (value != descripton)
                {
                    descripton = value;
                    OnPropertyChanged("Descripton");
                }
            }
        }
        #endregion

        #region Constructors
        public ManifestationTag()
        {
        }

        public ManifestationTag(string id, string color, string descripton)
        {
            this.id = id;
            this.color = color;
            this.descripton = descripton;
        }
        #endregion

        #region PropertyChangedNotifier
        [field: NonSerialized]
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
