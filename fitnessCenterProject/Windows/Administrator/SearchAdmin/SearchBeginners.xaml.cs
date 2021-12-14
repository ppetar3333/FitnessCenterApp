using fitnessCenterProject.Essentials;
using fitnessCenterProject.Essentials.FillComboBox;
using fitnessCenterProject.Validation;
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

namespace fitnessCenterProject.Windows.Administrator.SearchAdmin
{
    public partial class SearchBeginners : Window
    {
        private ObservableCollection<Models.Beginner> beginnersDataCollection;
        private string name, lastName, email, addressToSplit;
        private int findAddress;

        public SearchBeginners()
        {
            InitializeComponent();
            FillComboBox.fillComboBoxAddress(comboBoxAddress);
        }
        private void getDataFromInputs()
        {
            name = textBoxName.Text;
            lastName = textBoxLastName.Text;
            email = textBoxEmail.Text;
            if (comboBoxAddress.SelectedIndex != -1)
            {
                addressToSplit = comboBoxAddress.SelectedItem.ToString();
                findAddress = SearchAddressBY.searchAddressBYstreet(addressToSplit.Split(',')[0]);
            }
            else
            {
                findAddress = 0;
            }
        }
        private void closeButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void searchButton(object sender, RoutedEventArgs e)
        {
            if (UserValidation.searchValidation(textBoxName,textBoxLastName,comboBoxAddress,textBoxEmail))
            {
                getDataFromInputs();
                beginnersDataCollection = SearchUserValidation.checkInputsBeginner(name, lastName, email, findAddress);
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
