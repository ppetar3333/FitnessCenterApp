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
    class InstructorsCRUD : ICUInstructor, IRDModels
    {
        public void read()
        {
            AllData.Instance.instructors = new ObservableCollection<Instructor>();
            using (SqlConnection conn = new SqlConnection(AllData.dataBaseString))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"select * from Instructor where active=1";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AllData.Instance.instructors.Add(new Instructor
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Jmbg = reader.GetInt64(3),
                        Gender = (Gender)Enum.Parse(typeof(Gender), reader.GetString(4)),
                        AddressID = reader.GetInt32(5),
                        Email = reader.GetString(6),
                        PasswordOfUser = reader.GetString(7),
                        FitnessCenterID = reader.GetInt32(8),
                        TypeOfUser = reader.GetString(9),
                        Active = reader.GetBoolean(10)
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
                    new SqlCommand("UPDATE Instructor SET active=0" +
                        " WHERE id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", number);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void createInstructor(int id, string firstName, string lastName, long jmbg, string gender, int addressID, string email, string passwordOfUser)
        {
            using (SqlConnection conn = new SqlConnection(AllData.dataBaseString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("insert into Instructor values(@id,@firstName,@lastName,@jmbg,@gender,@addressID,@email,@passwordOfUser,@fitnessCenter,@typeOfUser,@active)", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@jmbg", jmbg);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@addressID", addressID);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@passwordOfUser", passwordOfUser);
                    cmd.Parameters.AddWithValue("@fitnessCenter", 1);
                    cmd.Parameters.AddWithValue("@typeOfUser", "instruktor");
                    cmd.Parameters.AddWithValue("@active", 1);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        public void updateInstructor(int id, string firstName, string lastName, long jmbg, string gender, int addressID, string email, string passwordOfUser)
        {
            using (SqlConnection conn = new SqlConnection(AllData.dataBaseString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("update Instructor set firstName=@firstName,lastName=@lastName,jmbg=@jmbg,gender=@gender,addressID=@addressID," +
                    "email=@email,passwordOfUser=@passwordOfUser where id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@jmbg", jmbg);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@addressID", addressID);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@passwordOfUser", passwordOfUser);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
