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

namespace fitnessCenterProject.Windows.Administrator.AdminInstructor
{
    public partial class UpdateInstructor : Window
    {
        private Models.Instructor foundInstructor;
        private readonly FillInputs fillInputs = new FillInputs();
        private int id, addressID;
        private long jmbg;
        private string firstName, lastName, gender, email, password;
        public UpdateInstructor(string jmbgOfInstructor)
        {
            InitializeComponent();
            foundInstructor = SearchInstructorBY.searchInstructorBYjmbg(jmbgOfInstructor);
            fillInputs.fillInInputs(foundInstructor, textBoxName, textBoxLastName, textBoxPassword, textBoxJMBG, textBoxEmail, comboBoxAddresses, comboBoxGender);
        }
        private void closeButton(object sender, RoutedEventArgs e)
        {
            showMainWindow();
        }
        private void showMainWindow()
        {
            AdminInstructorOptions adminInstructorOptions = new AdminInstructorOptions();
            adminInstructorOptions.Show();
            this.Close();
        }
        private void changeButton(object sender, RoutedEventArgs e)
        {
            if (UserValidation.updateUserValidation(textBoxName, comboBoxGender, textBoxLastName, textBoxPassword, comboBoxAddresses, textBoxEmail))
            {
                id = foundInstructor.Id;
                fillInputs.getDataFromInputs(textBoxName, textBoxLastName, textBoxPassword, textBoxJMBG, textBoxEmail, comboBoxAddresses, comboBoxGender, out firstName, out lastName, out addressID, out jmbg, out gender, out email, out password);
                AllData.Instance.updateInstructor(id, firstName, lastName, jmbg, gender, addressID, email, password);
                MessageBox.Show("You have successfuly changed your data.");
                showMainWindow();
            }
        }
    }
}
