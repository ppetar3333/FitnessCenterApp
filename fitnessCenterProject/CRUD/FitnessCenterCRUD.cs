using fitnessCenterProject.Essentials;
using fitnessCenterProject.Interfaces.ModelsInterfaces;
using fitnessCenterProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCenterProject.LoadFromDataBase
{
    class FitnessCenterCRUD : ICUFitnessCenter, IRDModels
    {

        public void read()
        {
            AllData.Instance.fitnessCenter = new ObservableCollection<FitnessCenter>();
            using (SqlConnection conn = new SqlConnection(AllData.dataBaseString))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"select * from FitnessCenter where active=1";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AllData.Instance.fitnessCenter.Add(new FitnessCenter
                    {
                        PasswordOfFitnessCenter = reader.GetInt32(0),
                        NameOfCenter = reader.GetString(1),
                        AddressID = reader.GetInt32(2),
                        Active = reader.GetBoolean(3)
                    });

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
                    new SqlCommand("UPDATE FitnessCenter SET active=0" +
                        " WHERE id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", number);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void createFitnessCenter(int passwordOfFitnessCenter, string nameOfCenter, int addressID)
        {
            using (SqlConnection conn = new SqlConnection(AllData.dataBaseString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("insert into FitnessCenter values(@passwordOfFitnessCenter,@nameOfCenter,@addressID,@active)", conn))
                {
                    cmd.Parameters.AddWithValue("@passwordOfFitnessCenter", passwordOfFitnessCenter);
                    cmd.Parameters.AddWithValue("@nameOfCenter", nameOfCenter);
                    cmd.Parameters.AddWithValue("@addressID", addressID);
                    cmd.Parameters.AddWithValue("@active", 1);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void updateFitnessCenter(int id, string nameOfCenter, int addressID)
        {
            using (SqlConnection conn = new SqlConnection(AllData.dataBaseString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("update FitnessCenter set nameOfCenter=@nameOfCenter,addressID=@addressID where id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nameOfCenter", nameOfCenter);
                    cmd.Parameters.AddWithValue("@addressID", addressID);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
