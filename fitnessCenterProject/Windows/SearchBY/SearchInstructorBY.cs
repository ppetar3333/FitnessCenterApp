using fitnessCenterProject.Essentials;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCenterProject.Windows.SearchBY
{
    class SearchInstructorBY
    {
        public static Models.Instructor searchInstructorBYjmbg(string jmbgOfUser)
        {
            foreach (var instructor in AllData.Instance.instructors.Where(instructor => instructor.Jmbg.ToString().Equals(jmbgOfUser)))
            {
                return instructor;
            }

            return null;
        }

        public static ObservableCollection<Models.Instructor> searchInstructorByjmbgGetCollection(string jmbgOfInstructor)
        {
            ObservableCollection<Models.Instructor> instructorAllData = new ObservableCollection<Models.Instructor>();
            foreach (var instructor in AllData.Instance.instructors.Where(instructor => (instructor.Jmbg).ToString().Equals(jmbgOfInstructor)))
            {
                instructorAllData.Add(instructor);
            }

            return instructorAllData;
        }

        public static int searchInstructorBYname(string name)
        {
            foreach (var instructor in AllData.Instance.instructors.Where(instructor => instructor.FirstName.Equals(name)))
            {
                return instructor.Id;
            }

            return 0;
        }
    }
}
