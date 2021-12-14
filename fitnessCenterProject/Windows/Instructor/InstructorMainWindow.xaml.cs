using fitnessCenterProject.Enums;
using fitnessCenterProject.Essentials;
using fitnessCenterProject.Essentials.ChangeVisibility;
using fitnessCenterProject.Essentials.FillDataGrid;
using fitnessCenterProject.Models;
using fitnessCenterProject.Windows.Instructor;
using fitnessCenterProject.Windows.Instructor.InstructorCheckBeginners;
using fitnessCenterProject.Windows.Instructor.InstructorCheckTrainings;
using fitnessCenterProject.Windows.Instructor.InstructorCreateTraining;
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

namespace fitnessCenterProject.Windows
{
    public partial class InstructorMainWindow : Window
    {
        private ObservableCollection<Models.Instructor> oCollectionInstructor;
        private ObservableCollection<Models.Training> oCollectionTrainings, trainings;
        private ObservableCollection<Models.Beginner> beginners = new ObservableCollection<Models.Beginner>();
        private ICollectionView viewTrainings, viewInstructorData;
        private string jmbgOfUser;
        private Models.Instructor idOfInstructor;
        private Models.Training training;

        public InstructorMainWindow(string jmbgOfInstructor)
        {
            InitializeComponent();
            jmbgOfUser = jmbgOfInstructor;
            idOfInstructor = SearchInstructorBY.searchInstructorBYjmbg(jmbgOfInstructor);
            fillInInstructor(jmbgOfInstructor);
            fillInInstructor(jmbgOfInstructor);
            fillInTrainings(idOfInstructor.Id);
            fillInTrainings(idOfInstructor.Id);
        }

        private void fillInTrainings(int idOfInstructor)
        {
            oCollectionTrainings = SearchTrainingsBY.findInstructorTraining(idOfInstructor);
            viewTrainings = CollectionViewSource.GetDefaultView(oCollectionTrainings);
            FillDataGrid.setAttribuesForDataGrid(trainingInformations, viewTrainings);
        }
        private void fillInInstructor(string jmbgOfInstructor)
        {
            oCollectionInstructor = SearchInstructorBY.searchInstructorByjmbgGetCollection(jmbgOfInstructor);
            viewInstructorData = CollectionViewSource.GetDefaultView(oCollectionInstructor);
            FillDataGrid.setAttribuesForDataGrid(instructorDataInformationDataGrid, viewInstructorData);
        }

        private void changeVisibilityInstructors(object sender, EventArgs e)
        {
            ChangeVisibilityDataGrid.changeVisibilityOfInstructor(instructorDataInformationDataGrid);
        }
        private void changeVisibilityTrainings(object sender, EventArgs e)
        {
            ChangeVisibilityDataGrid.changeVisibilityOfTrainings(trainingInformations);

        }
        private void logOutButton(object sender, RoutedEventArgs e)
        {
            BackToLogIn.backToLogInWindow(this);
        }
        private void exitTheApp(object sender, RoutedEventArgs e)
        {
            ExitTheApp.exitTheApp(this);
        }
        private void checkTrainings(object sender, RoutedEventArgs e)
        {
            CheckTrainings checkTrainings = new CheckTrainings(jmbgOfUser);
            checkTrainings.ShowDialog();
        }
        private void createTraining(object sender, RoutedEventArgs e)
        {
            CreateTraining createTraining = new CreateTraining(jmbgOfUser);
            createTraining.Show();
            this.Close();
        }

        private void changeData(object sender, RoutedEventArgs e)
        {
            object selectedInstructor = instructorDataInformationDataGrid.SelectedItem;
            if (selectedInstructor != null)
            {
                ChangeInstructorWindow changeInstructor = new ChangeInstructorWindow(jmbgOfUser);
                changeInstructor.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("You need to select column.");
            }
        }

        private void checkBeginners(object sender, RoutedEventArgs e)
        {
            trainings = SearchTrainingsBY.findInstructorTraining(idOfInstructor.Id);
            foreach(Training training in trainings)
            {
                foreach(Models.Beginner beginner in AllData.Instance.beginners)
                {
                    if(training.BegginerID == beginner.Id)
                    {
                        beginners.Add(beginner);
                    }
                }
            }
            beginners = new ObservableCollection<Models.Beginner>(beginners.Distinct());
            if (beginners.Count > 0)
            {
                CheckBeginners checkBeginners = new CheckBeginners(beginners, jmbgOfUser);
                checkBeginners.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Instructor does not have trainings.");
            }
        }

        private void deleteTraining(object sender, RoutedEventArgs e)
        {
            object selectedTraining = trainingInformations.SelectedItem;
            if (selectedTraining != null)
            {
                training = (Training) selectedTraining;
                if(training.TrainingStatus == TrainingStatus.slobodan)
                {
                    if (MessageBox.Show("Do you really want to delete this training?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        AllData.Instance.deleteTraining(training.PasswordOfTraining);
                        AllData.Instance.trainings.Remove(training);
                        fillInTrainings(idOfInstructor.Id);
                        MessageBox.Show("You have successfuly deleted training.");
                        fillInTrainings(idOfInstructor.Id);
                    }
                }
                else
                {
                    MessageBox.Show("You can not delete reserved training.");
                }
            }
            else
            {
                MessageBox.Show("Please select column.");
            }
        }
    }
}
