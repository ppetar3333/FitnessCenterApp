using fitnessCenterProject.Essentials;
using fitnessCenterProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCenterProject.Windows.SearchBY
{
    class SearchFitnessCenterBY
    {
        public static FitnessCenter searchFitnessCenterBYid(int id)
        {
            foreach (var fitnessCenter in AllData.Instance.fitnessCenter.Where(fitnessCenter => fitnessCenter.PasswordOfFitnessCenter == id))
            {
                return fitnessCenter;
            }

            return null;
        }
    }
}
