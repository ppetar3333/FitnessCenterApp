using fitnessCenterProject.Essentials;
using fitnessCenterProject.Essentials.ChangeVisibility;
using fitnessCenterProject.Essentials.FillDataGrid;
using fitnessCenterProject.Windows.SearchBY;
using System;
using System.Collections.Generic;
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

namespace fitnessCenterProject.Windows.Administrator.AdminOptions
{
    public partial class AdministratorWindow : Window
    {
        private Models.Admin admin;
        private Models.Admin loggedInAdmin;
        private string jmbgOfUser;
        public AdministratorWindow(string jmbgOfUser)
        {
            InitializeComponent();
            this.jmbgOfUser = jmbgOfUser;
            FillDataGrid.fillDataGridAdmins(adminInfo);
            FillDataGrid.fillDataGridAdmins(adminInfo);
            loggedInAdmin = SearchAdminBY.searchAdminBYjmbg(jmbgOfUser);
        }

        private void changeVisibilityAdmins(object sender, EventArgs e)
        {
            ChangeVisibilityDataGrid.changeVisibilityOfBeginners(adminInfo);
        }
        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void createAdmin(object sender, RoutedEventArgs e)
        {
            CreateAdmin create = new CreateAdmin(jmbgOfUser);
            create.Show();
            this.Close();
        }

        private void updateAdmin(object sender, RoutedEventArgs e)
        {
            var selectedAdmin = adminInfo.SelectedItem;
            if (selectedAdmin != null)
            {
                admin = (Models.Admin)selectedAdmin;
                UpdateAdmin update = new UpdateAdmin(admin.Jmbg.ToString(), jmbgOfUser);
                update.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("You need to select column.");
            }
        }

        private void deleteAdmin(object sender, RoutedEventArgs e)
        {
            object selectedAdmin = adminInfo.SelectedItem;
            if (selectedAdmin != null)
            {
                admin = (Models.Admin)selectedAdmin;
                if(admin.Jmbg != loggedInAdmin.Jmbg)
                {
                    if (MessageBox.Show("Do you really want to delete this admin?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        AllData.Instance.deleteAdministrator(admin.Id);
                        AllData.Instance.admins.Remove(admin);
                        FillDataGrid.fillDataGridAdmins(adminInfo);
                        MessageBox.Show("You have successfuly deleted admin " + admin.FirstName);
                        FillDataGrid.fillDataGridAdmins(adminInfo);
                    }
                } 
                else
                {
                    MessageBox.Show("You can not delete your self.");
                }
            }
            else
            {
                MessageBox.Show("Please select column.");
            }
        }
    }
}
