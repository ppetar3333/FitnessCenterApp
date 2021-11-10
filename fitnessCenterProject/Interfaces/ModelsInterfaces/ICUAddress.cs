using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCenterProject.Interfaces.ModelsInterfaces
{
    interface ICUAddress : IRDModels
    {
        void createAddress(int passwordOfAddress, string street, string number, string city, string country);
        void updateAddress(int id, string street, int number, string city, string country);
    }
}
