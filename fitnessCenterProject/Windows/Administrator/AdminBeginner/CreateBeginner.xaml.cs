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
    public partial class CreateBeginner : Window
    {
        private readonly FillInputs fillInputs = new FillInputs();
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
        }
        private void adminMainWindow()
        {
            AdminBeginnerOptions adminBeginnerOptions = new AdminBeginnerOptions();
            adminBeginnerOptions.Show();
            this.Close();
        }
        private void create(object sender, RoutedEventArgs e)
        {
            if (UserValidation.createUserValidation(textBoxName,textBoxLastName,textBoxJMBG,comboBoxEnum,textBoxPassword,comboBoxAddresses,textBoxEmail))
            {
                id = GenerateNewID.generateNewIDForBeginner();
                fillInputs.getDataFromInputs(textBoxName, textBoxLastName, textBoxPassword, textBoxJMBG, textBoxEmail, comboBoxAddresses, comboBoxEnum, out firstName, out lastName, out addressID, out jmbgString, out gender, out email, out password);
                AllData.Instance.createBeginner(id, firstName, lastName, jmbgString, gender, addressID, email, password);
                MessageBox.Show("You have successfuly added new beginner.");
                adminMainWindow();
            }
        }
    }
}
