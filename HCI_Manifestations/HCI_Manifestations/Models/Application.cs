using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Manifestations.Models
{
    class Application
    {
        private static Application instance = null;

        private List<Manifestation> manifestations { get; set; }
        private List<ManifestationType> types { get; set; }
        private List<Tag> tags { get; set; }

        private Application()
        {
            this.manifestations = new List<Manifestation>();
            this.types = new List<ManifestationType>();
            this.tags = new List<Tag>();
        }

        public static Application getInstance()
        {
            if (instance == null)
            {
                instance = new Application();
            }
            return instance;
        }
        
    }
}
