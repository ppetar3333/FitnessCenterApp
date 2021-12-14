using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace fitnessCenterProject.Essentials.FillDataGrid
{
    class FillDataGrid
    {
        public static void setAttribuesForDataGrid(DataGrid informations, ICollectionView view)
        {
            AllData.Instance.readingData();
            informations.ItemsSource = view;
            informations.IsSynchronizedWithCurrentItem = true;
            informations.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        public static void fillDataGridAddresses(DataGrid addressesInfo)
        {
            ICollectionView viewAddressess = CollectionViewSource.GetDefaultView(AllData.Instance.addresses);
            setAttribuesForDataGrid(addressesInfo, viewAddressess);
        }
        public static void fillDataGridBeginner(DataGrid beginnersInfo)
        {
            ICollectionView viewBeginners = CollectionViewSource.GetDefaultView(AllData.Instance.beginners);
            setAttribuesForDataGrid(beginnersInfo, viewBeginners);
        }
        public static void fillDataGridFitnessCenter(DataGrid fitnessCenterInfo)
        {
            ICollectionView viewFitnessCenter = CollectionViewSource.GetDefaultView(AllData.Instance.fitnessCenter);
            setAttribuesForDataGrid(fitnessCenterInfo, viewFitnessCenter);
        }
        public static void fillDataGridInstructor(DataGrid instructorsInfo)
        {
            ICollectionView viewInstructors = CollectionViewSource.GetDefaultView(AllData.Instance.instructors);
            setAttribuesForDataGrid(instructorsInfo, viewInstructors);
        }
        public static void fillDataGridTraining(DataGrid trainingsInfo)
        {
            ICollectionView viewTrainings = CollectionViewSource.GetDefaultView(AllData.Instance.trainings);
            setAttribuesForDataGrid(trainingsInfo, viewTrainings);
        }

        public static void fillDataGridAdmins(DataGrid adminsInfo)
        {
            ICollectionView viewAdmins = CollectionViewSource.GetDefaultView(AllData.Instance.admins);
            setAttribuesForDataGrid(adminsInfo, viewAdmins);
        }

    }
}
