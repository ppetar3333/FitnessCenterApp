using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace fitnessCenterProject.Essentials.ChangeVisibility
{
    class ChangeVisibilityDataGrid
    {
        public static void changeVisibilityOfFitnessCenter(DataGrid fitnessCenterInfo)
        {
            fitnessCenterInfo.Columns[0].Visibility = Visibility.Hidden;
            fitnessCenterInfo.Columns[3].Visibility = Visibility.Hidden;
        }
        public static void changeVisibilityOfInstructor(DataGrid instructorsInfo)
        {
            instructorsInfo.Columns[1].Visibility = Visibility.Hidden;
            instructorsInfo.Columns[8].Visibility = Visibility.Hidden;
            instructorsInfo.Columns[10].Visibility = Visibility.Hidden;
        }
        public static void changeVisibilityOfTrainings(DataGrid trainingInfo)
        {
            trainingInfo.Columns[0].Visibility = Visibility.Hidden;
            trainingInfo.Columns[7].Visibility = Visibility.Hidden;
        }

        public static void changeVisibilityOfBeginners(DataGrid beginnersInfo)
        {
            beginnersInfo.Columns[0].Visibility = Visibility.Hidden;
            beginnersInfo.Columns[7].Visibility = Visibility.Hidden;
            beginnersInfo.Columns[9].Visibility = Visibility.Hidden;
        }

        public static void changeVisibilityOfAdmin(DataGrid adminInfo)
        {
            adminInfo.Columns[0].Visibility = Visibility.Hidden;
            adminInfo.Columns[7].Visibility = Visibility.Hidden;
            adminInfo.Columns[9].Visibility = Visibility.Hidden;
        }
        public static void changeVisibilityOfAddress(DataGrid addressesInfo)
        {
            addressesInfo.Columns[0].Visibility = Visibility.Hidden;
            addressesInfo.Columns[5].Visibility = Visibility.Hidden;
        }

    }
}
