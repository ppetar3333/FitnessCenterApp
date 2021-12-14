using fitnessCenterProject.Essentials;
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

namespace fitnessCenterProject.Windows.Administrator.AdminAddresses
{
    public partial class UpdateAddress : Window
    {
        private Models.Address foundedAddress;
        private int id, number;
        private string country, city, street;
        public UpdateAddress(int passwordOfAddress)
        {
            InitializeComponent();
            this.id = passwordOfAddress;
            foundedAddress = SearchAddressBY.searchAddressBYid(passwordOfAddress);
            fillInTextBox(foundedAddress);
        }

        private void fillInTextBox(Models.Address foundedAddress)
        {
            countryTextBox.DataContext = foundedAddress;
            cityTextBox.DataContext = foundedAddress;
            streetTextBox.DataContext = foundedAddress;
            numberTextBox.DataContext = foundedAddress;
        }
        private void getDataFrominputs()
        {
            id = foundedAddress.PasswordOfAddress;
            country = countryTextBox.Text;
            city = cityTextBox.Text;
            street = streetTextBox.Text;
            number = int.Parse(numberTextBox.Text);
        }
        private void close(object sender, RoutedEventArgs e)
        {
            showMainWindow();
        }

        private void showMainWindow()
        {
            AdminAddressOptions adminAddressOptions = new AdminAddressOptions();
            adminAddressOptions.Show();
            this.Close();
        }
        private void update(object sender, RoutedEventArgs e)
        {
            if(ModelValidation.addressValidation(countryTextBox, cityTextBox, streetTextBox, numberTextBox))
            {
                getDataFrominputs();
                AllData.Instance.updateAddress(id, street, number, city, country);
                MessageBox.Show("You have successfuly updated address.");
                showMainWindow();
            }
        }
    }
}
