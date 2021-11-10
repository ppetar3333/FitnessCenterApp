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

namespace fitnessCenterProject.Windows.Beginner
{
    public partial class ChangeBeginnerWindow : Window
    {
        private Models.Beginner foundBeginner;
        private int id, addressID;
        private string firstName, lastName, gender, email, password;
        private long jmbg;
        public ChangeBeginnerWindow(string jmbgOfUser)
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
            showBeginnerMainWindow();
        }

        private void showBeginnerMainWindow()
        {
            BeginnerMainWindow beginnerMainWindow = new BeginnerMainWindow(foundBeginner.Jmbg.ToString());
            beginnerMainWindow.Show();
            this.Close();
        }
        private void getDataFromInputs()
        {
            id = foundBeginner.Id;
            firstName = textBoxName.Text;
            lastName = textBoxLastName.Text;
            addressID = SearchAddressBY.searchAddressBYstreet(comboBoxAddresses.SelectedItem.ToString());
            jmbg = long.Parse(textBoxJMBG.Text.ToString());
            gender = comboBoxGender.SelectedItem.ToString();
            email = textBoxEmail.Text;
            password = textBoxPassword.Text;
        }
        private void changeButton(object sender, RoutedEventArgs e)
        {
            if(UserValidation.updateUserValidation(textBoxName, comboBoxGender, textBoxLastName, textBoxPassword, comboBoxAddresses, textBoxEmail))
            {
                getDataFromInputs();
                AllData.Instance.updateBeginner(id, firstName, lastName, jmbg, gender, addressID, email, password);
                MessageBox.Show("You have successfuly changed your data.");
                showBeginnerMainWindow();
            }
        }
    }
}
