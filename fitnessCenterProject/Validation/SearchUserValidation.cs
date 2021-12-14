using fitnessCenterProject.Essentials;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCenterProject.Validation
{
    class SearchUserValidation
    {
        public static ObservableCollection<Models.Instructor> checkInputsInstructor(string name, string lastName, string email, int foundAddress)
        {
            ObservableCollection<Models.Instructor> instructorCollection = new ObservableCollection<Models.Instructor>();
            foreach (Models.Instructor instructor in AllData.Instance.instructors)
            {
                if ((name.Equals("") || name.Equals(instructor.FirstName, StringComparison.OrdinalIgnoreCase)) &&
                    (lastName.Equals("") || lastName.Equals(instructor.LastName, StringComparison.OrdinalIgnoreCase)) &&
                    (email.Equals("") || email.Equals(instructor.Email, StringComparison.OrdinalIgnoreCase)) &&
                    (foundAddress == 0 || foundAddress.Equals(instructor.AddressID)))
                {
                    instructorCollection.Add(instructor);
                }
            }
            return instructorCollection;
        }
        public static ObservableCollection<Models.Instructor> checkFirstNameInstructor(string firstName)
        {
            ObservableCollection<Models.Instructor> instructorCollection = new ObservableCollection<Models.Instructor>();
            foreach (Models.Instructor instructor in AllData.Instance.instructors)
            {
                if(instructor.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase))
                {
                    instructorCollection.Add(instructor);
                }
            }
            return instructorCollection;
        }
        public static ObservableCollection<Models.Instructor> checkLastNameInstructor(string lastName)
        {
            ObservableCollection<Models.Instructor> instructorCollection = new ObservableCollection<Models.Instructor>();
            foreach (Models.Instructor instructor in AllData.Instance.instructors)
            {
                if (instructor.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
                {
                    instructorCollection.Add(instructor);
                }
            }
            return instructorCollection;
        }
        public static ObservableCollection<Models.Instructor> checkEmailInstructor(string email)
        {
            ObservableCollection<Models.Instructor> instructorCollection = new ObservableCollection<Models.Instructor>();
            foreach (Models.Instructor instructor in AllData.Instance.instructors)
            {
                if (instructor.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                {
                    instructorCollection.Add(instructor);
                }
            }
            return instructorCollection;
        }
        public static ObservableCollection<Models.Instructor> checkAddressInstructor(int address)
        {
            ObservableCollection<Models.Instructor> instructorCollection = new ObservableCollection<Models.Instructor>();
            foreach (Models.Instructor instructor in AllData.Instance.instructors)
            {
                if (instructor.AddressID.Equals(address))
                {
                    instructorCollection.Add(instructor);
                }
            }
            return instructorCollection;
        }

        public static ObservableCollection<Models.Beginner> checkInputsBeginner(string name, string lastName, string email, int foundAddress)
        {
            ObservableCollection<Models.Beginner> beginnerCollection = new ObservableCollection<Models.Beginner>();
            foreach (Models.Beginner beginner in AllData.Instance.beginners)
            {
                if ((name.Equals("") || name.Equals(beginner.FirstName, StringComparison.OrdinalIgnoreCase)) &&
                    (lastName.Equals("") || lastName.Equals(beginner.LastName, StringComparison.OrdinalIgnoreCase)) &&
                    (email.Equals("") || email.Equals(beginner.Email, StringComparison.OrdinalIgnoreCase)) &&
                    (foundAddress == 0 || foundAddress.Equals(beginner.AddressID)))
                {
                    beginnerCollection.Add(beginner);
                }
            }
            return beginnerCollection;
        }
        public static ObservableCollection<Models.Beginner> checkFirstNameBeginner(string firstName)
        {
            ObservableCollection<Models.Beginner> beginnerCollection = new ObservableCollection<Models.Beginner>();
            foreach (Models.Beginner beginner in AllData.Instance.beginners)
            {
                if (beginner.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase))
                {
                    beginnerCollection.Add(beginner);
                }
            }
            return beginnerCollection;
        }
        public static ObservableCollection<Models.Beginner> checkLastNameBeginner(string lastName)
        {
            ObservableCollection<Models.Beginner> beginnerCollection = new ObservableCollection<Models.Beginner>();
            foreach (Models.Beginner beginner in AllData.Instance.beginners)
            {
                if (beginner.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
                {
                    beginnerCollection.Add(beginner);
                }
            }
            return beginnerCollection;
        }
        public static ObservableCollection<Models.Beginner> checkEmailBeginner(string email)
        {
            ObservableCollection<Models.Beginner> beginnerCollection = new ObservableCollection<Models.Beginner>();
            foreach (Models.Beginner beginner in AllData.Instance.beginners)
            {
                if (beginner.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                {
                    beginnerCollection.Add(beginner);
                }
            }
            return beginnerCollection;
        }
        public static ObservableCollection<Models.Beginner> checkAddressBeginner(int address)
        {
            ObservableCollection<Models.Beginner> beginnerCollection = new ObservableCollection<Models.Beginner>();
            foreach (Models.Beginner beginner in AllData.Instance.beginners)
            {
                if (beginner.AddressID.Equals(address))
                {
                    beginnerCollection.Add(beginner);
                }
            }
            return beginnerCollection;
        }
    }
}
