using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Manifestations.Models
{
    public class ManifestationType
    {
        private string id { get; set; }
        private string name { get; set; }
        private string description { get; set; }
        private string iconPath { get; set; }

        public ManifestationType(string id, string name, string description, string iconPath) {
            this.id = id;
            this.name = name;
            this.description = description;
            this.iconPath = iconPath;
        }
    }
}
