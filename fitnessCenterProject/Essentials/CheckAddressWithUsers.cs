using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCenterProject.Essentials
{
    class CheckAddressWithUsers
    {
        public static bool checkAddressBeginner(int idAddress)
        {
            foreach (Models.Beginner beginner in AllData.Instance.beginners)
            {
                if (beginner.AddressID == idAddress)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool checkAddressAdmin(int idAddress)
        {
            foreach (Models.Admin admin in AllData.Instance.admins)
            {
                if (admin.AddressID == idAddress)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool checkAddressInstructor(int idAddress)
        {
            foreach (Models.Instructor instructor in AllData.Instance.instructors)
            {
                if (instructor.AddressID == idAddress)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool checkAddressFitnessCenter(int idAddress)
        {
            foreach (Models.FitnessCenter fitnessCenter in AllData.Instance.fitnessCenter)
            {
                if (fitnessCenter.AddressID == idAddress)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
