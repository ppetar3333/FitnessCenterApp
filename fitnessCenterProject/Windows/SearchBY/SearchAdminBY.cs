using fitnessCenterProject.Essentials;
using fitnessCenterProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCenterProject.Windows.SearchBY
{
    class SearchAdminBY
    {
        public static ObservableCollection<Admin> searchAdminBYjmbgGetCollection(string jmbgOfAdministrator)
        {
            ObservableCollection<Admin> adminAllData = new ObservableCollection<Models.Admin>();
            foreach (var admins in AllData.Instance.admins.Where(admins => (admins.Jmbg).ToString().Equals(jmbgOfAdministrator)))
            {
                adminAllData.Add(admins);
            }

            return adminAllData;
        }
        public static Admin searchAdminBYjmbg(string jmbgOfUser)
        {
            foreach (var admin in AllData.Instance.admins.Where(admin => admin.Jmbg.ToString().Equals(jmbgOfUser)))
            {
                return admin;
            }

            return null;
        }
    }
}
