using fitnessCenterProject.Essentials;
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
        private string name, lastName, email, addressStreet;
        private int findAddress;

        public SearchInstructors()
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
            if (UserValidation.searchUserValidation(textBoxName,textBoxLastName,textBoxAddress,textBoxEmail))
            {
                getDataFromInputs();
                Models.Instructor foundInstructor = SearchUserValidation.checkInputsInstructor(name, lastName, email, findAddress);
                instructorsDataCollection = new ObservableCollection<Models.Instructor>();
                instructorsDataCollection.Add(foundInstructor);
                if (foundInstructor != null)
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
