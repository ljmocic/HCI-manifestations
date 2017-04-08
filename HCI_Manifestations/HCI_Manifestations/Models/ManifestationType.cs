using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Manifestations.Models
{
    class ManifestationType
    {
        private string id;
        private string name;
        private string description;
        private string iconPath;

        public ManifestationType(string id, string name, string description, string iconPath) {
            this.id = id;
            this.name = name;
            this.description = description;
            this.iconPath = iconPath;
        }
    }
}
