using fitnessCenterProject.Essentials;
using fitnessCenterProject.Models;
using fitnessCenterProject.Validation;
using fitnessCenterProject.Windows.SearchBY;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace fitnessCenterProject.Windows.Instructor.InstructorCheckTrainings
{
    public partial class CheckTrainings : Window
    {
        private string jmbgOfInstructor;
        private ObservableCollection<Training> foundedTrainings;
        private Models.Instructor instructor;
        private string date;
        public CheckTrainings(string jmbgOfUser)
        {
            jmbgOfInstructor = jmbgOfUser;
            InitializeComponent();
        }
        private void checkTrainings(object sender, RoutedEventArgs e)
        {
            if(ModelValidation.checkTrainingValidation(selectedDate))
            {
                instructor = SearchInstructorBY.searchInstructorBYjmbg(jmbgOfInstructor);
                date = selectedDate.Text;
                foundedTrainings = SearchTrainingsBY.findTrainingBYdate(date, instructor.Id);
                if (foundedTrainings.Count == 0)
                {
                    MessageBox.Show("Sorry, but there isn't trainings for this date.");
                }
                else
                {
                    ShowFoundedTrainings showFoundedTrainings = new ShowFoundedTrainings(foundedTrainings);
                    showFoundedTrainings.ShowDialog();
                }
            }
        }
        private void closeButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
