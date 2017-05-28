using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Manifestations.Models
{
    [Serializable]
    public class ManifestationType : INotifyPropertyChanged
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

        private string iconPath;
        public string IconPath
        {
            get { return iconPath; }
            set
            {
                if (value != iconPath)
                {
                    iconPath = value;
                    string newPath = Directory.GetCurrentDirectory() + "\\" + @iconPath.Split('\\').Last();
                    File.Copy(@iconPath, @newPath);
                    iconPath = newPath;
                    OnPropertyChanged("IconPath");
                }
            }
        }
        #endregion

        #region Constructors
        public ManifestationType()
        {
        }

        public ManifestationType(string id, string name, string description, string iconPath) {
            this.id = id;
            this.name = name;
            this.description = description;
            this.iconPath = iconPath;
        }

        public ManifestationType(ManifestationType type)
        {
            if (type != null)
            {
                id = type.Id;
                name = type.Name;
                description = type.Description;
                iconPath = type.IconPath;
            }
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
