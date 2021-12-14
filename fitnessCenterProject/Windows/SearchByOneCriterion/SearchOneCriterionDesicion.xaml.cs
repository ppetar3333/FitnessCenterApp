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
    public partial class SearchOneCriterionDesicion : Window
    {
        public SearchOneCriterionDesicion()
        {
            InitializeComponent();
        }

        private void firstName(object sender, RoutedEventArgs e)
        {
            InstructorFirstName instructor = new InstructorFirstName();
            instructor.ShowDialog();
        }

        private void lastName(object sender, RoutedEventArgs e)
        {
            InstructorLastName instructor = new InstructorLastName();
            instructor.ShowDialog();
        }

        private void email(object sender, RoutedEventArgs e)
        {
            InstructorEmail instructor = new InstructorEmail();
            instructor.ShowDialog();
        }

        private void address(object sender, RoutedEventArgs e)
        {
            InstructorAddress instructor = new InstructorAddress();
            instructor.ShowDialog();
        }

        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
