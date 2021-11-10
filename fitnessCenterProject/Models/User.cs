using fitnessCenterProject.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCenterProject.Models
{
    public abstract class User : INotifyPropertyChanged
    {
        protected int id;
        protected string firstName;
        protected string lastName;
        protected long jmbg;
        protected Gender gender;
        protected int addressID;
        protected string email;
        protected string passwordOfUser;
        protected string typeOfUser;
        protected bool active;

        protected User() { }
        protected User(int id, string firstName, string lastName, long jmbg, Gender gender, int addressID, string email, string passwordOfUser, string typeOfUser, bool active)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.jmbg = jmbg;
            this.gender = gender;
            this.addressID = addressID;
            this.email = email;
            this.passwordOfUser = passwordOfUser;
            this.typeOfUser = typeOfUser;
            this.active = active;
        }

        public int Id { get => id; set { id = value; OnPropertyChanged("id"); } }
        public string FirstName { get => firstName; set { firstName = value; OnPropertyChanged("firstName"); } }
        public string LastName { get => lastName; set { lastName = value; OnPropertyChanged("lastName"); } }
        public long Jmbg { get => jmbg; set { jmbg = value; OnPropertyChanged("jmbg"); } }
        public Gender Gender { get => gender; set { gender = value; OnPropertyChanged("gender"); } }
        public int AddressID { get => addressID; set { addressID = value; OnPropertyChanged("addressID"); } }
        public string Email { get => email; set { email = value; OnPropertyChanged("email"); } }
        public string PasswordOfUser { get => passwordOfUser; set { passwordOfUser = value; OnPropertyChanged("passwordOfUser"); } }
        public string TypeOfUser { get => typeOfUser; set { typeOfUser = value; OnPropertyChanged("typeOfUser"); } }
        public bool Active { get => active; set { active = value; OnPropertyChanged("active"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
