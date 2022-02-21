using fitnessCenterProject.Essentials;
using fitnessCenterProject.Essentials.FillInputs;
using fitnessCenterProject.Validation;
using fitnessCenterProject.Windows.SearchBY;
using System;
using System.Collections.Generic;
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

namespace fitnessCenterProject.Windows.Administrator.AdminOptions
{
    public partial class UpdateAdmin : Window
    {
        private Models.Admin foundedAdmin;
        private readonly FillInputs fillInputs = new FillInputs();
        private int id, addressID;
        private string firstName, lastName, gender, email, password;
        private long jmbg;
        private string loggedInAdmin;
        public UpdateAdmin(string jmbgOfUser, string loggedInAdmin)
        {
            InitializeComponent();
            this.loggedInAdmin = loggedInAdmin;
            foundedAdmin = SearchAdminBY.searchAdminBYjmbg(jmbgOfUser);
            fillInputs.fillInInputs(foundedAdmin, textBoxName, textBoxLastName, textBoxPassword, textBoxJMBG, textBoxEmail, comboBoxAddresses, comboBoxGender);
        }
        private void closeButton(object sender, RoutedEventArgs e)
        {
            showMainWindow();
        }

        private void showMainWindow()
        {
            AdministratorWindow administrator = new AdministratorWindow(loggedInAdmin);
            administrator.Show();
            this.Close();
        }
        private void changeButton(object sender, RoutedEventArgs e)
        {
            if (UserValidation.updateUserValidation(textBoxName, comboBoxGender, textBoxLastName, textBoxPassword, comboBoxAddresses, textBoxEmail))
            {
                id = foundedAdmin.Id;
                fillInputs.getDataFromInputs(textBoxName, textBoxLastName, textBoxPassword, textBoxJMBG, textBoxEmail, comboBoxAddresses, comboBoxGender, out firstName, out lastName, out addressID, out jmbg, out gender, out email, out password);
                AllData.Instance.updateAdmin(id, firstName, lastName, jmbg, gender, addressID, email, password);
                MessageBox.Show("You have successfuly changed admin.");
                showMainWindow();
            }
        }
    }
}
