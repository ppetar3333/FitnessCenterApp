using fitnessCenterProject.Essentials;
using fitnessCenterProject.Essentials.ChangeVisibility;
using fitnessCenterProject.Essentials.FillDataGrid;
using System;
using System.Collections.Generic;
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

namespace fitnessCenterProject.Windows.Administrator.AdminTrainings
{
    public partial class AdminTrainingsOptions : Window
    {
        private Models.Training training;
        public AdminTrainingsOptions()
        {
            InitializeComponent();
            FillDataGrid.fillDataGridTraining(trainingsInfo);
            FillDataGrid.fillDataGridTraining(trainingsInfo);
        }

        private void changeVisibilityTrainings(object sender, EventArgs e)
        {
            ChangeVisibilityDataGrid.changeVisibilityOfTrainings(trainingsInfo);
        }
        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void createTraining(object sender, RoutedEventArgs e)
        {
            CreateTraingings createTraingings = new CreateTraingings();
            createTraingings.Show();
            this.Close();
        }

        private void deleteTraining(object sender, RoutedEventArgs e)
        {
            object selectedTraining = trainingsInfo.SelectedItem;
            if (selectedTraining != null)
            {
                if (MessageBox.Show("Do you really want to delete this training?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    training = (Models.Training)selectedTraining;
                    AllData.Instance.deleteTraining(training.PasswordOfTraining);
                    AllData.Instance.trainings.Remove(training);
                    FillDataGrid.fillDataGridTraining(trainingsInfo);
                    MessageBox.Show("You have successfuly deleted training.");
                    FillDataGrid.fillDataGridTraining(trainingsInfo);
                }
            }
            else
            {
                MessageBox.Show("Please select column.");
            }
        }

        private void updateTraining(object sender, RoutedEventArgs e)
        {
            object selectedTraining = trainingsInfo.SelectedItem;
            if (selectedTraining != null)
            {
                training = (Models.Training)selectedTraining;
                AdminUpdateTraining updateTraining = new AdminUpdateTraining(training.PasswordOfTraining.ToString());
                updateTraining.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("You need to select column.");
            }
        }
    }
}
