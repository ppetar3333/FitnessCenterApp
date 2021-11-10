using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCenterProject.Interfaces.ModelsInterfaces
{
    interface ICUInstructor : IRDModels
    {
        void createInstructor(int id, string firstName, string lastName, long jmbg, string gender, int addressID, string email, string passwordOfUser);
        void updateInstructor(int id, string firstName, string lastName, long jmbg, string gender, int addressID, string email, string passwordOfUser);
    }
}
