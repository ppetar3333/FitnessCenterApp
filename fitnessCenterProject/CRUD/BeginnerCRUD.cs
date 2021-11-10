﻿using fitnessCenterProject.Enums;
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
    class BeginnerCRUD : ICUBeginner, IRDModels
    {
        public void read()
        {
            AllData.Instance.beginners = new ObservableCollection<Beginner>();
            using (SqlConnection conn = new SqlConnection(AllData.dataBaseString))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"select * from Beginner where active=1";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AllData.Instance.beginners.Add(new Beginner
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Jmbg = reader.GetInt64(3),
                        Gender = (Gender)Enum.Parse(typeof(Gender), reader.GetString(4)),
                        AddressID = reader.GetInt32(5),
                        Email = reader.GetString(6),
                        PasswordOfUser = reader.GetString(7),
                        TypeOfUser = reader.GetString(8),
                        Active = reader.GetBoolean(9)
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
                    new SqlCommand("UPDATE Beginner SET active=0" +
                        " WHERE id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", number);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void createBeginner(int id, string firstName, string lastName, long jmbg, string gender, int addressID, string email, string passwordOfUser)
        {
            using (SqlConnection conn = new SqlConnection(AllData.dataBaseString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("insert into Beginner values(@id,@firstName,@lastName,@jmbg,@gender,@addressID,@email,@passwordOfUser,@typeOfUser,@active)", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@jmbg", jmbg);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@addressID", addressID);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@passwordOfUser", passwordOfUser);
                    cmd.Parameters.AddWithValue("@typeOfUser", "polaznik");
                    cmd.Parameters.AddWithValue("@active", 1);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void updateBeginner(int id, string firstName, string lastName, long jmbg, string gender, int addressID, string email, string passwordOfUser)
        {
            using (SqlConnection conn = new SqlConnection(AllData.dataBaseString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("update Beginner set firstName=@firstName,lastName=@lastName,jmbg=@jmbg,gender=@gender,addressID=@addressID," +
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
