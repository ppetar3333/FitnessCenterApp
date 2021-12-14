using fitnessCenterProject.Essentials;
using fitnessCenterProject.Essentials.ChangeVisibility;
using fitnessCenterProject.Essentials.FillDataGrid;
using fitnessCenterProject.Windows.Beginner;
using fitnessCenterProject.Windows.Beginner.BeginnerCheckInstructor;
using fitnessCenterProject.Windows.SearchBY;
using System;
using System.Collections;
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
    public partial class BeginnerMainWindow : Window
    {
        private ObservableCollection<Models.Beginner> oCollectionBeginner;
        private ObservableCollection<Models.Training> oCollectionTrainings;
        private ICollectionView viewBegginerData, viewTrainings;
        private Models.Beginner idOfBeginner;

        private string jmbgOfUser;
        public BeginnerMainWindow(string jmbgOfBeginner)
        {
            InitializeComponent();
            idOfBeginner = SearchBeginnerBY.searchBeginnerByJMBG(jmbgOfBeginner);
            jmbgOfUser = jmbgOfBeginner;
            fillInDataGrid(jmbgOfBeginner);
            fillInDataGrid(jmbgOfBeginner);
            fillInTrainings(idOfBeginner.Id);
            fillInTrainings(idOfBeginner.Id);
        }

        private void fillInDataGrid(string jmbgOfBeginner)
        {
            oCollectionBeginner = SearchBeginnerBY.searchBeginnerBYjmbgGetCollection(jmbgOfBeginner);
            viewBegginerData = CollectionViewSource.GetDefaultView(oCollectionBeginner);
            FillDataGrid.setAttribuesForDataGrid(beginnerDataInformationDataGrid, viewBegginerData);
        }

        private void fillInTrainings(int idOfBeginner)
        {
            oCollectionTrainings = SearchTrainingsBY.findBeginnerTraining(idOfBeginner);
            viewTrainings = CollectionViewSource.GetDefaultView(oCollectionTrainings);
            FillDataGrid.setAttribuesForDataGrid(trainingInformations, viewTrainings);
        }
        private void changeVisibilityTrainings(object sender, EventArgs e)
        {
            ChangeVisibilityDataGrid.changeVisibilityOfTrainings(trainingInformations);
        }
        private void changeVisibilityBeginners(object sender, EventArgs e)
        {
            ChangeVisibilityDataGrid.changeVisibilityOfBeginners(beginnerDataInformationDataGrid);
        }
        private void logOutButton(object sender, RoutedEventArgs e)
        {
            BackToLogIn.backToLogInWindow(this);
        }
        private void exitTheApp(object sender, RoutedEventArgs e)
        {
            ExitTheApp.exitTheApp(this);
        }
        private void searchInstructors(object sender, RoutedEventArgs e)
        {
            SearchOptions searchInstructors = new SearchOptions();
            searchInstructors.ShowDialog();
        }

        private void checkInstructors(object sender, RoutedEventArgs e)
        {
            ShowAllInstructors showAllInstructors = new ShowAllInstructors(jmbgOfUser);
            showAllInstructors.ShowDialog();
        }

        private void changeOwnData(object sender, RoutedEventArgs e)
        {
            var selectedBeginner = beginnerDataInformationDataGrid.SelectedItem;
            if (selectedBeginner != null)
            {
                ChangeBeginnerWindow changeBeginner = new ChangeBeginnerWindow(jmbgOfUser);
                changeBeginner.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("You need to select column.");
            }
        }
    }
}
