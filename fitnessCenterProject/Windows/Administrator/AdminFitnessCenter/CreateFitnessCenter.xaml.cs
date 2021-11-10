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
    public partial class CreateFitnessCenter : Window
    {
        private int id, addressID;
        private string nameOfCenter;
        public CreateFitnessCenter()
        {
            InitializeComponent();
            fillInComboBox();
        }

        private void fillInComboBox()
        {
            FillComboBox.fillComboBoxAddress(addressComboBox);
        }

        private void close(object sender, RoutedEventArgs e)
        {
            showMainWindow();
            this.Close();
        }

        private static void showMainWindow()
        {
            AdminFitnessCenterOptions adminFitnessCenterOptions = new AdminFitnessCenterOptions();
            adminFitnessCenterOptions.Show();
        }
        private void getDataFromInputs()
        {
            id = GenerateNewID.generateNewIDForFitnessCenter();
            nameOfCenter = nameTextBox.Text;
            addressID = SearchAddressBY.searchAddressBYstreet(addressComboBox.SelectedItem.ToString());
        }
        private void create(object sender, RoutedEventArgs e)
        {
            if(ModelValidation.fitnessCenterValidation(nameTextBox, addressComboBox))
            {
                getDataFromInputs();
                AllData.Instance.createFitnessCenter(id, nameOfCenter, addressID);
                MessageBox.Show("You have successfuly added new Fitness Center.");
                showMainWindow();
                this.Close();
            }
        }
    }
}
