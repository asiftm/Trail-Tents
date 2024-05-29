using MySqlConnector;
using System.Reflection.PortableExecutable;
using TrailTents.Database;

namespace TrailTents.Models
{
    public class User
    {
        //CREATE TABLE `trailtents`.`user` (`ID` INT NOT NULL AUTO_INCREMENT , `Firstname` VARCHAR(65) NOT NULL , `Lastname` VARCHAR(65) NOT NULL , `Date_of_Birth` DATE NOT NULL , `Email` VARCHAR(65) NOT NULL , `Address` VARCHAR(65) NOT NULL , `Contact_Number` VARCHAR(65) NOT NULL , `Password` VARCHAR(65) NOT NULL , PRIMARY KEY (`ID`)) ENGINE = InnoDB;
        
        Data data = new Data();
        public int ID { get; private set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Password { get; set; }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            string query = "Select * From `user`";
            MySqlDataReader reader = data.SelectQuery(query);
            while (reader.Read())
            {
                User user = new User();
                FillUser(reader, user);
                users.Add(user);
            }
            return users;
        }
        public User GetUserByID(int id)
        {
            User user = new User();
            string query = $"Select * From `user` Where ID = '{id}'";
            MySqlDataReader reader = data.SelectQuery(query);
            while (reader.Read())
            {
                FillUser(reader, user);
            }
            return user;
        }
        public User FillUser(MySqlDataReader reader,User user)
        {
            user.ID = reader.GetInt32(0);
            user.Firstname = reader.GetString(1);
            user.Lastname = reader.GetString(2);
            user.DateOfBirth = reader[3].ToString().Substring(0,10);
            user.Email = reader.GetString(4);
            user.Address = reader.GetString(5);
            user.ContactNumber = reader.GetString(6);
            user.Password = reader.GetString(7);
            return user;
        }
        public bool AddUser(User user)
        {
            if (!user.CheckAllFields(user)) return false;
            string query = $"INSERT INTO `user` (`ID`, `Firstname`, `Lastname`, `Date_of_Birth`, `Email`, `Address`, `Contact_Number`, `Password`) VALUES (NULL, '{user.Firstname}', '{user.Lastname}', '{user.DateOfBirth}', '{user.Email}', '{user.Address}', '{user.ContactNumber}', '{user.Password}');";
            if (data.NotSelectQuery(query) == 1)
            {
                return true;
            }
            return false;
        }
        public bool CheckAllFields(User user)
        {
            if (user.Firstname != null && user.Lastname != null && user.DateOfBirth != null && user.Email != null && user.Address != null && user.ContactNumber != null && user.Password != null) return true;
            return false;
        }
        public bool UpdateUser(User user,int id)
        {
            if (!user.CheckAllFields(user)) return false;
            string query = $"UPDATE `user` SET `Firstname` = '{user.Firstname}', `Lastname` = '{user.Lastname}', `Date_of_Birth` = '{user.DateOfBirth}', `Email` = '{user.Email}', `Address` ='{user.Address}', `Contact_Number` = '{user.ContactNumber}', `Password` = '{user.Password}' WHERE `user`.`ID` = {id};";
            if (data.NotSelectQuery(query) == 1)
            {
                return true;
            }
            return false;
        }
        public User VerifyUser(string email,string password)
        {
            User user = null;

            string query = $"SELECT * FROM `user` WHERE Email = '{email}' and Password='{password}';";
            MySqlDataReader reader = data.SelectQuery(query);
            while (reader.Read())
            {
                user = new User();
                FillUser(reader, user);
            }
            return user;
        }
        public bool UniqueEmail(string email)
        {
            string query = $"SELECT * FROM `user` WHERE Email = '{email}';";
            MySqlDataReader reader = data.SelectQuery(query);
            if (!reader.HasRows)
            {
                return true;
            }
            return false;
        }
    }
}
