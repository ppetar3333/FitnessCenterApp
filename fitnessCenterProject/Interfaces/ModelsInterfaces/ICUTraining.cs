using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCenterProject.Interfaces.ModelsInterfaces
{
    interface ICUTraining : IRDModels
    {
        void createTraining(int passwordOfTraining, DateTime dateOfTraining, string stratTime, int durationOfTraining, int instructorID);
        void cancelReservationOfTraining(int trainingID);
        void bookTraining(int trainingID, int beginnerID);
    }
}
