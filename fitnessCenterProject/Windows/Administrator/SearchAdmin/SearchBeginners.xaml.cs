using fitnessCenterProject.Essentials;
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
        private Models.Beginner foundBeginner;
        private string name, lastName, email, addressStreet;
        private int findAddress;

        public SearchBeginners()
        {
            InitializeComponent();
        }
        private void getDataFromInputs()
        {
            name = textBoxName.Text;
            lastName = textBoxLastName.Text;
            email = textBoxEmail.Text;
            addressStreet = textBoxAddress.Text;
            findAddress = SearchAddressBY.searchAddressBYstreet(addressStreet);
        }
        private void searchButton(object sender, RoutedEventArgs e)
        {
            if (UserValidation.searchUserValidation(textBoxName, textBoxLastName, textBoxAddress, textBoxEmail))
            {
                getDataFromInputs();
                foundBeginner = SearchUserValidation.checkInputsBeginner(name, lastName, email, findAddress);
                beginnersDataCollection = new ObservableCollection<Models.Beginner>();
                beginnersDataCollection.Add(foundBeginner);
                if (foundBeginner != null)
                {
                    ShowSearchingResultBeginner showResults = new ShowSearchingResultBeginner(beginnersDataCollection);
                    showResults.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Sorry, instructor with this data can not be found.");
                }
            }
        }
        private void closeButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
