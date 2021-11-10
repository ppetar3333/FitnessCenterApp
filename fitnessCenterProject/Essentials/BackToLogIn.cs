using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace fitnessCenterProject
{
    class BackToLogIn
    {
        public static void backToLogInWindow(Window window)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Do you want to go back to LogIn window?", "Decision window", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                window.Close();
            }
        }
    }
}
