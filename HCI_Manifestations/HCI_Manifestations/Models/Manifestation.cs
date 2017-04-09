using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Manifestations.Models
{
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
            set { date = value; }
        }

        private ManifestationType type;
        public ManifestationType Type
        {
            get { return type; }
            set { type = value; }
        }

        private string iconPath;
        public string IconPath
        {
            get { return iconPath; }
            set { iconPath = value; }
        }

        private bool smokingInside;
        public bool SmokingInside
        {
            get { return smokingInside; }
            set { smokingInside = value; }
        }

        private bool smokingOutside;
        public bool SmokingOutside
        {
            get { return smokingOutside; }
            set { smokingOutside = value; }
        }

        private PriceEnum price;
        public PriceEnum Price
        {
            get { return price; }
            set { price = value; }
        }

        private AlcoholEnum alcohol;
        public AlcoholEnum Alcohol
        {
            get { return alcohol; }
            set { alcohol = value; }
        }

        private string expectedPublic;
        public string ExpectedPublic
        {
            get { return expectedPublic; }
            set { expectedPublic = value; }
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
            bool smokingInside, bool smokingOutside, PriceEnum price, AlcoholEnum alcohol, string expectedPublic, List<ManifestationTag> tags)
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

    #region Enums
    public enum PriceEnum
    {
        FREE, LOW_PRICES, MEDIUM_PRICES, HIGH_PRICES
    }

    public enum AlcoholEnum
    {
        NOT_ALLOWED, CAN_BRING, CAN_BUY
    }
    #endregion
}
