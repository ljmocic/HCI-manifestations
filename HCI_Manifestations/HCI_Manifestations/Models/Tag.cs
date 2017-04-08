using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Manifestations.Models
{
    public class Tag
    {
        private string id { get; set; }
        private string color { get; set; }
        private string descripton { get; set; }

        public Tag(string id, string color, string description)
        {
            this.id = id;
            this.color = color;
            this.descripton = descripton;
        }
    }
}
