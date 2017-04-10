using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Manifestations
{
    public class Config
    {
        #region File names
        public static readonly string MANIFESTATIONS_DATA = "manifestations.bin";
        public static readonly string TYPES_DATA = "types.bin";
        public static readonly string TAGS_DATA = "tags.bin";
        #endregion

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
}
