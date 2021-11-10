using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace fitnessCenterProject.Essentials
{
    class ExitTheApp
    {
        public static void exitTheApp(Window window)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Do you want to close the app?", "Decision window", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                System.Windows.Forms.MessageBox.Show("You successfully exit the Fitness Center App!");
                window.Close();
            }
        }
    }
}
