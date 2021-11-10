using fitnessCenterProject.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCenterProject.Models
{
    public class Instructor : User
    {
        private int fitnessCenterID;
        public Instructor() { }
        public Instructor(int id, string firstName, string lastName, long jmbg, Gender gender, int addressID, string email, string passwordOfUser, string typeOfUser, bool active, int fitnessCenterID) : base(id, firstName, lastName, jmbg, gender, addressID, email, passwordOfUser, typeOfUser, active)
        {
            this.fitnessCenterID = fitnessCenterID;
        }

        public int FitnessCenterID { get => fitnessCenterID; set { fitnessCenterID = value; OnPropertyChanged("fitnessCenterID"); } }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
