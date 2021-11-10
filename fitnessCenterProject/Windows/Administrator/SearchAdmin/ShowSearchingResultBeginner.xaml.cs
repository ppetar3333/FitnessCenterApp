using fitnessCenterProject.Essentials;
using fitnessCenterProject.Essentials.ChangeVisibility;
using fitnessCenterProject.Essentials.FillDataGrid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ShowSearchingResultBeginner : Window
    {
        private readonly ICollectionView viewBeginner;
        public ShowSearchingResultBeginner(ObservableCollection<Models.Beginner> beginnersDataCollection)
        {
            InitializeComponent();
            viewBeginner = CollectionViewSource.GetDefaultView(beginnersDataCollection);
            FillDataGrid.setAttribuesForDataGrid(beginnerDataInformationDataGrid, viewBeginner);
        }

        private void changeVisibilityBeginners(object sender, EventArgs e)
        {
            ChangeVisibilityDataGrid.changeVisibilityOfBeginners(beginnerDataInformationDataGrid);
        }

        private void closeButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
