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

namespace fitnessCenterProject.Windows
{
    public partial class Guest : Window
    {
        public Guest()
        {
            InitializeComponent();
            FillDataGrid.fillDataGridFitnessCenter(fitnessCenterInfo);
            FillDataGrid.fillDataGridInstructor(instructorsInfo);
        }
        private void backToLogInWindow(object sender, RoutedEventArgs e)
        {
            BackToLogIn.backToLogInWindow(this);
        }

        private void exitTheApp(object sender, RoutedEventArgs e)
        {
            ExitTheApp.exitTheApp(this);
        }

        private void searchInstructorsButton(object sender, RoutedEventArgs e)
        {
            SearchInstructors searchInstructors = new SearchInstructors();
            searchInstructors.ShowDialog();
        }

        private void changeVisibilityFitnessCenter(object sender, EventArgs e)
        {
            ChangeVisibilityDataGrid.changeVisibilityOfFitnessCenter(fitnessCenterInfo);
        }

        private void changeVisibilityInstructors(object sender, EventArgs e)
        {
            ChangeVisibilityDataGrid.changeVisibilityOfInstructor(instructorsInfo);
        }
    }
}
