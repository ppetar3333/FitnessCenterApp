using fitnessCenterProject.Essentials;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCenterProject.Windows.SearchBY
{
    class SearchBeginnerBY
    {
        public static ObservableCollection<Models.Beginner> searchBeginnerBYjmbgGetCollection(string jmbgOfBeginner)
        {
            ObservableCollection<Models.Beginner> beginnerAllData = new ObservableCollection<Models.Beginner>();
            foreach (var beginner in AllData.Instance.beginners.Where(beginner => (beginner.Jmbg).ToString().Equals(jmbgOfBeginner)))
            {
                beginnerAllData.Add(beginner);
            }

            return beginnerAllData;
        }
        public static Models.Beginner searchBeginnerByJMBG(string jmbgOfUser)
        {
            foreach (var beginner in AllData.Instance.beginners.Where(beginner => beginner.Jmbg.ToString().Equals(jmbgOfUser)))
            {
                return beginner;
            }

            return null;
        }
    }
}
