using fitnessCenterProject.Interfaces.ChangeInterfaces;
using fitnessCenterProject.Windows.SearchBY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace fitnessCenterProject.Essentials.FillInputs
{
    public class FillInputs : IChangeModels
    {
        private Models.Beginner beginner;
        private Models.Instructor instructor;
        private Models.Admin admin;

        public void fillInInputs(object obj, TextBox textBoxName, TextBox textBoxLastName, TextBox textBoxPassword, TextBox textBoxJMBG, TextBox textBoxEmail, ComboBox comboBoxAddresses, ComboBox comboBoxGender)
        {
            if(obj is Models.Beginner)
            {
                beginner = obj as Models.Beginner;
                textBoxName.DataContext = beginner;
                textBoxLastName.DataContext = beginner;
                textBoxPassword.DataContext = beginner;
                textBoxJMBG.DataContext = beginner;
                textBoxEmail.DataContext = beginner;
                FillComboBox.FillComboBox.fillComboBoxAddress(comboBoxAddresses);
                FillComboBox.FillComboBox.fillComboBoxGender(comboBoxGender);
            }
            else if(obj is Models.Admin)
            {
                admin = obj as Models.Admin;
                textBoxName.DataContext = admin;
                textBoxLastName.DataContext = admin;
                textBoxJMBG.DataContext = admin;
                textBoxEmail.DataContext = admin;
                textBoxPassword.DataContext = admin;
                FillComboBox.FillComboBox.fillComboBoxAddress(comboBoxAddresses);
                FillComboBox.FillComboBox.fillComboBoxGender(comboBoxGender);
            }
            else if(obj is Models.Instructor)
            {
                instructor = obj as Models.Instructor;
                textBoxName.DataContext = instructor;
                textBoxLastName.DataContext = instructor;
                textBoxJMBG.DataContext = instructor;
                textBoxEmail.DataContext = instructor;
                textBoxPassword.DataContext = instructor;
                FillComboBox.FillComboBox.fillComboBoxAddress(comboBoxAddresses);
                FillComboBox.FillComboBox.fillComboBoxGender(comboBoxGender);
            }
        }

        public void getDataFromInputs(TextBox textBoxName, TextBox textBoxLastName, TextBox textBoxPassword, TextBox textBoxJMBG, TextBox textBoxEmail, ComboBox comboBoxAddresses, ComboBox comboBoxGender, 
            out string firstName, out string lastName, out int addressID, out long jmbg, out string gender, out string email, out string password)
        {
            firstName = textBoxName.Text;
            lastName = textBoxLastName.Text;
            string addressToSplit = comboBoxAddresses.SelectedItem.ToString();
            addressID = SearchAddressBY.searchAddressBYstreet(addressToSplit.Split(',')[0]);
            jmbg = long.Parse(textBoxJMBG.Text.ToString());
            gender = comboBoxGender.SelectedItem.ToString();
            email = textBoxEmail.Text;
            password = textBoxPassword.Text;
        }
    }
}
