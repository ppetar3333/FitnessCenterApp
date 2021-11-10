using fitnessCenterProject.Enums;
using fitnessCenterProject.Essentials;
using fitnessCenterProject.Interfaces.ModelsInterfaces;
using fitnessCenterProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCenterProject.CRUD
{
    class TrainingCRUD : ICUTraining, IRDModels
    {
        public void read()
        {
            AllData.Instance.trainings = new ObservableCollection<Training>();
            using (SqlConnection conn = new SqlConnection(AllData.dataBaseString))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"select * from TrainingSchedule where active=1";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int passwordOfTraining = reader.GetInt32(0);
                    DateTime dateOfTraining = reader.GetDateTime(1);
                    string startTime = reader.GetString(2);
                    int duraionOfTraining = reader.GetInt32(3);
                    TrainingStatus trainingStatus = (TrainingStatus)Enum.Parse(typeof(TrainingStatus), reader.GetString(4));
                    int instructorID = reader.GetInt32(5);
                    int beginnerID = reader.GetOrdinal("Beginner");
                    int beginnerIDToShow;
                    if (reader.IsDBNull(beginnerID))
                    {
                        beginnerIDToShow = 0;
                    }
                    else
                    {
                        beginnerIDToShow = reader.GetInt32(beginnerID);
                    }
                    bool active = reader.GetBoolean(7);
                    Training training = new Training(passwordOfTraining, dateOfTraining, startTime, duraionOfTraining, trainingStatus, instructorID, beginnerIDToShow, active);
                    AllData.Instance.trainings.Add(training);
                }
                reader.Close();
            }
        }
        public void delete(int number)
        {
            using (SqlConnection conn =
            new SqlConnection(AllData.dataBaseString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("UPDATE TrainingSchedule SET active=0" +
                        " WHERE id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", number);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void createTraining(int passwordOfTraining, DateTime dateOfTraining, string stratTime, int durationOfTraining, int instructorID)
        {
            using (SqlConnection conn = new SqlConnection(AllData.dataBaseString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("insert into TrainingSchedule values(@id,@dateOfTraining,@stratTime,@durationOfTraining,@statusOfTraining,@instructor,@beginner,@active)", conn))
                {
                    cmd.Parameters.AddWithValue("@id", passwordOfTraining);
                    cmd.Parameters.AddWithValue("@dateOfTraining", dateOfTraining);
                    cmd.Parameters.AddWithValue("@stratTime", stratTime);
                    cmd.Parameters.AddWithValue("@durationOfTraining", durationOfTraining);
                    cmd.Parameters.AddWithValue("@statusOfTraining", TrainingStatus.slobodan.ToString());
                    cmd.Parameters.AddWithValue("@instructor", instructorID);
                    cmd.Parameters.AddWithValue("@beginner", DBNull.Value);
                    cmd.Parameters.AddWithValue("@active", 1);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        public void cancelReservationOfTraining(int id)
        {
            using (SqlConnection conn =
            new SqlConnection(AllData.dataBaseString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("UPDATE TrainingSchedule SET statusOfTraining='slobodan', beginner=null" +
                        " WHERE id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void bookTraining(int id, int beginnerID)
        {
            using (SqlConnection conn =
            new SqlConnection(AllData.dataBaseString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("UPDATE TrainingSchedule SET statusOfTraining='rezervisan', beginner=@beginner" +
                        " WHERE id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@beginner", beginnerID);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
