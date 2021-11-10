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

namespace fitnessCenterProject.Windows.Instructor
{
    public partial class ChangeInstructorWindow : Window
    {
        private Models.Instructor foundInstructor;
        private int id, addressID;
        private long jmbg;
        private string firstName, lastName, gender, email, password;
        public ChangeInstructorWindow(string jmbgOfInstructor)
        {
            InitializeComponent();
            foundInstructor = SearchInstructorBY.searchInstructorBYjmbg(jmbgOfInstructor);
            fillInData(foundInstructor);
        }

        private void fillInData(Models.Instructor foundedInstructor)
        {
            textBoxName.DataContext = foundedInstructor;
            textBoxLastName.DataContext = foundedInstructor;
            textBoxJMBG.DataContext = foundedInstructor;
            textBoxEmail.DataContext = foundedInstructor;
            textBoxPassword.DataContext = foundedInstructor;
            FillComboBox.fillComboBoxAddress(comboBoxAddresses);
            FillComboBox.fillComboBoxGender(comboBoxGender);
        }

        private void closeButton(object sender, RoutedEventArgs e)
        {
            showInstructorMainWindow();
        }

        private void showInstructorMainWindow()
        {
            InstructorMainWindow instructorMainWindow = new InstructorMainWindow(foundInstructor.Jmbg.ToString());
            instructorMainWindow.Show();
            this.Close();
        }
        private void getChangedData()
        {
            id = foundInstructor.Id;
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
                getChangedData();
                AllData.Instance.updateInstructor(id, firstName, lastName, jmbg, gender, addressID, email, password);
                MessageBox.Show("You have successfuly changed your data.");
                showInstructorMainWindow();
            }
        }
    }
}
