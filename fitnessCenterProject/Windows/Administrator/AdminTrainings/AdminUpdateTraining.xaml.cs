using fitnessCenterProject.Essentials;
using fitnessCenterProject.Essentials.FillComboBox;
using fitnessCenterProject.Validation;
using fitnessCenterProject.Windows.Administrator.AdminBeginner;
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

namespace fitnessCenterProject.Windows.Administrator.AdminTrainings
{
    public partial class AdminUpdateTraining : Window
    {
        private Models.Training training;
        private int id;
        public AdminUpdateTraining(string trainingID)
        {
            InitializeComponent();
            training = SearchTrainingsBY.findByID(trainingID);
            textBoxDate.DataContext = training;
            textBoxStartTime.DataContext = training;
            textBoxDuration.DataContext = training;
            textBoxTrainingStatus.DataContext = training;
            textBoxBeginner.DataContext = training;
            FillComboBox.fillComboBoxInstructor(comboBoxInstructor);
        }
        private void closeButton(object sender, RoutedEventArgs e)
        {
            showMainWindow();
        }

        private void showMainWindow()
        {
            AdminTrainingsOptions adminTrainingsOptions = new AdminTrainingsOptions();
            adminTrainingsOptions.Show();
            this.Close();
        }

        private void changeButton(object sender, RoutedEventArgs e)
        {
            if (ModelValidation.createTrainingValidation(textBoxStartTime, textBoxDuration, comboBoxInstructor))
            {
                id = training.PasswordOfTraining;
                int instructor = SearchInstructorBY.searchInstructorBYname(comboBoxInstructor.SelectedItem.ToString());
                training.InstructorID = instructor;
                AllData.Instance.updateTraining(training);
                MessageBox.Show("You have successfuly changed training.");
                showMainWindow();
            }
        }
    }
}
