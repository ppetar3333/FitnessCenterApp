using fitnessCenterProject.Essentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCenterProject.Validation
{
    class SearchUserValidation
    {
        public static Models.Instructor checkInputsInstructor(string name, string lastName, string email, int foundAddress)
        {
            foreach (Models.Instructor instructor in AllData.Instance.instructors)
            {
                if (instructor.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                    instructor.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase) &&
                    instructor.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                    instructor.AddressID.Equals(foundAddress))
                {
                    return instructor;
                }
            }
            return null;
        }

        public static Models.Beginner checkInputsBeginner(string name, string lastName, string email, int foundAddress)
        {
            foreach (Models.Beginner beginner in AllData.Instance.beginners)
            {
                if (beginner.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                    beginner.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase) &&
                    beginner.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                    beginner.AddressID.Equals(foundAddress))
                {
                    return beginner;
                }
            }
            return null;
        }
    }
}
