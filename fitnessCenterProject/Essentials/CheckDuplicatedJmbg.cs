using fitnessCenterProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCenterProject.Essentials
{
    class CheckDuplicatedJmbg
    {
        public static bool isNotDuplicatedBeginner(long jmbgFromTextBox)
        {
            foreach (Beginner beginner in AllData.Instance.beginners)
            {
                if (beginner.Jmbg == jmbgFromTextBox)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool isNotDuplicatedAdmin(long jmbgFromTextBox)
        {
            foreach (Admin admin in AllData.Instance.admins)
            {
                if (admin.Jmbg == jmbgFromTextBox)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool isNotDuplicatedInstructor(long jmbgFromTextBox)
        {
            foreach (Instructor instructor in AllData.Instance.instructors)
            {
                if (instructor.Jmbg == jmbgFromTextBox)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
