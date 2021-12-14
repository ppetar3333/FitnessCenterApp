using fitnessCenterProject.Essentials;
using fitnessCenterProject.Essentials.ChangeVisibility;
using fitnessCenterProject.Essentials.FillDataGrid;
using fitnessCenterProject.Models;
using fitnessCenterProject.Windows.SearchBY;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace fitnessCenterProject.Windows.Beginner.BeginnerCheckInstructor
{

    public partial class ShowAllInstructors : Window
    {
        private Models.Instructor instructor;
        private string jmbgOfBeginner;
        private ObservableCollection<Training> trainingsCollection;

        public ShowAllInstructors(string jmbgOfUser)
        {
            jmbgOfBeginner = jmbgOfUser;
            InitializeComponent();
            FillDataGrid.fillDataGridInstructor(instructorsInfo);
        }
        private void changeVisibilityInstructors(object sender, EventArgs e)
        {
            ChangeVisibilityDataGrid.changeVisibilityOfInstructor(instructorsInfo);
        }
        private void closeButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void selectButton(object sender, RoutedEventArgs e)
        {
            object selectedInstructor = instructorsInfo.SelectedItem;
            if (selectedInstructor != null)
            {
                instructor = (Models.Instructor)selectedInstructor;
                trainingsCollection = SearchTrainingsBY.findInstructorTraining(instructor.Id);
                if (trainingsCollection.Count == 0)
                {
                    MessageBox.Show("Sorry, but " + instructor.FirstName + " doesn't have trainings yet.");
                }
                else
                {
                    ShowTrainings showTrainings = new ShowTrainings(trainingsCollection, jmbgOfBeginner);
                    showTrainings.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("You need to select column.");
            }
        }
    }
}
