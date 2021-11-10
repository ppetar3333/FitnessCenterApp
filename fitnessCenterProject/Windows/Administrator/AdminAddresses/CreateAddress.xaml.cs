using fitnessCenterProject.Essentials;
using fitnessCenterProject.Validation;
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

namespace fitnessCenterProject.Windows.Administrator.AdminAddresses
{
    public partial class CreateAddress : Window
    {
        private int id;
        private string street, number, city, country;
        public CreateAddress()
        {
            InitializeComponent();
        }

        private void close(object sender, RoutedEventArgs e)
        {
            showMainWindow();
            this.Close();
        }
        private static void showMainWindow()
        {
            AdminAddressOptions adminAddressOptions = new AdminAddressOptions();
            adminAddressOptions.Show();
        }
        private void getDataFromInputs()
        {
            id = GenerateNewID.generateNewIDForAddresses();
            street = streetTextBox.Text;
            number = numberTextBox.Text;
            city = cityTextBox.Text;
            country = countryTextBox.Text;
        }
        private void create(object sender, RoutedEventArgs e)
        {
            if(ModelValidation.addressValidation(countryTextBox, cityTextBox, streetTextBox, numberTextBox))
            {
                getDataFromInputs();
                AllData.Instance.createAddress(id, street, number, city, country);
                MessageBox.Show("You have successfuly added new address!");
                showMainWindow();
                this.Close();
            }
        }
    }
}
