using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI_Manifestations.Validation
{
    public class ContentValidation : ValidationRule
    {
        public string Type { get; set; }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                // TODO Content validation
                return new ValidationResult(true, "");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }

}
