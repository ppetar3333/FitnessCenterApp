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

namespace fitnessCenterProject.Windows.Administrator.AdminFitnessCenter
{
    public partial class UpdateFitnessCenter : Window
    {
        private Models.FitnessCenter foundFitnessCenter;
        private int id, addressID;
        private string name;
        public UpdateFitnessCenter(int id)
        {
            InitializeComponent();
            foundFitnessCenter = SearchFitnessCenterBY.searchFitnessCenterBYid(id);
            fillInData(foundFitnessCenter);
        }

        private void fillInData(Models.FitnessCenter foundFitnessCenter)
        {
            textBoxName.DataContext = foundFitnessCenter;
            FillComboBox.fillComboBoxAddress(comboBoxAddresses);
        }

        private void closeButton(object sender, RoutedEventArgs e)
        {
            showMainWindow();
        }

        private void showMainWindow()
        {
            AdminFitnessCenterOptions adminFitnessCenterOptions = new AdminFitnessCenterOptions();
            adminFitnessCenterOptions.Show();
            this.Close();
        }
        private void getDataFromInputs()
        {
            id = foundFitnessCenter.PasswordOfFitnessCenter;
            name = textBoxName.Text;
            addressID = SearchAddressBY.searchAddressBYstreet(comboBoxAddresses.SelectedItem.ToString());
        }
        private void changeButton(object sender, RoutedEventArgs e)
        {
            if (ModelValidation.fitnessCenterValidation(textBoxName, comboBoxAddresses))
            {
                getDataFromInputs();
                AllData.Instance.updateFitnessCenter(id, name, addressID);
                MessageBox.Show("You have successfuly changed Fitness Center.");
                showMainWindow();
            }
        }
    }
}
