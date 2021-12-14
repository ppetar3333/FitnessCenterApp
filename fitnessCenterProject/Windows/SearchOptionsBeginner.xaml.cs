using fitnessCenterProject.Windows.Administrator.SearchAdmin;
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
    public partial class SearchOptionsBeginner : Window
    {
        public SearchOptionsBeginner()
        {
            InitializeComponent();
        }
        private void oneCriterion(object sender, RoutedEventArgs e)
        {
            SearchOneCriterionDesicionBeginner searchOneCriterionDesicion = new SearchOneCriterionDesicionBeginner();
            searchOneCriterionDesicion.ShowDialog();
        }

        private void multipleCirterion(object sender, RoutedEventArgs e)
        {
            SearchBeginners searchBeginners = new SearchBeginners();
            searchBeginners.ShowDialog();
        }

        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
