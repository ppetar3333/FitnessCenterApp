using fitnessCenterProject.LoadFromDataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCenterProject.Models
{
    public class FitnessCenter : INotifyPropertyChanged
    {
        private int passwordOfFitnessCenter;
        private string nameOfCenter;
        private int addressID;
        private bool active;

        public FitnessCenter() { }
        public FitnessCenter(int passwordOfFitnessCenter, string nameOfCenter, int addressID, bool active)
        {
            this.passwordOfFitnessCenter = passwordOfFitnessCenter;
            this.nameOfCenter = nameOfCenter;
            this.addressID = addressID;
            this.active = active;
        }

        public int PasswordOfFitnessCenter { get => passwordOfFitnessCenter; set { passwordOfFitnessCenter = value; OnPropertyChanged("id"); } }
        public string NameOfCenter { get => nameOfCenter; set { nameOfCenter = value; OnPropertyChanged("nameOfCenter"); }}
        public int AddressID { get => addressID; set { addressID = value; OnPropertyChanged("addressID"); }}
        public bool Active { get => active; set { active = value; OnPropertyChanged("active"); }}

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
