using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCenterProject.Interfaces.ModelsInterfaces
{
    interface ICUFitnessCenter : IRDModels
    {
        void createFitnessCenter(int passwordOfFitnessCenter, string nameOfCenter, int addressID);
        void updateFitnessCenter(int id, string nameOfCenter, int addressID);
    }
}
