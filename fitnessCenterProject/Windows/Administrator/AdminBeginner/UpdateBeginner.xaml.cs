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
    public partial class UpdateBeginner : Window
    {
        private Models.Beginner foundBeginner;
        public UpdateBeginner(string jmbgOfUser)
        {
            InitializeComponent();
            foundBeginner = SearchBeginnerBY.searchBeginnerByJMBG(jmbgOfUser);
            fillInData(foundBeginner);
        }
        private void fillInData(Models.Beginner foundedBeginner)
        {
            textBoxName.DataContext = foundedBeginner;
            textBoxLastName.DataContext = foundedBeginner;
            textBoxPassword.DataContext = foundedBeginner;
            textBoxJMBG.DataContext = foundedBeginner;
            textBoxEmail.DataContext = foundedBeginner;
            FillComboBox.fillComboBoxAddress(comboBoxAddresses);
            FillComboBox.fillComboBoxGender(comboBoxGender);
        }

        private void closeButton(object sender, RoutedEventArgs e)
        {
            showMainWindow();
        }

        private void showMainWindow()
        {
            AdminBeginnerOptions adminBeginnerOptions = new AdminBeginnerOptions();
            adminBeginnerOptions.Show();
            this.Close();
        }

        private void changeButton(object sender, RoutedEventArgs e)
        {
            if (UserValidation.updateUserValidation(textBoxName, comboBoxGender, textBoxLastName, textBoxPassword, comboBoxAddresses, textBoxEmail))
            {
                int id = foundBeginner.Id;
                string firstName = textBoxName.Text;
                string lastName = textBoxLastName.Text;
                int addressID = SearchAddressBY.searchAddressBYstreet(comboBoxAddresses.SelectedItem.ToString());
                long jmbg = long.Parse(textBoxJMBG.Text.ToString());
                string gender = comboBoxGender.SelectedItem.ToString();
                string email = textBoxEmail.Text;
                string password = textBoxPassword.Text;
                AllData.Instance.updateBeginner(id, firstName, lastName, jmbg, gender, addressID, email, password);
                MessageBox.Show("You have successfuly changed beginner.");
                showMainWindow();
            }
        }
    }
}
