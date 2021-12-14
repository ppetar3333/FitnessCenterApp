using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace fitnessCenterProject.Interfaces.ChangeInterfaces
{
    interface IChangeModels
    {
        void fillInInputs(object obj, TextBox textBoxName, TextBox textBoxLastName, TextBox textBoxPassword, TextBox textBoxJMBG, TextBox textBoxEmail, ComboBox comboBoxAddresses, ComboBox comboBoxGender);
        void getDataFromInputs(TextBox textBoxName, TextBox textBoxLastName, TextBox textBoxPassword, TextBox textBoxJMBG, TextBox textBoxEmail, ComboBox comboBoxAddresses, ComboBox comboBoxGender,
            out string firstName, out string lastName, out int addressID, out long jmbg, out string gender, out string email, out string password);
    }
}
