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
        private bool smokingInside { get; set; }
        private bool smokingOutside { get; set; }
        private PriceEnum price { get; set; }
        private AlcoholEnum alcohol { get; set; }
        private string expectedPublic { get; set; }
        private List<Tag> tags { get; set; }

        public Manifestation(string id, string name, string description, DateTime date, ManifestationType type, string iconPath, 
            bool smokingInside, bool smokingOutside, PriceEnum price, AlcoholEnum alcohol, string expectedPublic, List<Tag> tags)
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

    }

    public enum PriceEnum
    {
        FREE, LOW_PRICES, MEDIUM_PRICES, HIGH_PRICES
    }

    public enum AlcoholEnum
    {
        NOT_ALLOWED, CAN_BRING, CAN_BUY
    }
}
