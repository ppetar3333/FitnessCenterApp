using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCenterProject.Essentials
{
    class GenerateNewID
    {
        public static int generateNewIDForBeginner()
        {
            int maxID = -1;
            foreach (var beginner in AllData.Instance.beginners.Where(beginner => beginner.Id > maxID))
            {
                maxID = beginner.Id;
            }
            return maxID + 1;
        }
        public static int generateNewIDForInstructor()
        {
            int maxID = -1;
            foreach (var instructor in AllData.Instance.instructors.Where(instructor => instructor.Id > maxID))
            {
                maxID = instructor.Id;
            }
            return maxID + 1;
        }
        public static int generateNewIDForAdministrator()
        {
            int maxID = -1;
            foreach (var admin in AllData.Instance.admins.Where(admin => admin.Id > maxID))
            {
                maxID = admin.Id;
            }
            return maxID + 1;
        }
        public static int generateNewIDForFitnessCenter()
        {
            int maxID = -1;
            foreach (var fitnessCenter in AllData.Instance.fitnessCenter.Where(fitnessCenter => fitnessCenter.PasswordOfFitnessCenter > maxID))
            {
                maxID = fitnessCenter.PasswordOfFitnessCenter;
            }
            return maxID + 1;
        }
        public static int generateNewIDForTraining()
        {
            int maxID = -1;
            foreach (var training in AllData.Instance.trainings.Where(training => training.PasswordOfTraining > maxID && (training.Active == false || training.Active == true)))
            {
                maxID = training.PasswordOfTraining;
            }
            return maxID + 1;
        }
        public static int generateNewIDForAddresses()
        {
            int maxID = -1;
            foreach (var address in AllData.Instance.addresses.Where(address => address.PasswordOfAddress > maxID))
            {
                maxID = address.PasswordOfAddress;
            }
            return maxID + 1;
        }
    }
}
