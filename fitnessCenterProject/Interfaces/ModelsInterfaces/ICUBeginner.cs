using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCenterProject.Interfaces.ModelsInterfaces
{
    interface ICUBeginner : IRDModels
    {
        void createBeginner(int id, string firstName, string lastName, long jmbg, string gender, int addressID, string email, string passwordOfUser);
        void updateBeginner(int id, string firstName, string lastName, long jmbg, string gender, int addressID, string email, string passwordOfUser);
    }
}
