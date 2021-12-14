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

namespace fitnessCenterProject.Windows.Administrator.SearchAdmin
{
    public partial class ShowAllInstructors : Window
    {
        public ShowAllInstructors()
        {
            InitializeComponent();
            FillDataGrid.fillDataGridInstructor(instructorsInfo);
        }
        private void changeVisibilityInstructors(object sender, EventArgs e)
        {
            ChangeVisibilityDataGrid.changeVisibilityOfInstructor(instructorsInfo);
        }
        private void closeButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
