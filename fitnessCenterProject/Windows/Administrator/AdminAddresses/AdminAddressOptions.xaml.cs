using fitnessCenterProject.Essentials;
using fitnessCenterProject.Essentials.ChangeVisibility;
using fitnessCenterProject.Essentials.FillDataGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace fitnessCenterProject.Windows.Administrator.AdminAddresses
{
    public partial class AdminAddressOptions : Window
    {
        private Models.Address address;
        public AdminAddressOptions()
        {
            InitializeComponent();
            FillDataGrid.fillDataGridAddresses(addressesInfo);
            FillDataGrid.fillDataGridAddresses(addressesInfo);
        }

        private void changeVisibilityAddresses(object sender, EventArgs e)
        {
            ChangeVisibilityDataGrid.changeVisibilityOfAddress(addressesInfo);
        }

        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void createAddress(object sender, RoutedEventArgs e)
        {
            CreateAddress createAddress = new CreateAddress();
            createAddress.Show();
            this.Close();
        }

        private void updateAddress(object sender, RoutedEventArgs e)
        {
            var selectedAddress = addressesInfo.SelectedItem;
            if (selectedAddress != null)
            {
                address = (Models.Address)selectedAddress;
                UpdateAddress updateAddress = new UpdateAddress(address.PasswordOfAddress);
                updateAddress.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("You need to select column.");
            }
        }
        private void deleteAddress(object sender, RoutedEventArgs e)
        {
            object selectedAddress = addressesInfo.SelectedItem;
            if (selectedAddress != null)
            {
                address = (Models.Address) selectedAddress;
                if (CheckAddressWithUsers.checkAddressBeginner(address.PasswordOfAddress) ||
                    CheckAddressWithUsers.checkAddressAdmin(address.PasswordOfAddress) ||
                    CheckAddressWithUsers.checkAddressInstructor(address.PasswordOfAddress) ||
                    CheckAddressWithUsers.checkAddressFitnessCenter(address.PasswordOfAddress))
                {
                    MessageBox.Show("You can not delete address because some of users have it.");
                }
                else
                {
                    if (MessageBox.Show("Do you really want to delete this address?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        AllData.Instance.deleteAddress(address.PasswordOfAddress);
                        AllData.Instance.addresses.Remove(address);
                        FillDataGrid.fillDataGridAddresses(addressesInfo);
                        MessageBox.Show("You have successfuly deleted address.");
                        FillDataGrid.fillDataGridAddresses(addressesInfo);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select column.");
            }
        }
    }
}
