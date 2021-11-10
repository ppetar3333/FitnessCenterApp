using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace fitnessCenterProject.Validation
{
    class ModelValidation
    {
        public static bool addressValidation(TextBox countryTextBox, TextBox cityTextBox, TextBox streetTextBox, TextBox numberTextBox)
        {
            bool ok = true;
            String message = "Error. Please correct invalid inputs\n";
            if (countryTextBox.Text.Equals(""))
            {
                message += "- Country field can not be blank!\n";
                ok = false;
            }
            if (cityTextBox.Text.Equals(""))
            {
                message += "- City field can not be blank!\n";
                ok = false;
            }
            if (streetTextBox.Text.Equals(""))
            {
                message += "- Street field can not be empty!\n";
                ok = false;
            }
            if (numberTextBox.Text.Equals(""))
            {
                message += "- Number field can not be empty!\n";
                ok = false;
            }
            else if (!numberTextBox.Text.All(char.IsDigit))
            {
                message += "- Number of street can not have letters.\n";
                ok = false;
            }
            if (ok == false)
                MessageBox.Show(message, "Please, try again.");

            return ok;
        }

        public static bool fitnessCenterValidation(TextBox textBoxName, ComboBox comboBoxAddresses)
        {
            bool ok = true;
            String message = "Error. Please correct invalid inputs\n";

            if (textBoxName.Text.Equals(""))
            {
                message += "- Name field can not be blank!\n";
                ok = false;
            }
            if (comboBoxAddresses.SelectedItem == null)
            {
                message += "- Please select address.\n";
                ok = false;
            }
            if (ok == false)
                MessageBox.Show(message, "Please, try again.");

            return ok;
        }

        public static bool createTrainingValidation(TextBox startTime, TextBox durationOfTraining, ComboBox instructorsComboBox)
        {
            bool ok = true;
            String message = "Error. Please correct invalid inputs\n";
            if (startTime.Text.Equals(""))
            {
                message += "- Start time field can not be blank!\n";
                ok = false;
            }
            if (durationOfTraining.Text.Equals(""))
            {
                message += "- Duration of training field can not be blank!\n";
                ok = false;
            }
            else if (!durationOfTraining.Text.All(char.IsDigit))
            {
                message += "- Duration of training can not have letters.\n";
                ok = false;
            }
            if (instructorsComboBox.SelectedIndex == -1)
            {
                message += "- Please select instructor.\n";
                ok = false;
            }
            if (ok == false)
                MessageBox.Show(message, "Please, try again.");
            return ok;
        }
        public static bool createTrainingInstructorValidation(TextBox startTime, TextBox durationOfTraining)
        {
            bool ok = true;
            String message = "Error. Please correct invalid inputs\n";
            if (startTime.Text.Equals(""))
            {
                message += "- Start time field can not be blank!\n";
                ok = false;
            }
            if (durationOfTraining.Text.Equals(""))
            {
                message += "- Duration of training field can not be blank!\n";
                ok = false;
            }
            else if (!durationOfTraining.Text.All(char.IsDigit))
            {
                message += "- Duration of training can not have letters.\n";
                ok = false;
            }
            if (ok == false)
                MessageBox.Show(message, "Please, try again.");
            return ok;
        }

        public static bool checkTrainingValidation(DatePicker selectedDate)
        {
            bool ok = true;
            String message = "Error. Please correct invalid inputs\n";
            if (selectedDate.Text.Equals(""))
            {
                message += "- Input can not be empty.\n";
                ok = false;
            }
            if (ok == false)
                MessageBox.Show(message, "Please, try again.");
            return ok;
        }
    }
}
