using fitnessCenterProject.Essentials;
using fitnessCenterProject.Models;
using fitnessCenterProject.Windows;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace fitnessCenterProject
{
    public partial class MainWindow : Window
    {
        string beginnerData, instructorData, administratorData;
        int countAdminstrator, countInstructor, countBeginner;
        private SqlCommand sqlCommandAdministrator, sqlCommandInstructor, sqlCommandBeginner;
        public MainWindow()
        {
            InitializeComponent();
            textBoxJMBG.Focus();
            AllData.Instance.readingData();
        }
        private void registrationWindow(object sender, RoutedEventArgs e)
        {
            Registration registrationWindow = new Registration();
            registrationWindow.Show();
            this.Close();
        }

        private void exitTheApp(object sender, RoutedEventArgs e)
        {
            ExitTheApp.exitTheApp(this);
        }

        private void openGuestWindow(object sender, RoutedEventArgs e)
        {
            Guest guestWindow = new Guest();
            guestWindow.Show();
            this.Close();
        }
        private void loggedInMessage(string userName, Window windowToShow)
        {
            MessageBox.Show("You are logged in as " + userName);
            this.Close();
            windowToShow.Show();
        }

        private void sqlCommandUsers(SqlCommand sqlCommand)
        {
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.AddWithValue("@jmbg", textBoxJMBG.Text);
            sqlCommand.Parameters.AddWithValue("@passwordOfUser", textBoxPassword.Password);
        }
        private void declaringNamesOfDataBase()
        {
            beginnerData = "select count(1) from Beginner where jmbg=@jmbg and passwordOfUser=@passwordOfUser and active=1";
            instructorData = "select count(1) from Instructor where jmbg=@jmbg and passwordOfUser=@passwordOfUser and active=1";
            administratorData = "select count(1) from Administrator where jmbg=@jmbg and passwordOfUser=@passwordOfUser and active=1";
        }
        private void logInButton(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(AllData.dataBaseString);
            try
            {
                sqlConnection.Open();

                declaringNamesOfDataBase();

                sqlCommandAdministrator = new SqlCommand(administratorData, sqlConnection);
                sqlCommandInstructor = new SqlCommand(instructorData, sqlConnection);
                sqlCommandBeginner = new SqlCommand(beginnerData, sqlConnection);

                sqlCommandUsers(sqlCommandAdministrator);
                sqlCommandUsers(sqlCommandInstructor);
                sqlCommandUsers(sqlCommandBeginner);

                countAdminstrator = (int) sqlCommandAdministrator.ExecuteScalar();
                countInstructor = (int) sqlCommandInstructor.ExecuteScalar();
                countBeginner = (int) sqlCommandBeginner.ExecuteScalar();

                if (countBeginner > 0)
                {
                    loggedInMessage("Begginer.", new BeginnerMainWindow(textBoxJMBG.Text));
                } 
                else if (countAdminstrator > 0)
                {
                    loggedInMessage("Administrator.", new AdministratorMainWindow(textBoxJMBG.Text));
                }
                else if (countInstructor > 0)
                {
                    loggedInMessage("Instructor.", new InstructorMainWindow(textBoxJMBG.Text));
                }
                else
                {
                    MessageBox.Show("JMBG or password is incorrect.");
                    textBoxJMBG.Clear();
                    textBoxPassword.Clear();
                    textBoxJMBG.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
