﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace fitnessCenterProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static void back(Window currentWindow, Window previousWindow)
        {
            currentWindow.Close();
            previousWindow.Show();
        }
    }
 
}
