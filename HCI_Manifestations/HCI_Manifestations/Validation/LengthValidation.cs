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
                if (value != null)
                {
                    var text = value as string;
                    if (text.Length == 0 || text == null)
                    {
                        return new ValidationResult(false, "Popunjavanje polja je obavezno");
                    }
                    else if (text.Length < Min)
                    {
                        return new ValidationResult(false, "Minimalna dužina unosa je " + Min + " karaktera");
                    }
                    else if (text.Length > Max)
                    {
                        return new ValidationResult(false, "Maksimalna dužina unosa je " + Max + " karaktera");
                    }
                    return new ValidationResult(true, null);
                }
                else
                {
                    return new ValidationResult(false, "Popunjavanje polja je obavezno");
                }
            }
            catch
            {
                return new ValidationResult(false, "Desila se neočekivana greška.");
            }
        }
    }

}
