using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Sharp_Client.Classes;

namespace Sharp_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string username = textBox1.Text;
            string password = textBox2.Text;

            // 1.1 Validate Input
            if (ValidateInput(username) && ValidateInput(password))
            { // 1.2 Input validated

                // 1.3 Check if login is correct.
                if (LoginHandler.UserLogin(username, password))
                { // 1.4 Login is correct.

                    // 1.7 Show main menu.
                    MainForm mf = new MainForm();
                    mf.Show();
                    this.Hide();
                }
              
            }



        }

        private bool ValidateInput(string input)
        {
            // TODO: Set RegEx for unallowed characthers.
            Regex reg = new Regex("([Å-Æ])");
            MatchCollection match;

            match = reg.Matches(input);

            

            if (match.Count != 0) { return false; }

            if (input.Length > 32) { return false; }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

           

            SharpDatabase database = new SharpDatabase();
            

            User usr = (database.Tables.User.GetUserByID(1));
            // Maybe add SqlConnection to SharpDatabase, 
            //so don't have to pass it to function everytime.
            MessageBox.Show(usr.ToString());

            database.myconn.Close();

        }
    }
}
