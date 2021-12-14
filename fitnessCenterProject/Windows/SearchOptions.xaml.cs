using fitnessCenterProject.Windows.SearchByOneCriterion;
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

namespace fitnessCenterProject.Windows
{
    public partial class SearchOptions : Window
    {
        public SearchOptions()
        {
            InitializeComponent();
        }

        private void oneCriterion(object sender, RoutedEventArgs e)
        {
            SearchOneCriterionDesicion searchOneCriterionDesicion = new SearchOneCriterionDesicion();
            searchOneCriterionDesicion.ShowDialog();
        }

        private void multipleCirterion(object sender, RoutedEventArgs e)
        {
            SearchInstructors searchInstructors = new SearchInstructors();
            searchInstructors.ShowDialog();
        }

        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
