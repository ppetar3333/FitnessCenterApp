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
    class AddressCRUD : ICUAddress, IRDModels
    {
        public void read()
        {
            AllData.Instance.addresses = new ObservableCollection<Address>();
            using (SqlConnection conn = new SqlConnection(AllData.dataBaseString))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"select * from Addresses where active=1";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AllData.Instance.addresses.Add(new Address
                    {
                        PasswordOfAddress = reader.GetInt32(0),
                        Street = reader.GetString(1),
                        Number = reader.GetString(2),
                        City = reader.GetString(3),
                        Country = reader.GetString(4),
                        Active = reader.GetBoolean(5)
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
                    new SqlCommand("UPDATE Addresses SET active=0" +
                        " WHERE id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", number);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void createAddress(int passwordOfAddress, string street, string number, string city, string country)
        {
            using (SqlConnection conn = new SqlConnection(AllData.dataBaseString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("insert into Addresses values(@passwordOfAddress,@street,@number,@city,@country,@active)", conn))
                {
                    cmd.Parameters.AddWithValue("@passwordOfAddress", passwordOfAddress);
                    cmd.Parameters.AddWithValue("@street", street);
                    cmd.Parameters.AddWithValue("@number", number);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@country", country);
                    cmd.Parameters.AddWithValue("@active", 1);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void updateAddress(int id, string street, int number, string city, string country)
        {
            using (SqlConnection conn = new SqlConnection(AllData.dataBaseString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("update Addresses set street=@street,number=@number,city=@city,country=@country where id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@street", street);
                    cmd.Parameters.AddWithValue("@number", number);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@country", country);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
