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

namespace fitnessCenterProject.Windows.Administrator.AdminBeginner
{
    public partial class AdminBeginnerOptions : Window
    {
        private Models.Beginner beginner;

        public AdminBeginnerOptions()
        {
            InitializeComponent();
            FillDataGrid.fillDataGridBeginner(beginnersInfo);
            FillDataGrid.fillDataGridBeginner(beginnersInfo);
        }

        private void changeVisibilityBeginners(object sender, EventArgs e)
        {
            ChangeVisibilityDataGrid.changeVisibilityOfBeginners(beginnersInfo);
        }
        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void createBeginner(object sender, RoutedEventArgs e)
        {
            CreateBeginner createBeginner = new CreateBeginner();
            createBeginner.Show();
            this.Close();
        }

        private void updateBeginner(object sender, RoutedEventArgs e)
        {
            var selectedBeginner = beginnersInfo.SelectedItem;
            if (selectedBeginner != null)
            {
                beginner = (Models.Beginner)selectedBeginner;
                UpdateBeginner updateBeginner = new UpdateBeginner(beginner.Jmbg.ToString());
                updateBeginner.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("You need to select column.");
            }
        }

        private void deleteBeginner(object sender, RoutedEventArgs e)
        {
            object selectetBeginner = beginnersInfo.SelectedItem;
            if (selectetBeginner != null)
            {
                if (MessageBox.Show("Do you really want to delete this beginner?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    beginner = (Models.Beginner)selectetBeginner;
                    AllData.Instance.deleteBeginner(beginner.Id);
                    AllData.Instance.beginners.Remove(beginner);
                    FillDataGrid.fillDataGridBeginner(beginnersInfo);
                    MessageBox.Show("You have successfuly deleted beginner " + beginner.FirstName);
                    FillDataGrid.fillDataGridBeginner(beginnersInfo);
                }
            }
            else
            {
                MessageBox.Show("Please select column.");
            }
        }
    }
}
