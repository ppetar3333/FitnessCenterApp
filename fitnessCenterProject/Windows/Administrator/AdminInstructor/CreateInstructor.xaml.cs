using fitnessCenterProject.Enums;
using fitnessCenterProject.Essentials;
using fitnessCenterProject.Essentials.FillComboBox;
using fitnessCenterProject.Validation;
using fitnessCenterProject.Windows.SearchBY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace fitnessCenterProject.Windows.Administrator.AdminInstructor
{
    public partial class CreateInstructor : Window
    {
        private int id, addressID;
        private string firstName, lastName, gender, email, password;
        private long jmbgString;
        public CreateInstructor()
        {
            InitializeComponent();
            FillComboBox.fillComboBoxGender(comboBoxEnum);
            FillComboBox.fillComboBoxAddress(comboBoxAddresses);
        }

        private void close(object sender, RoutedEventArgs e)
        {
            adminMainWindow();
        }

        private void adminMainWindow()
        {
            AdminInstructorOptions adminInstructorOptions = new AdminInstructorOptions();
            adminInstructorOptions.Show();
            this.Close();
        }
        private void getDataFromInputs()
        {
            id = GenerateNewID.generateNewIDForInstructor();
            firstName = textBoxName.Text;
            lastName = textBoxLastName.Text;
            jmbgString = long.Parse(textBoxJMBG.Text.ToString());
            gender = comboBoxEnum.SelectedItem.ToString();
            addressID = SearchAddressBY.searchAddressBYstreet(comboBoxAddresses.SelectedItem.ToString());
            email = textBoxEmail.Text;
            password = textBoxPassword.Text;
        }
        private void create(object sender, RoutedEventArgs e)
        {
            if (UserValidation.createUserValidation(textBoxName,textBoxLastName,textBoxJMBG,comboBoxEnum,textBoxPassword,comboBoxAddresses,textBoxEmail))
            {
                getDataFromInputs();
                AllData.Instance.createInstructor(id, firstName, lastName, jmbgString, gender, addressID, email, password);
                MessageBox.Show("You have successfuly added new instructor.");
                adminMainWindow();
            }
        }
    }
}
