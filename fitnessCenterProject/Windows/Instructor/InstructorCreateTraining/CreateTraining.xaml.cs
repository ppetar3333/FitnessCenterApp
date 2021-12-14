using fitnessCenterProject.Essentials;
using fitnessCenterProject.Models;
using fitnessCenterProject.Validation;
using fitnessCenterProject.Windows.SearchBY;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace fitnessCenterProject.Windows.Instructor.InstructorCreateTraining
{
    public partial class CreateTraining : Window
    {
        private string jmbgOfInstructor;
        private int trainingID;
        private string startingTime;
        private DateTime startingTimeDateTime;
        private int duration;
        private DateTime dateTimeNow;
        private string[] splitStartingTime;
        private TimeSpan differenceStartTime;
        private double totalMinutesStartTime;
        private double sumMinutes;
        private TimeSpan timeSpanMinutes;
        private string hoursString;
        private Models.Instructor instructor;
        private ObservableCollection<Models.Training> instructorTrainings;
        private string startTimeString;
        private DateTime startTimeDT;
        private DateTime timeOfNow;
        public CreateTraining(string jmbgOfInstructor)
        {
            this.jmbgOfInstructor = jmbgOfInstructor;
            InitializeComponent();
        }

        private void close(object sender, RoutedEventArgs e)
        {
            showInstructorMainWindow();
            this.Close();
        }

        private void showInstructorMainWindow()
        {
            InstructorMainWindow instructorMainWindow = new InstructorMainWindow(jmbgOfInstructor);
            instructorMainWindow.Show();
        }
        private List<DateTime> getDateNowFromTraining(List<DateTime> dateOfTraining)
        {
            List<DateTime> list = new List<DateTime>();

            foreach (DateTime dt in dateOfTraining)
            {
                if (dateTimeNow.Date == dt.Date)
                {
                    list.Add(dt);
                }
            }

            return list;
        }
        private void getDataFromInputs()
        {
            trainingID = GenerateNewID.generateNewIDForTraining();
            startingTime = startTime.Text;
            startingTimeDateTime = DateTime.ParseExact(startingTime, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            duration = int.Parse(durationOfTraining.Text);
            dateTimeNow = DateTime.Now;
        }
        private void convertDataFromInputs()
        {
            splitStartingTime = startingTime.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            differenceStartTime = new TimeSpan(Convert.ToInt32(splitStartingTime[0]), Convert.ToInt32(splitStartingTime[1]), 0);
            totalMinutesStartTime = differenceStartTime.TotalMinutes;
            sumMinutes = totalMinutesStartTime + duration;
            timeSpanMinutes = TimeSpan.FromMinutes(sumMinutes);
            hoursString = string.Format("{0:00}:{1:00}", (int)timeSpanMinutes.TotalHours, timeSpanMinutes.Minutes);
        }
        private List<DateTime> getDateFromTraining()
        {
            List<DateTime> dateOfTraining = new List<DateTime>();

            foreach (Models.Training training in instructorTrainings)
            {
                dateOfTraining.Add(training.DateOfTraining);
            }

            return dateOfTraining;
        }
        private List<Training> checkDateNowFromTraining(List<DateTime> list)
        {
            List<Models.Training> trainingDateTimeNow = new List<Models.Training>();

            foreach (DateTime dt in list)
            {
                foreach (Models.Training training in instructorTrainings)
                {
                    if (dt.Date == training.DateOfTraining.Date)
                    {
                        trainingDateTimeNow.Add(training);
                    }
                }
            }
            trainingDateTimeNow = new List<Models.Training>(trainingDateTimeNow.Distinct());
            return trainingDateTimeNow;
        }
        private List<int> checkInstructorAvilability(List<Training> trainingDateTimeNow)
        {
            List<DateTime> listOfStartTraining = new List<DateTime>();
            List<DateTime> listOfEndTraining = new List<DateTime>();
            List<int> trainingIsRunning = new List<int>();

            if (trainingDateTimeNow.Count > 0)
            {
                foreach (Models.Training training in trainingDateTimeNow)
                {
                    string startTime = training.StartTime;
                    DateTime trainingStartTime = DateTime.ParseExact(startTime, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                    listOfStartTraining.Add(trainingStartTime);
                    double durationOfTraining = training.DuraionOfTraining;
                    string[] splitStartTime = startTime.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    TimeSpan difference = new TimeSpan(Convert.ToInt32(splitStartTime[0]), Convert.ToInt32(splitStartTime[1]), 0);
                    double minutesOfStartTime = difference.TotalMinutes;
                    double endOfTrainingMinutes = minutesOfStartTime + durationOfTraining;
                    TimeSpan spWorkMin = TimeSpan.FromMinutes(endOfTrainingMinutes);
                    string endOfTrainingHourse = string.Format("{0:00}:{1:00}", (int)spWorkMin.TotalHours, spWorkMin.Minutes);
                    DateTime trainingEndTime = DateTime.ParseExact(endOfTrainingHourse, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                    listOfEndTraining.Add(trainingEndTime);
                    if (startingTimeDateTime >= trainingStartTime &&
                        startingTimeDateTime <= trainingEndTime)
                    {
                        trainingIsRunning.Add(1);
                    }
                }
            }

            return trainingIsRunning;
        }
        private void createNewTraining(int trainingID, DateTime dateOfTraining, string startingTime, int durationOfTraining, int instructorID)
        {
            AllData.Instance.createTraining(trainingID, dateOfTraining, startingTime, durationOfTraining, instructorID);
            MessageBox.Show("You have successfuly added new training.");
            showInstructorMainWindow();
            this.Close();
        }
        private void getValidatedDataFromInput()
        {
            getDataFromInputs();

            convertDataFromInputs();

            instructor = SearchInstructorBY.searchInstructorBYjmbg(jmbgOfInstructor);
            instructorTrainings = SearchTrainingsBY.findInstructorTraining(instructor.Id);
            
            List<DateTime> dateOfTraining = getDateFromTraining();

            List<DateTime> list = getDateNowFromTraining(dateOfTraining);

            List<Training> trainingDateTimeNow = checkDateNowFromTraining(list);

            List<int> trainingIsRunning = checkInstructorAvilability(trainingDateTimeNow);

            if (instructorTrainings.Count > 0)
            {
                if (list.Count > 0)
                {
                    if (trainingIsRunning.Count > 0)
                    {
                        MessageBox.Show("Sorry but instructor " + instructor.FirstName + " now have training. Please try with another schedule.");
                    }
                    else
                    {
                        createNewTraining(trainingID, dateTimeNow, startingTime, duration, instructor.Id);
                    }
                }
                else
                {
                    createNewTraining(trainingID, dateTimeNow, startingTime, duration, instructor.Id);
                }
            }
            else
            {
                createNewTraining(trainingID, dateTimeNow, startingTime, duration, instructor.Id);
            }
        }
        private void create(object sender, RoutedEventArgs e)
        {
            if (ModelValidation.createTrainingInstructorValidation(startTime, durationOfTraining))
            {
                try
                {
                    startTimeString = startTime.Text;
                    startTimeDT = DateTime.ParseExact(startTimeString, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                    timeOfNow = DateTime.Now;
                    if (startTimeDT < timeOfNow)
                    {
                        MessageBox.Show("Sory but entered time has passed.");
                    }
                    else
                    {
                        getValidatedDataFromInput();
                    }
                }
                catch
                {
                    MessageBox.Show("Start time needs to be in format HH:MM.");
                }
            }
        }
    }
}
