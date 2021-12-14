using fitnessCenterProject.Essentials.FillComboBox;
using fitnessCenterProject.Validation;
using fitnessCenterProject.Windows.Administrator.SearchAdmin;
using fitnessCenterProject.Windows.SearchBY;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace fitnessCenterProject.Windows.SearchByOneCriterion
{
    public partial class BeginnerAddress : Window
    {
        private ObservableCollection<Models.Beginner> beginnersDataCollection;
        private string address;
        private int findAddress;
        public BeginnerAddress()
        {
            InitializeComponent();
            FillComboBox.fillComboBoxAddress(comboBoxAddress);
        }
        private void getDataFromInputs()
        {
            address = comboBoxAddress.SelectedItem.ToString();
            findAddress = SearchAddressBY.searchAddressBYstreet(address.Split(',')[0]);
        }
        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void search(object sender, RoutedEventArgs e)
        {
            if (UserValidation.searchAddressValidation(comboBoxAddress))
            {
                getDataFromInputs();
                beginnersDataCollection = SearchUserValidation.checkAddressBeginner(findAddress);
                if (beginnersDataCollection.Count != 0)
                {
                    ShowSearchingResultBeginner showResults = new ShowSearchingResultBeginner(beginnersDataCollection);
                    showResults.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Sorry, beginner with this data can not be found.");
                }
            }
        }
    }
}
