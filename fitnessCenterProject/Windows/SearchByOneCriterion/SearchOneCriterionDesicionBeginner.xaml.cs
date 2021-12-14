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

namespace fitnessCenterProject.Windows.SearchByOneCriterion
{
    public partial class SearchOneCriterionDesicionBeginner : Window
    {
        public SearchOneCriterionDesicionBeginner()
        {
            InitializeComponent();
        }
        private void firstName(object sender, RoutedEventArgs e)
        {
            BeginnerFirstName beginner = new BeginnerFirstName();
            beginner.ShowDialog();
        }

        private void lastName(object sender, RoutedEventArgs e)
        {
            BeginnerLastName beginner = new BeginnerLastName();
            beginner.ShowDialog();
        }

        private void email(object sender, RoutedEventArgs e)
        {
            BeginnerEmail beginner = new BeginnerEmail();
            beginner.ShowDialog();
        }

        private void address(object sender, RoutedEventArgs e)
        {
            BeginnerAddress beginner = new BeginnerAddress();
            beginner.ShowDialog();
        }

        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
