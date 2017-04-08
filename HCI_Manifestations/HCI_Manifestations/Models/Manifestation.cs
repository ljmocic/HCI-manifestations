using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Manifestations.Models
{
    public class Manifestation
    {
        private string id { get; set; }
        private string name { get; set; }
        private string description { get; set; }
        private DateTime date { get; set; }
        private ManifestationType type { get; set; }
        private string iconPath { get; set; }
        private bool inside { get; set; }
        private PriceEnum price { get; set; }
        private AlcoholEnum alcohol { get; set; }
        private string expectedPublic { get; set; }
        private List<Tag> tags { get; set; }

    }

    enum PriceEnum
    {
        FREE, LOW_PRICES, MEDIUM_PRICES, HIGH_PRICES
    }

    enum AlcoholEnum
    {
        NOT_ALLOWED, CAN_BRING, CAN_BUY
    }
}
