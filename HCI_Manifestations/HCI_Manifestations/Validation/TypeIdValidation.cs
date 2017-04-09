using HCI_Manifestations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI_Manifestations.Validation
{
    public class TypeIdValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var text = value as string;

                foreach (ManifestationType type in Database.getInstance().types)
                {
                    if (type.Id.Equals(text))
                    {
                        return new ValidationResult(false, "Id already exists.");
                    }
                }

                return new ValidationResult(true, "");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }

}
