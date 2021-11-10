using System;
using System.Collections.Generic;
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
    public partial class SearchByType : Window
    {
        public SearchByType()
        {
            InitializeComponent();
        }

        private void searchBeginner(object sender, RoutedEventArgs e)
        {
            ShowAllBeginners showAllBeginners = new ShowAllBeginners();
            showAllBeginners.ShowDialog();
        }

        private void searchInstructor(object sender, RoutedEventArgs e)
        {
            ShowAllInstructors showAllInstructors = new ShowAllInstructors();
            showAllInstructors.ShowDialog();
        }

        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
