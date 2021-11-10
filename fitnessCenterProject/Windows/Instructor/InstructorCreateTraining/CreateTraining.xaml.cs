using fitnessCenterProject.Essentials;
using fitnessCenterProject.Validation;
using fitnessCenterProject.Windows.SearchBY;
using System;
using System.Collections.Generic;
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

namespace fitnessCenterProject.Windows.Instructor.InstructorCreateTraining
{
    public partial class CreateTraining : Window
    {
        private string jmbgOfInstructor, startingTime;
        private int instructorID, duration, trainingID;
        DateTime dateOfTraining;
        private Models.Instructor instructor;
        public CreateTraining(string jmbgOfInstructor)
        {
            this.jmbgOfInstructor = jmbgOfInstructor;
            InitializeComponent();
        }

        private void close(object sender, RoutedEventArgs e)
        {
            showInstructorMainWindow();
            this.Close();
        }

        private void showInstructorMainWindow()
        {
            InstructorMainWindow instructorMainWindow = new InstructorMainWindow(jmbgOfInstructor);
            instructorMainWindow.Show();
        }
        private void getDataFromInput()
        {
            trainingID = GenerateNewID.generateNewIDForTraining();
            dateOfTraining = DateTime.Now;
            startingTime = startTime.Text;
            duration = int.Parse(durationOfTraining.Text);
            instructor = SearchInstructorBY.searchInstructorBYjmbg(jmbgOfInstructor);
            instructorID = instructor.Id;
        }

        private void create(object sender, RoutedEventArgs e)
        {
            if(ModelValidation.createTrainingInstructorValidation(startTime, durationOfTraining))
            {
                getDataFromInput();
                AllData.Instance.createTraining(trainingID, dateOfTraining, startingTime, duration, instructorID);
                MessageBox.Show("You have successfuly added new training.");
                showInstructorMainWindow();
                this.Close();
            }
        }
    }
}
