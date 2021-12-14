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

namespace fitnessCenterProject.Windows.SearchByOneCriterion
{
    public partial class InstructorAddress : Window
    {
        private string address;
        private int findAddress;
        private ObservableCollection<Models.Instructor> instructorsDataCollection;

        public InstructorAddress()
        {
            InitializeComponent();
            FillComboBox.fillComboBoxAddress(comboBoxAddress);
        }

        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void getDataFromInputs()
        {
            address = comboBoxAddress.SelectedItem.ToString();
            findAddress = SearchAddressBY.searchAddressBYstreet(address.Split(',')[0]);
        }
        private void search(object sender, RoutedEventArgs e)
        {
            if (UserValidation.searchAddressValidation(comboBoxAddress))
            {
                getDataFromInputs();
                instructorsDataCollection = SearchUserValidation.checkAddressInstructor(findAddress);
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
    }
}
