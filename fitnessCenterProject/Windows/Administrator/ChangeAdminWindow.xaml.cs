using fitnessCenterProject.CRUD;
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

namespace fitnessCenterProject.Windows.Administrator
{
    public partial class ChangeAdminWindow : Window
    {
        private Models.Admin foundAdmin;
        private int id, addressID;
        private long jmbg;
        private string firstName, lastName, gender, email, password;
        public ChangeAdminWindow(string jmbgOfUser)
        {
            InitializeComponent();
            foundAdmin = SearchAdminBY.searchAdminBYjmbg(jmbgOfUser);
            fillInData(foundAdmin);
        }
        private void fillInData(Models.Admin foundedAdmin)
        {
            textBoxName.DataContext = foundedAdmin;
            textBoxLastName.DataContext = foundedAdmin;
            textBoxJMBG.DataContext = foundedAdmin;
            textBoxEmail.DataContext = foundedAdmin;
            textBoxPassword.DataContext = foundedAdmin;
            FillComboBox.fillComboBoxAddress(comboBoxAddresses);
            FillComboBox.fillComboBoxGender(comboBoxGender);
        }
        private void closeButton(object sender, RoutedEventArgs e)
        {
            showAdminMainWindow();
        }

        private void showAdminMainWindow()
        {
            AdministratorMainWindow administratorMainWindow = new AdministratorMainWindow(foundAdmin.Jmbg.ToString());
            administratorMainWindow.Show();
            this.Close();
        }
        private void getDataFromInputs()
        {
            id = foundAdmin.Id;
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
            if (UserValidation.updateUserValidation(textBoxName, comboBoxGender, textBoxLastName, textBoxPassword, comboBoxAddresses, textBoxEmail))
            {
                getDataFromInputs();
                AllData.Instance.updateAdmin(id, firstName, lastName, jmbg, gender, addressID, email, password);
                MessageBox.Show("You have successfuly changed your data.");
                showAdminMainWindow();
            }
        }
    }
}
