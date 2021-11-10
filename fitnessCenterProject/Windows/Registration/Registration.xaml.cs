﻿using fitnessCenterProject.Enums;
using fitnessCenterProject.Essentials;
using fitnessCenterProject.Essentials.FillComboBox;
using fitnessCenterProject.Models;
using fitnessCenterProject.Validation;
using fitnessCenterProject.Windows.SearchBY;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace fitnessCenterProject.Windows
{
    public partial class Registration : Window
    {
        private int id, addressID;
        private string firstName, lastName, gender, email, password;
        private long jmbgString;

        public Registration()
        {
            InitializeComponent();
            FillComboBox.fillComboBoxAddress(comboBoxAddresses);
            FillComboBox.fillComboBoxGender(comboBoxEnum);
        }
        private void getDataFromInputs()
        {
            firstName = textBoxName.Text;
            lastName = textBoxLastName.Text;
            jmbgString = long.Parse(textBoxJMBG.Text.ToString());
            gender = comboBoxEnum.SelectedItem.ToString();
            addressID = SearchAddressBY.searchAddressBYstreet(comboBoxAddresses.SelectedItem.ToString());
            email = textBoxEmail.Text;
            password = textBoxPassword.Text;
        }
        private void registerButton(object sender, RoutedEventArgs e)
        {
            if(UserValidation.createUserValidation(textBoxName, textBoxLastName, textBoxJMBG, comboBoxEnum, textBoxPassword, comboBoxAddresses, textBoxEmail))
            {
                id = GenerateNewID.generateNewIDForBeginner();
                getDataFromInputs();
                AllData.Instance.createBeginner(id, firstName, lastName, jmbgString, gender, addressID, email, password);
                MessageBox.Show("You have complete registration. Please login. Thank you!");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void exitTheApp(object sender, RoutedEventArgs e)
        {
            ExitTheApp.exitTheApp(this);
        }

        private void backToLogInWindow(object sender, RoutedEventArgs e)
        {
            BackToLogIn.backToLogInWindow(this);
        }
    }
}
