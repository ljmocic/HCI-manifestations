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

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var temp = value as string;
                if (temp.Any(ch => !char.IsLetterOrDigit(ch)))
                { 
                    return new ValidationResult(false, "Dozvoljeni karakteri su samo slova i brojevi");
                }
                else
                {
                    return new ValidationResult(true, "");
                }
            }
            catch
            {
                return new ValidationResult(false, "Desila se neočekivana greška");
            }
        }
    }

}
