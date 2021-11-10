using fitnessCenterProject.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCenterProject.Models
{
    public class Training : INotifyPropertyChanged
    {
        private int passwordOfTraining;
        private DateTime dateOfTraining;
        private string startTime;
        private int duraionOfTraining;
        private TrainingStatus trainingStatus;
        private int instructorID;
        private int? begginerID;
        private bool active;

        public Training() { }
        public Training(int passwordOfTraining, DateTime dateOfTraining, string startTime, int duraionOfTraining, TrainingStatus trainingStatus, int instructorID, int begginerID, bool active)
        {
            this.passwordOfTraining = passwordOfTraining;
            this.dateOfTraining = dateOfTraining;
            this.startTime = startTime;
            this.duraionOfTraining = duraionOfTraining;
            this.trainingStatus = trainingStatus;
            this.instructorID = instructorID;
            this.begginerID = begginerID;
            this.active = active;
        }

        public int PasswordOfTraining { get => passwordOfTraining; set { passwordOfTraining = value; OnPropertyChanged("PasswordOfTraining"); } }
        public DateTime DateOfTraining { get => dateOfTraining; set { dateOfTraining = value; OnPropertyChanged("DateOfTraining"); }}
        public string StartTime { get => startTime; set { startTime = value; OnPropertyChanged("StartTime"); }}
        public int DuraionOfTraining { get => duraionOfTraining; set { duraionOfTraining = value; OnPropertyChanged("DuraionOfTraining"); }}
        public TrainingStatus TrainingStatus { get => trainingStatus; set { trainingStatus = value; OnPropertyChanged("TrainingStatus"); }}
        public int InstructorID { get => instructorID; set { instructorID = value; OnPropertyChanged("InstructorID"); }}
        public int? BegginerID { get => begginerID; set { begginerID = value; OnPropertyChanged("BegginerID"); }}
        public bool Active { get => active; set { active = value; OnPropertyChanged("Active"); }}

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
