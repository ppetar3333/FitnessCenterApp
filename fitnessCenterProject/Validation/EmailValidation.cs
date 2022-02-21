using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace fitnessCenterProject.Validation
{
    class EmailValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;
            if (charString.ToString().Contains("@") && charString.ToString().EndsWith(".com"))
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Email invalid format!");
            }
        }
    }
}
