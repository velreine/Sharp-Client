using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Sharp_Client.Classes
{
    internal class DatabaseHandler
    {

        public static MySqlConnection GetMySqlConnection(string connectionString = "")
        {

            const string server = "127.0.0.1";
            const string user = "root";
            const string pass = "1oktober";
            const string database = "sharpdb";
            // server=127.0.0.1;user id=root;password=1oktober;database=sharpdb

            if (connectionString.Length > 0)
            {
                return new MySqlConnection(connectionString);
            }

            return new MySqlConnection($"server={server};user id={user};password={pass};database={database}");



        }


    }

    public class SharpDatabase
    {

        public MySqlConnection myconn;
        public Tables Tables;

        public SharpDatabase()
        {
            Initialize();
            this.Tables = new Tables(myconn);
            
        }

        private void Initialize()
        {
            myconn = DatabaseHandler.GetMySqlConnection();
            myconn.Open();

        }



    }

    public class Tables
    {
        public Tables(MySqlConnection connection)
        {
            this.User = new User(connection);
        }

        public User User;
    }


    public class User
    {
        public uint UserID;
        public string Username, Password, FirstName, LastName, Email, LastIPAddress;
        private MySqlConnection myconn;

        public User()
        {

        }

        public User(MySqlConnection connection)
        {
            myconn = connection;
        }

        public User(uint _userid, string _username, string _password, string _firstname, string _lastname, string _email, string _lastipaddress)
        {
            UserID = _userid;
            Username = _username;
            Password = _password;
            FirstName = _firstname;
            LastName = _lastname;
            Email = _email;
            LastIPAddress = _lastipaddress;
        }

        public User GetUserByID(int _UserID)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM user WHERE UserID=@id", myconn);
            cmd.Parameters.AddWithValue("@id", _UserID);
            cmd.Prepare();

            MySqlDataReader reader = cmd.ExecuteReader();
           

            User user = new User();

            if (reader.HasRows)
            {

                while(reader.Read())
                {
                    user.UserID = reader.GetUInt32("UserID");
                    user.Username = reader.GetString("Username");
                    user.Password = reader.GetString("Password");
                    user.FirstName = reader.GetString("FirstName");
                    user.LastName = reader.GetString("LastName");
                    user.Email = reader.GetString("Email");
                    user.LastIPAddress = reader.GetString("LastIPAddress");
                }


            }

            return user;

           
        }

        public User GetUserWhere(string _column, string _isEqualTo)
        {
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM user WHERE {_column}=@tag", myconn);
            cmd.Parameters.AddWithValue("@tag", _isEqualTo);
            cmd.Prepare();

            MySqlDataReader reader = cmd.ExecuteReader();


            User user = new User();

            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    user.UserID = reader.GetUInt32("UserID");
                    user.Username = reader.GetString("Username");
                    user.Password = reader.GetString("Password");
                    user.FirstName = reader.GetString("FirstName");
                    user.LastName = reader.GetString("LastName");
                    user.Email = reader.GetString("Email");
                    user.LastIPAddress = reader.GetString("LastIPAddress");
                }


            }

            return user;


        }


        public override string ToString()
        {
            return ($"{nameof(UserID)}: {UserID}," +
                $" {nameof(Username)}: {Username}," +
                $" {nameof(Password)}: {Password}," +
                $" {nameof(FirstName)}: {FirstName}," +
                $" {nameof(LastName)}: {LastName}," +
                $" {nameof(Email)}: {Email}," +
                $" {nameof(LastIPAddress)}: {LastIPAddress}");
        }


    }


}
