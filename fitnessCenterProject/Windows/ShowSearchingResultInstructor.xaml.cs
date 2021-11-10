using fitnessCenterProject.Essentials;
using fitnessCenterProject.Essentials.ChangeVisibility;
using fitnessCenterProject.Essentials.FillDataGrid;
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
    public partial class ShowSearchingResultInstructor : Window
    {
        public ShowSearchingResultInstructor(ObservableCollection<Models.Instructor> instructorsDataCollection)
        {
            InitializeComponent();
            fillDataGrid(instructorsDataCollection);
        }

        private void fillDataGrid(ObservableCollection<Models.Instructor> instructorsDataCollection)
        {
            ICollectionView viewInstructorData = CollectionViewSource.GetDefaultView(instructorsDataCollection);
            FillDataGrid.setAttribuesForDataGrid(instructorsInfo, viewInstructorData);
        }

        private void closeButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void changeVisibilityInstructors(object sender, EventArgs e)
        {
            ChangeVisibilityDataGrid.changeVisibilityOfInstructor(instructorsInfo);
        }
    }
}
