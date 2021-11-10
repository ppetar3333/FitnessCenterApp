using fitnessCenterProject.Essentials;
using fitnessCenterProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace fitnessCenterProject.Windows.SearchBY
{
    class SearchTrainingsBY
    {
        public static Training searchTrainingBYid(string singleID)
        {
            foreach (var tr in AllData.Instance.trainings.Where(tr => tr.PasswordOfTraining.ToString().Equals(singleID)))
            {
                return tr;
            }

            return null;
        }

        public static ObservableCollection<Training> findBeginnerTraining(int idOfBeginner)
        {
            ObservableCollection<Training> trainingsBeginner = new ObservableCollection<Training>();
            foreach (var training in AllData.Instance.trainings.Where(training => training.BegginerID == idOfBeginner))
            {
                trainingsBeginner.Add(training);
            }

            return trainingsBeginner;
        }

        public static ObservableCollection<Training> findInstructorTraining(int idOfInstructor)
        {
            ObservableCollection<Training> trainingsInstructor = new ObservableCollection<Training>();
            foreach (var training in AllData.Instance.trainings.Where(training => training.InstructorID == idOfInstructor))
            {
                trainingsInstructor.Add(training);
            }

            return trainingsInstructor;
        }

        public static ObservableCollection<Training> findTrainingBYdate(string date, int instructorId)
        {
            ObservableCollection<Training> foundedTrainings = new ObservableCollection<Training>();
            foreach (var training in AllData.Instance.trainings.Where(training => training.DateOfTraining.ToString().Contains(date) && training.InstructorID == instructorId))
            {
                foundedTrainings.Add(training);
            }

            return foundedTrainings;
        }
    }
}
