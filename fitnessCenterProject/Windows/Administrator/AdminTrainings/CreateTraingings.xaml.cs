using fitnessCenterProject.Essentials;
using fitnessCenterProject.Essentials.FillComboBox;
using fitnessCenterProject.Validation;
using fitnessCenterProject.Windows.SearchBY;
using System;
using System.Collections.Generic;
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

namespace fitnessCenterProject.Windows.Administrator.AdminTrainings
{
    public partial class CreateTraingings : Window
    {
        private int trainingID, duration, instructorID;
        private DateTime dateOfTraining;
        string startingTime;
        public CreateTraingings()
        {
            InitializeComponent();
            FillComboBox.fillComboBoxInstructor(instructorsComboBox);
        }
        private void showAdminTrainingOptions()
        {
            AdminTrainingsOptions adminTrainingsOptions = new AdminTrainingsOptions();
            adminTrainingsOptions.Show();
        }
        private void close(object sender, RoutedEventArgs e)
        {
            showAdminTrainingOptions();
            this.Close();
        }
        private void getDataFromInputs()
        {
            trainingID = GenerateNewID.generateNewIDForTraining();
            dateOfTraining = DateTime.Now;
            startingTime = startTime.Text;
            duration = int.Parse(durationOfTraining.Text);
            instructorID = SearchInstructorBY.searchInstructorBYname(instructorsComboBox.SelectedItem.ToString());
        }
        private void create(object sender, RoutedEventArgs e)
        {
            if (ModelValidation.createTrainingValidation(startTime, durationOfTraining,instructorsComboBox))
            {
                getDataFromInputs();
                AllData.Instance.createTraining(trainingID, dateOfTraining, startingTime, duration, instructorID);
                MessageBox.Show("You have successfuly added new training.");
                showAdminTrainingOptions();
                this.Close();
            }
        }
    }
}
