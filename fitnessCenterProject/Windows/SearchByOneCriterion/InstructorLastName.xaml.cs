using fitnessCenterProject.Validation;
using fitnessCenterProject.Windows.Administrator.SearchAdmin;
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
    public partial class InstructorLastName : Window
    {
        private string lastName;
        private ObservableCollection<Models.Instructor> instructorsDataCollection;

        public InstructorLastName()
        {
            InitializeComponent();
        }

        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void getDataFromInputs()
        {
            lastName = textBoxData.Text;
        }
        private void search(object sender, RoutedEventArgs e)
        {
            if (UserValidation.searchLastNameValidation(textBoxData))
            {
                getDataFromInputs();
                instructorsDataCollection = SearchUserValidation.checkLastNameInstructor(lastName);
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
