using fitnessCenterProject.Enums;
using fitnessCenterProject.Essentials;
using fitnessCenterProject.Essentials.FillComboBox;
using fitnessCenterProject.Essentials.FillInputs;
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
        private readonly FillInputs fillInputs = new FillInputs();
        private int id, addressID;
        private string firstName, lastName, gender, email, password;
        private long jmbg;
        public UpdateBeginner(string jmbgOfUser)
        {
            InitializeComponent();
            foundBeginner = SearchBeginnerBY.searchBeginnerByJMBG(jmbgOfUser);
            fillInputs.fillInInputs(foundBeginner, textBoxName, textBoxLastName, textBoxPassword, textBoxJMBG, textBoxEmail, comboBoxAddresses, comboBoxGender);
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
                id = foundBeginner.Id;
                fillInputs.getDataFromInputs(textBoxName, textBoxLastName, textBoxPassword, textBoxJMBG, textBoxEmail, comboBoxAddresses, comboBoxGender, out firstName, out lastName, out addressID, out jmbg, out gender, out email, out password);
                AllData.Instance.updateBeginner(id, firstName, lastName, jmbg, gender, addressID, email, password);
                MessageBox.Show("You have successfuly changed beginner.");
                showMainWindow();
            }
        }
    }
}
