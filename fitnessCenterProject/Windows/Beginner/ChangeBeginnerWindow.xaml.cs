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

namespace fitnessCenterProject.Windows.Beginner
{
    public partial class ChangeBeginnerWindow : Window
    {
        private Models.Beginner foundBeginner;
        private readonly FillInputs fillInputs = new FillInputs();
        private int id, addressID;
        private long jmbg;
        private string firstName, lastName, gender, email, password;

        public ChangeBeginnerWindow(string jmbgOfUser)
        {
            InitializeComponent();
            foundBeginner = SearchBeginnerBY.searchBeginnerByJMBG(jmbgOfUser);
            fillInputs.fillInInputs(foundBeginner, textBoxName, textBoxLastName, textBoxPassword, textBoxJMBG, textBoxEmail, comboBoxAddresses, comboBoxGender);
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
        private void changeButton(object sender, RoutedEventArgs e)
        {
            if(UserValidation.updateUserValidation(textBoxName, comboBoxGender, textBoxLastName, textBoxPassword, comboBoxAddresses, textBoxEmail))
            {
                id = foundBeginner.Id;
                fillInputs.getDataFromInputs(textBoxName, textBoxLastName, textBoxPassword, textBoxJMBG, textBoxEmail, comboBoxAddresses, comboBoxGender, out firstName, out lastName, out addressID, out jmbg, out gender, out email, out password);
                AllData.Instance.updateBeginner(id, firstName, lastName, jmbg, gender, addressID, email, password);
                MessageBox.Show("You have successfuly changed your data.");
                showBeginnerMainWindow();
            }
        }
    }
}
