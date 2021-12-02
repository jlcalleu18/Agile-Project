﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;


namespace Agile_Project
{
    public partial class Form2 : Form
    {
        public static Form2 instance;
        public Form2()
        {
            InitializeComponent();
            instance = this;
        }
        DataTable mydt = new DataTable();
        
        SqlConnection myconn;

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            //Establish a connection with the DBMS

            myconn = new SqlConnection();
            //Jorge Calle - Connection
            myconn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jorgecalle\\source\\repos\\Agile-Project\\data\\DB-Users.mdf;Integrated Security=True";

            //Kyle Schoenhardt - Connection
            //myconn.ConnectionString = "";

            //Leslie Montan - Connection
            //myconn.ConnectionString = "";

            //Jada Alvarez - Connection
            //myconn.ConnectionString = "";

            //Shisir Humagain - Connection
            //myconn.ConnectionString = "";

            //George Vanishvili - Connection
            //myconn.ConnectionString = "";




            SqlCommand mycommand = new SqlCommand();



            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            System.Text.RegularExpressions.Regex rPassword = new System.Text.RegularExpressions.Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,8}$");
           
            
            if (txtFirstName.Text.Length > 0 && txtLastName.Text.Length > 0 && txtEmail.Text.Length > 0 && txtPassword.Text.Length > 0)
            {
                if (!rEmail.IsMatch(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("check email id");
                    txtEmail.SelectAll();
                }
                else if (!rPassword.IsMatch(txtPassword.Text.Trim()))
                {
                    MessageBox.Show("password must contain 8 characters, one uppercase, one lowercase, one number");
                }
                else
                {
                    
                    mycommand.Connection = myconn;
                    mycommand.CommandText = "INSERT INTO Users (firstName, lastName, email, password) VALUES (@firstName, @lastName, @email, @password)";
                    mycommand.Parameters.AddWithValue("@firstName", txtFirstName.Text);
                    mycommand.Parameters.AddWithValue("@lastName", txtLastName.Text);
                    mycommand.Parameters.AddWithValue("@email", txtEmail.Text);
                    mycommand.Parameters.AddWithValue("@password", txtPassword.Text);
                    myconn.Open();
                    int i = mycommand.ExecuteNonQuery();

                    myconn.Close();

                    if (i != 0)
                    {
                        MessageBox.Show(i + "Data Saved");
                    }
                }
            }
            else
            {
                MessageBox.Show("fill the blanks");
            }
       
        }
    }
}
