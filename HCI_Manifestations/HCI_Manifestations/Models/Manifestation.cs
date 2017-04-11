using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HCI_Manifestations.Config;

namespace HCI_Manifestations.Models
{
    [Serializable]
    public class Manifestation : INotifyPropertyChanged
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

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                if (value != description)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        private bool handicap;
        public bool Handicap
        {
            get { return handicap; }
            set
            {
                if (value != handicap)
                {
                    handicap = value;
                    OnPropertyChanged("Handicap");
                }
            }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (value != date)
                {
                    date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        private ManifestationType type;
        public ManifestationType Type
        {
            get { return type; }
            set
            {
                if (value != type)
                {
                    type = value;
                    OnPropertyChanged("Type");
                }
            }
        }

        private string iconPath;
        public string IconPath
        {
            get { return iconPath; }
            set
            {
                if (value != iconPath)
                {
                    iconPath = value;
                    OnPropertyChanged("IconPath");
                }
            }
        }

        private bool smokingInside;
        public bool SmokingInside
        {
            get { return smokingInside; }
            set
            {
                if (value != smokingInside)
                {
                    smokingInside = value;
                    OnPropertyChanged("SmokingInside");
                }
            }
        }

        private bool smokingOutside;
        public bool SmokingOutside
        {
            get { return smokingOutside; }
            set
            {
                if (value != smokingOutside)
                {
                    smokingOutside = value;
                    OnPropertyChanged("SmokingOuside");
                }
            }
        }

        private string price;
        public string Price
        {
            get { return price; }
            set
            {
                if (value != price)
                {
                    price = value;
                    OnPropertyChanged("Price");
                }
            }
        }

        private string alcohol;
        public string Alcohol
        {
            get { return alcohol; }
            set
            {
                if (value != alcohol)
                {
                    alcohol = value;
                    OnPropertyChanged("Alcohol");
                }
            }
        }

        private string expectedPublic;
        public string ExpectedPublic
        {
            get { return expectedPublic; }
            set
            {
                if (value != expectedPublic)
                {
                    expectedPublic = value;
                    OnPropertyChanged("ExpectedPublic");
                }
            }
        }

        private List<ManifestationTag> tags;
        public List<ManifestationTag> Tags
        {
            get { return tags; }
            set { tags = value; }
        }
        #endregion

        #region Constructors
        public Manifestation()
        {
            tags = new List<ManifestationTag>();
        }

        public Manifestation(string id, string name, string description, DateTime date, ManifestationType type, string iconPath,
            bool smokingInside, bool smokingOutside, string price, string alcohol, string expectedPublic, List<ManifestationTag> tags)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.date = date;
            this.type = type;
            this.iconPath = iconPath;
            this.smokingInside = smokingInside;
            this.smokingOutside = smokingOutside;
            this.price = price;
            this.alcohol = alcohol;
            this.expectedPublic = expectedPublic;
            this.tags = tags;
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
