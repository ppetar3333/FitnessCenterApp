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

namespace fitnessCenterProject.Windows.Administrator.AdminFitnessCenter
{
    public partial class AdminFitnessCenterOptions : Window
    {
        private Models.FitnessCenter fitnessCenter;
        public AdminFitnessCenterOptions()
        {
            InitializeComponent();
            FillDataGrid.fillDataGridFitnessCenter(fitnessCenterInfo);
            FillDataGrid.fillDataGridFitnessCenter(fitnessCenterInfo);
        }

        private void changeVisibilityFitnessCenter(object sender, EventArgs e)
        {
            ChangeVisibilityDataGrid.changeVisibilityOfFitnessCenter(fitnessCenterInfo);
        }
        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void createFitnessCenter(object sender, RoutedEventArgs e)
        {
            CreateFitnessCenter createFitnessCenter = new CreateFitnessCenter();
            createFitnessCenter.Show();
            this.Close();
        }

        private void updateFitnessCenter(object sender, RoutedEventArgs e)
        {
            object selectedFitnessCenter = fitnessCenterInfo.SelectedItem;
            if (selectedFitnessCenter != null)
            {
                fitnessCenter = (Models.FitnessCenter)selectedFitnessCenter;
                UpdateFitnessCenter updateFitnessCenter = new UpdateFitnessCenter(fitnessCenter.PasswordOfFitnessCenter);
                updateFitnessCenter.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("You need to select column.");
            }
        }

        private void deleteFitnessCenter(object sender, RoutedEventArgs e)
        {
            object selectedFitnessCenter = fitnessCenterInfo.SelectedItem;
            if (selectedFitnessCenter != null)
            {
                if (MessageBox.Show("Do you really want to delete this Fitness Center?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    fitnessCenter = (Models.FitnessCenter)selectedFitnessCenter;
                    AllData.Instance.deleteFitnessCenter(fitnessCenter.PasswordOfFitnessCenter);
                    AllData.Instance.fitnessCenter.Remove(fitnessCenter);
                    FillDataGrid.fillDataGridFitnessCenter(fitnessCenterInfo);
                    MessageBox.Show("You have successfuly deleted fitness center " + fitnessCenter.NameOfCenter);
                    FillDataGrid.fillDataGridFitnessCenter(fitnessCenterInfo);
                }
            }
            else
            {
                MessageBox.Show("Please select column.");
            }
        }
    }
}
