using fitnessCenterProject.CRUD;
using fitnessCenterProject.Enums;
using fitnessCenterProject.Interfaces.ModelsInterfaces;
using fitnessCenterProject.LoadFromDataBase;
using fitnessCenterProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCenterProject.Essentials
{
    class AllData
    {
        public const string dataBaseString = @"Integrated Security=true; Initial Catalog=Fitness_Center; Data Source=DESKTOP-SBS5PG3\SQLEXPRESS";
        private static AllData instance = new AllData();

        ICUFitnessCenter fitnessCenterCRUD;
        ICUInstructor instructorsCRUD;
        ICUAddress addressCRUD;
        ICUBeginner beginnerssCRUD;
        ICUTraining trainingsCRUD;
        ICUAdmin administratorCRUD;

        private AllData()
        {
            fitnessCenterCRUD = new FitnessCenterCRUD();
            instructorsCRUD = new InstructorsCRUD();
            addressCRUD = new AddressCRUD();
            beginnerssCRUD = new BeginnerCRUD();
            trainingsCRUD = new TrainingCRUD();
            administratorCRUD = new AdministratorCRUD();
        }

        public static AllData Instance
        {
            get
            {
                return instance;
            }
        }
        public ObservableCollection<FitnessCenter> fitnessCenter { get; set; }
        public ObservableCollection<Instructor> instructors { get; set; }
        public ObservableCollection<Address> addresses { get; set; }
        public ObservableCollection<Beginner> beginners { get; set; }
        public ObservableCollection<Training> trainings { get; set; }
        public ObservableCollection<Admin> admins { get; set; }

        public void initalize()
        {
            fitnessCenter = new ObservableCollection<FitnessCenter>();
            instructors = new ObservableCollection<Instructor>();
            addresses = new ObservableCollection<Address>();
            beginners = new ObservableCollection<Beginner>();
            trainings = new ObservableCollection<Training>();
            admins = new ObservableCollection<Admin>();
        }
        public void readingData()
        {
            fitnessCenterCRUD.read();
            instructorsCRUD.read();
            addressCRUD.read();
            beginnerssCRUD.read();
            trainingsCRUD.read();
            administratorCRUD.read();
        }
        public void deleteFitnessCenter(int number)
        {
            fitnessCenterCRUD.delete(number);
        }
        public void deleteAddress(int number)
        {
            addressCRUD.delete(number);
        }
        public void deleteTraining(int number)
        {
            trainingsCRUD.delete(number);
        }
        public void deleteInstructor(int number)
        {
            instructorsCRUD.delete(number);
        }
        public void deleteBeginner(int number)
        {
            beginnerssCRUD.delete(number);
        }
        public void deleteAdministrator(int number)
        {
            administratorCRUD.delete(number);
        }
        public void createAddress(int passwordOfAddress, string street, string number, string city, string country)
        {
            addressCRUD.createAddress(passwordOfAddress, street, number, city, country);
        }
        public void createFitnessCenter(int passwordOfFitnessCenter, string nameOfCenter, int addressID)
        {
            fitnessCenterCRUD.createFitnessCenter(passwordOfFitnessCenter, nameOfCenter, addressID);
        }
        public void createTraining(int passwordOfTraining, DateTime dateOfTraining, string stratTime, int durationOfTraining, int instructorID)
        {
            trainingsCRUD.createTraining(passwordOfTraining, dateOfTraining, stratTime, durationOfTraining, instructorID);
        }
        public void createBeginner(int id, string firstName, string lastName, long jmbg, string gender, int addressID, string email, string passwordOfUser)
        {
            beginnerssCRUD.createBeginner(id, firstName, lastName, jmbg, gender, addressID, email, passwordOfUser);
        }
        public void createAdmin(int id, string firstName, string lastName, long jmbg, string gender, int addressID, string email, string passwordOfUser)
        {
            administratorCRUD.createAdministrator(id, firstName, lastName, jmbg, gender, addressID, email, passwordOfUser);
        }
        public void createInstructor(int id, string firstName, string lastName, long jmbg, string gender, int addressID, string email, string passwordOfUser)
        {
            instructorsCRUD.createInstructor(id, firstName, lastName, jmbg, gender, addressID, email, passwordOfUser);
        }

        public void updateBeginner(int id, string firstName, string lastName, long jmbg, string gender, int addressID, string email, string passwordOfUser)
        {
            beginnerssCRUD.updateBeginner(id, firstName, lastName, jmbg, gender, addressID, email, passwordOfUser);
        }

        public void updateAdmin(int id, string firstName, string lastName, long jmbg, string gender, int addressID, string email, string passwordOfUser)
        {
            administratorCRUD.updateAdmin(id, firstName, lastName, jmbg, gender, addressID, email, passwordOfUser);
        }

        public void updateInstructor(int id, string firstName, string lastName, long jmbg, string gender, int addressID, string email, string passwordOfUser)
        {
            instructorsCRUD.updateInstructor(id, firstName, lastName, jmbg, gender, addressID, email, passwordOfUser);
        }

        public void updateAddress(int id, string street, int number, string city, string country)
        {
            addressCRUD.updateAddress(id, street, number, city, country);
        }
        public void updateFitnessCenter(int id, string nameOfCenter, int addressID)
        {
            fitnessCenterCRUD.updateFitnessCenter(id, nameOfCenter, addressID);
        }

        public void cancelReservationOfTraining(int trainingID)
        {
            trainingsCRUD.cancelReservationOfTraining(trainingID);
        }

        public void bookTraining(int trainingID, int beginnerID)
        {
            trainingsCRUD.bookTraining(trainingID, beginnerID);
        }

        public void updateTraining(Training training)
        {
            trainingsCRUD.updateTraining(training);
        }
    }
}
