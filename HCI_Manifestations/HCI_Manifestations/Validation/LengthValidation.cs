using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI_Manifestations.Validation
{
    public class LengthValidation : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var text = value as string;
                if (text.Length == 0)
                {
                    return new ValidationResult(false, "Name is required.");
                }
                else if (text.Length < Min)
                {
                    return new ValidationResult(false, "Minimum name length is " + Min + " chars.");
                }
                else if (text.Length > Max)
                {
                    return new ValidationResult(false, "Maximum name length is " + Max + " chars.");
                }
                else
                {
                    return new ValidationResult(true, null);
                }
            }
            catch
            {
                return new ValidationResult(false, "Unknown error happened.");
            }
        }
    }

}
