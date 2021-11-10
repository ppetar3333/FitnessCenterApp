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

namespace fitnessCenterProject.Windows.Administrator.AdminBeginner
{
    public partial class CreateBeginner : Window
    {
        private int id, addressID;
        private string firstName, lastName, gender, email, password;
        private long jmbgString;

        public CreateBeginner()
        {
            InitializeComponent();
            FillComboBox.fillComboBoxAddress(comboBoxAddresses);
            FillComboBox.fillComboBoxGender(comboBoxEnum);
        }
        private void close(object sender, RoutedEventArgs e)
        {
            adminMainWindow();
            this.Close();
        }
        private static void adminMainWindow()
        {
            AdminBeginnerOptions adminBeginnerOptions = new AdminBeginnerOptions();
            adminBeginnerOptions.Show();
        }
        private void getDataFromInputs()
        {
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
                id = GenerateNewID.generateNewIDForBeginner();
                getDataFromInputs();
                AllData.Instance.createBeginner(id, firstName, lastName, jmbgString, gender, addressID, email, password);
                MessageBox.Show("You have successfuly added new beginner.");
                adminMainWindow();
                this.Close();
            }
        }
    }
}
