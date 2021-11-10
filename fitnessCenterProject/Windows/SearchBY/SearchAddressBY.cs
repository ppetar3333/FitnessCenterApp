using fitnessCenterProject.Essentials;
using fitnessCenterProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCenterProject.Windows.SearchBY
{
    class SearchAddressBY
    {
        public static int searchAddressBYstreet(string addressStreet)
        {
            foreach (var address in AllData.Instance.addresses.Where(address => address.Street.Equals(addressStreet)))
            {
                return address.PasswordOfAddress;
            }

            return 0;
        }

        public static Address searchAddressBYid(int passwordOfAddress)
        {
            foreach (var address in AllData.Instance.addresses.Where(address => address.PasswordOfAddress == passwordOfAddress))
            {
                return address;
            }

            return null;
        }
    }
}
