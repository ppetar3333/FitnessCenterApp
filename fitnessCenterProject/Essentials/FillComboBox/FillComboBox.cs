using fitnessCenterProject.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace fitnessCenterProject.Essentials.FillComboBox
{
    class FillComboBox
    {
        public static void fillComboBoxGender(ComboBox comboBoxData)
        {
            comboBoxData.ItemsSource = Enum.GetValues(typeof(Gender)).Cast<Gender>();
        }

        public static void fillComboBoxAddress(ComboBox comboBoxData)
        {
            string selectAddresses = "select * from Addresses";
            SqlConnection connection = new SqlConnection(AllData.dataBaseString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(selectAddresses, connection);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                comboBoxData.Items.Add(dataReader[1] + "," + dataReader[2] + "," + dataReader[3]);
            }
        }

        public static void fillComboBoxInstructor(ComboBox comboBoxData)
        {
            string selectInstructors = "select * from Instructor";
            SqlConnection connection = new SqlConnection(AllData.dataBaseString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(selectInstructors, connection);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                comboBoxData.Items.Add(dataReader[1]);
            }
        }
    }
}
