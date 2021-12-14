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

namespace fitnessCenterProject.Windows.Administrator.AdminInstructor
{

    public partial class AdminInstructorOptions : Window
    {
        private Models.Instructor instructor;

        public AdminInstructorOptions()
        {
            InitializeComponent();
            FillDataGrid.fillDataGridInstructor(instructorsInfo);
            FillDataGrid.fillDataGridInstructor(instructorsInfo);
        }

        private void changeVisibilityInstructors(object sender, EventArgs e)
        {
            ChangeVisibilityDataGrid.changeVisibilityOfInstructor(instructorsInfo);
        }
        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void createInstrucors(object sender, RoutedEventArgs e)
        {
            CreateInstructor createInstructor = new CreateInstructor();
            createInstructor.Show();
            this.Close();
        }
        private void updateInstrucors(object sender, RoutedEventArgs e)
        {
            object selectedInstructor = instructorsInfo.SelectedItem;
            if (selectedInstructor != null)
            {
                instructor = (Models.Instructor)selectedInstructor;
                UpdateInstructor updateInstructor = new UpdateInstructor(instructor.Jmbg.ToString());
                updateInstructor.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("You need to select column.");
            }
        }
        private void deleteInstrucors(object sender, RoutedEventArgs e)
        {
            object selectedInstructor = instructorsInfo.SelectedItem;
            if (selectedInstructor != null)
            {
                if (MessageBox.Show("Do you really want to delete this instructor?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    instructor = (Models.Instructor)selectedInstructor;
                    AllData.Instance.deleteInstructor(instructor.Id);
                    AllData.Instance.instructors.Remove(instructor);
                    FillDataGrid.fillDataGridInstructor(instructorsInfo);
                    MessageBox.Show("You have successfuly deleted instructor " + instructor.FirstName);
                    FillDataGrid.fillDataGridInstructor(instructorsInfo);
                }
            }
            else
            {
                MessageBox.Show("Please select column.");
            }
        }
    }
}
