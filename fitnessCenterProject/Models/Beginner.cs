using fitnessCenterProject.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCenterProject.Models
{
    public class Beginner : User
    {
        public Beginner() { }
        public Beginner(int id, string firstName, string lastName, long jmbg, Gender gender, int addressID, string email, string passwordOfUser, string typeOfUser, bool active) : base(id, firstName, lastName, jmbg, gender, addressID, email, passwordOfUser, typeOfUser, active)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
