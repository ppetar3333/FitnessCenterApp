using fitnessCenterProject.Enums;
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
    public partial class ShowTrainings : Window
    {
        private readonly ICollectionView viewTrainings;
        private string jmbgOfUser;
        public ShowTrainings(ObservableCollection<Models.Training> trainings, string jmbgOfBeginner)
        {
            InitializeComponent();
            jmbgOfUser = jmbgOfBeginner;
            viewTrainings = CollectionViewSource.GetDefaultView(trainings);
            FillDataGrid.setAttribuesForDataGrid(trainingInfo, viewTrainings);
        }

        private void changeVisibilityTrainings(object sender, EventArgs e)
        {
            ChangeVisibilityDataGrid.changeVisibilityOfTrainings(trainingInfo);
        }
        private void closeButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bookTraining(object sender, RoutedEventArgs e)
        {
            object selectedTraining = trainingInfo.SelectedItem;
            if (selectedTraining != null)
            {
                Training training = (Training) selectedTraining;
                if(training.TrainingStatus == TrainingStatus.slobodan)
                {
                    if (MessageBox.Show("Do you really want to book this training?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        Models.Beginner foundedBeginner = SearchBeginnerBY.searchBeginnerByJMBG(jmbgOfUser);
                        MessageBox.Show("You have successfuly book the training.");
                        AllData.Instance.bookTraining(training.PasswordOfTraining, foundedBeginner.Id);
                        training.TrainingStatus = TrainingStatus.rezervisan;
                        training.BegginerID = foundedBeginner.Id;
                        trainingInfo.Items.Refresh();
                    }
                }
                else
                {
                    MessageBox.Show("Sorry, but status of this training is: '" + training.TrainingStatus + "' and you cant book it.");
                }
            }
            else
            {
                MessageBox.Show("Please select column.");
            }
        }

        private void cancelTheReservation(object sender, RoutedEventArgs e)
        {
            object selectedTraining = trainingInfo.SelectedItem;
            if (selectedTraining != null)
            {
                Training training = (Training)selectedTraining;
                if (training.TrainingStatus == TrainingStatus.rezervisan)
                {
                    Models.Beginner foundedBeginner = SearchBeginnerBY.searchBeginnerByJMBG(jmbgOfUser);
                    if(training.BegginerID == foundedBeginner.Id)
                    {
                        if (MessageBox.Show("Do you really want to cancel the rezervation?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            MessageBox.Show("You have successfuly cancel the reservation.");
                            int idOfTraining = training.PasswordOfTraining;
                            AllData.Instance.cancelReservationOfTraining(idOfTraining);
                            training.TrainingStatus = TrainingStatus.slobodan;
                            training.BegginerID = 0;
                            trainingInfo.Items.Refresh();
                        }
                    }
                    else
                    {
                        MessageBox.Show("You didn't book this training.");
                    }
                }
                else
                {
                    MessageBox.Show("Sorry, but you didn't book this training so you can't cancel reservation.");
                }
            }
            else
            {
                MessageBox.Show("Please select column.");
            }
        }
    }
}
