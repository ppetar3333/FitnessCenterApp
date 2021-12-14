using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace fitnessCenterProject.Validation
{
    class LogInValidation
    {
        public static bool logInValidation(TextBox textBoxJMBG, PasswordBox textBoxPassword)
        {
            bool ok = true;
            String message = "Error. Please correct invalid inputs\n";
            if (textBoxJMBG.Text.Equals(""))
            {
                message += "- JMBG field can not be empty!\n";
                ok = false;
            }
            else if (!textBoxJMBG.Text.All(char.IsDigit))
            {
                message += "- JMBG can not have letters.\n";
                ok = false;
            }
            else if (textBoxJMBG.Text.Length != 13)
            {
                message += "- JMBG needs to be 13 digit.\n";
                ok = false;
            }
            if (textBoxPassword.Password.ToString().Equals(""))
            {
                message += "- Password field can not be blank!\n";
                ok = false;
            }
            if (ok == false)
                MessageBox.Show(message, "Please, try again.");

            return ok;
        }
    }
}
