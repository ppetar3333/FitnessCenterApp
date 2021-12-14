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

namespace fitnessCenterProject.Windows.Instructor.InstructorCheckBeginners
{
    public partial class CheckBeginners : Window
    {
        private readonly ICollectionView viewBegginerData;
        private string jmbgOfInstructor;
        public CheckBeginners(ObservableCollection<Models.Beginner> beginners, string jmbgOfUser)
        {
            InitializeComponent();
            this.jmbgOfInstructor = jmbgOfUser;
            viewBegginerData = CollectionViewSource.GetDefaultView(beginners);
            FillDataGrid.setAttribuesForDataGrid(beginnersInfo, viewBegginerData);
        }

        private void changeVisibilityBeginners(object sender, EventArgs e)
        {
            ChangeVisibilityDataGrid.changeVisibilityOfBeginners(beginnersInfo);
        }

        private void close(object sender, RoutedEventArgs e)
        {
            InstructorMainWindow instructor = new InstructorMainWindow(jmbgOfInstructor);
            instructor.Show();
            this.Close();
        }
    }
}
