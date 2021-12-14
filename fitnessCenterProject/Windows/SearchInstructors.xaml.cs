using fitnessCenterProject.Essentials;
using fitnessCenterProject.Essentials.FillComboBox;
using fitnessCenterProject.Models;
using fitnessCenterProject.Validation;
using fitnessCenterProject.Windows.SearchBY;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace fitnessCenterProject.Windows
{
    public partial class SearchInstructors : Window
    {
        private ObservableCollection<Models.Instructor> instructorsDataCollection;
        private string name, lastName, email, addressToSplit;
        private int findAddress;

        public SearchInstructors()
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
        private void searchButton(object sender, RoutedEventArgs e)
        {
            if (UserValidation.searchValidation(textBoxName,textBoxLastName,comboBoxAddress,textBoxEmail))
            {
                getDataFromInputs();
                instructorsDataCollection = SearchUserValidation.checkInputsInstructor(name, lastName, email, findAddress);
                if (instructorsDataCollection.Count != 0)
                {
                    ShowSearchingResultInstructor showResults = new ShowSearchingResultInstructor(instructorsDataCollection);
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
