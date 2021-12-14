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
    public partial class SearchPossibilityAdmin : Window
    {
        public SearchPossibilityAdmin()
        {
            InitializeComponent();
        }
        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void searchInstructors(object sender, RoutedEventArgs e)
        {
            SearchOptions searchInstructors = new SearchOptions();
            searchInstructors.ShowDialog();
        }
        private void searchBeginners(object sender, RoutedEventArgs e)
        {
            SearchOptionsBeginner searchBeginners = new SearchOptionsBeginner();
            searchBeginners.ShowDialog();
        }
        private void searchByType(object sender, RoutedEventArgs e)
        {
            SearchByType searchByType = new SearchByType();
            searchByType.ShowDialog();
        }
    }
}
