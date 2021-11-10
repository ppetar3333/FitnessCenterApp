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

namespace fitnessCenterProject.Windows.Instructor.InstructorCheckTrainings
{
    public partial class ShowFoundedTrainings : Window
    {
        public ShowFoundedTrainings(ObservableCollection<Models.Training> foundedTrainings)
        {
            InitializeComponent();
            ICollectionView viewTrainings = CollectionViewSource.GetDefaultView(foundedTrainings);
            FillDataGrid.setAttribuesForDataGrid(showTrainings, viewTrainings);
        }

        private void changeVisibilityTrainings(object sender, EventArgs e)
        {
            ChangeVisibilityDataGrid.changeVisibilityOfTrainings(showTrainings);
        }

        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
