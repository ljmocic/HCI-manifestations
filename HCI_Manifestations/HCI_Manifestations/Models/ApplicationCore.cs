using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Manifestations.Models
{
    class ApplicationCore
    {
        private static ApplicationCore instance = null;

        private List<Manifestation> manifestations { get; set; }
        private List<ManifestationType> types { get; set; }
        private List<Tag> tags { get; set; }

        private ApplicationCore()
        {
            this.manifestations = new List<Manifestation>();
            this.types = new List<ManifestationType>();
            this.tags = new List<Tag>();
        }

        public static ApplicationCore getInstance()
        {
            if (instance == null)
            {
                instance = new ApplicationCore();
            }
            return instance;
        }
    }
}
