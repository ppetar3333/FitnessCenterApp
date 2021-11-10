using fitnessCenterProject.Essentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace fitnessCenterProject.Validation
{
    class UserValidation
    {
        public static bool createUserValidation(TextBox textBoxName, TextBox textBoxLastName, TextBox textBoxJMBG, ComboBox comboBoxEnum, TextBox textBoxPassword, ComboBox comboBoxAddresses, TextBox textBoxEmail)
        {
            bool ok = true;
            String message = "Error. Please correct invalid inputs\n";
            if (textBoxName.Text.Equals(""))
            {
                message += "- Name field can not be blank!\n";
                ok = false;
            }
            if (textBoxLastName.Text.Equals(""))
            {
                message += "- Last name field can not be blank!\n";
                ok = false;
            }
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
            else if (CheckDuplicatedJmbg.isNotDuplicatedBeginner(long.Parse(textBoxJMBG.Text.ToString())) ||
                CheckDuplicatedJmbg.isNotDuplicatedAdmin(long.Parse(textBoxJMBG.Text.ToString())) ||
                CheckDuplicatedJmbg.isNotDuplicatedInstructor(long.Parse(textBoxJMBG.Text.ToString())))
            {
                message += "- JMBG already exists!\n";
                ok = false;
            }
            if (comboBoxEnum.SelectedIndex == -1)
            {
                message += "- Please select gender.\n";
                ok = false;
            }
            if (textBoxPassword.Text.Equals(""))
            {
                message += "- Password field can not be blank!\n";
                ok = false;
            }
            if (comboBoxAddresses.SelectedIndex == -1)
            {
                message += "- Plese select address.\n";
                ok = false;
            }
            if (textBoxEmail.Text.Equals(""))
            {
                message += "- Email filed can not be empty!\n";
                ok = false;
            }
            if (!textBoxEmail.Text.Contains("@"))
            {
                message += "- Email is not in valid format!\n";
                ok = false;
            }
            if (ok == false)
                MessageBox.Show(message, "Please, try again.");

            return ok;
        }

        public static bool searchUserValidation(TextBox textBoxName, TextBox textBoxLastName, TextBox textBoxAddress, TextBox textBoxEmail)
        {
            bool ok = true;
            String message = "Error. Please correct invalid inputs\n";
            if (textBoxName.Text.Equals(""))
            {
                message += "- Name field can not be blank!\n";
                ok = false;
            }
            if (textBoxLastName.Text.Equals(""))
            {
                message += "- Last name field can not be blank!\n";
                ok = false;
            }
            if (textBoxAddress.Text.Equals(""))
            {
                message += "- Address field can not be blank!\n";
                ok = false;
            }
            if (textBoxEmail.Text.Equals(""))
            {
                message += "- Email field can not be empty!\n";
                ok = false;
            }
            else if (!textBoxEmail.Text.Contains("@"))
            {
                message += "- Email is in invalid format!\n";
                ok = false;
            }
            if (ok == false)
                MessageBox.Show(message, "Please, try again.");

            return ok;
        }
        public static bool updateUserValidation(TextBox textBoxName, ComboBox comboBoxGender,TextBox textBoxLastName, TextBox textBoxPassword, ComboBox comboBoxAddresses, TextBox textBoxEmail)
        {
            bool ok = true;
            String message = "Error. Please correct invalid inputs\n";

            if (textBoxName.Text.Equals(""))
            {
                message += "- Name field can not be blank!\n";
                ok = false;
            }
            if (comboBoxGender.SelectedItem == null)
            {
                message += "- Please select gender\n";
                ok = false;
            }
            if (textBoxLastName.Text.Equals(""))
            {
                message += "- Last name field can not be blank!\n";
                ok = false;
            }
            if (textBoxPassword.Text.Equals(""))
            {
                message += "- Password field can not be blank!\n";
                ok = false;
            }
            if (comboBoxAddresses.SelectedItem == null)
            {
                message += "- Please select address\n";
                ok = false;
            }
            if (textBoxEmail.Text.Equals(""))
            {
                message += "- Email filed can not be empty!\n";
                ok = false;
            }
            if (!textBoxEmail.Text.Contains("@"))
            {
                message += "- Email field is not in valid format!\n";
                ok = false;
            }
            if (ok == false)
                MessageBox.Show(message, "Please, try again.");

            return ok;
        }
    }
}
