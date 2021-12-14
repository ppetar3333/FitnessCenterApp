using fitnessCenterProject.Essentials;
using fitnessCenterProject.Essentials.ChangeVisibility;
using fitnessCenterProject.Essentials.FillDataGrid;
using fitnessCenterProject.Models;
using fitnessCenterProject.Windows.Administrator;
using fitnessCenterProject.Windows.Administrator.AdminAddresses;
using fitnessCenterProject.Windows.Administrator.AdminBeginner;
using fitnessCenterProject.Windows.Administrator.AdminFitnessCenter;
using fitnessCenterProject.Windows.Administrator.AdminInstructor;
using fitnessCenterProject.Windows.Administrator.AdminOptions;
using fitnessCenterProject.Windows.Administrator.AdminTrainings;
using fitnessCenterProject.Windows.Administrator.SearchAdmin;
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
    public partial class AdministratorMainWindow : Window
    {
        private ObservableCollection<Admin> oCollectionAdmin;
        private string jmbgOfUser;
        private ICollectionView viewAdminData;

        public AdministratorMainWindow(string jmbgOfAdministrator)
        {
            InitializeComponent();
            jmbgOfUser = jmbgOfAdministrator;
            fillInDataGrid(jmbgOfAdministrator);
            fillInDataGrid(jmbgOfAdministrator);
        }

        private void fillInDataGrid(string jmbgOfAdministrator)
        {
            oCollectionAdmin = SearchAdminBY.searchAdminBYjmbgGetCollection(jmbgOfAdministrator);
            viewAdminData = CollectionViewSource.GetDefaultView(oCollectionAdmin);
            FillDataGrid.setAttribuesForDataGrid(adminDataInformationDataGrid, viewAdminData);
        }

        private void changeVisibilityAdmin(object sender, EventArgs e)
        {
            ChangeVisibilityDataGrid.changeVisibilityOfAdmin(adminDataInformationDataGrid);
        }
        private void logOutButton(object sender, RoutedEventArgs e)
        {
            BackToLogIn.backToLogInWindow(this);
        }

        private void exitTheApp(object sender, RoutedEventArgs e)
        {
            ExitTheApp.exitTheApp(this);
        }

        private void searchButton(object sender, RoutedEventArgs e)
        {
            SearchPossibilityAdmin searchPossibility = new SearchPossibilityAdmin();
            searchPossibility.ShowDialog();
        }

        private void beginnerCRUD(object sender, RoutedEventArgs e)
        {
            AdminBeginnerOptions adminBeginnerOptions = new AdminBeginnerOptions();
            adminBeginnerOptions.ShowDialog();
        }

        private void addressesCRUD(object sender, RoutedEventArgs e)
        {
            AdminAddressOptions adminAddressOptions = new AdminAddressOptions();
            adminAddressOptions.ShowDialog();
        }

        private void trainingCRUD(object sender, RoutedEventArgs e)
        {
            AdminTrainingsOptions adminTrainingsOptions = new AdminTrainingsOptions();
            adminTrainingsOptions.ShowDialog();
        }

        private void fitnessCenterCRUD(object sender, RoutedEventArgs e)
        {
            AdminFitnessCenterOptions adminFitnessCenterOptions = new AdminFitnessCenterOptions();
            adminFitnessCenterOptions.ShowDialog();
        }

        private void instructorCRUD(object sender, RoutedEventArgs e)
        {
            AdminInstructorOptions adminInstructorOptions = new AdminInstructorOptions();
            adminInstructorOptions.ShowDialog();
        }
        private void changeData(object sender, RoutedEventArgs e)
        {
            object selectedAdmin = adminDataInformationDataGrid.SelectedItem;
            if (selectedAdmin != null)
            {
                ChangeAdminWindow changeAdmin = new ChangeAdminWindow(jmbgOfUser);
                changeAdmin.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("You need to select column.");
            }
        }

        private void adminButton(object sender, RoutedEventArgs e)
        {
            AdministratorWindow administrator = new AdministratorWindow(jmbgOfUser);
            administrator.ShowDialog();
        }
    }
}
