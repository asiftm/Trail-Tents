using Microsoft.AspNetCore.Http.HttpResults;
using MySqlConnector;
using TrailTents.Database;

namespace TrailTents.Models
{
    public class Admin
    {
        //CREATE TABLE `trailtents`.`admin` (`ID` INT NOT NULL , `Firstname` VARCHAR(65) NOT NULL, `Lastname` VARCHAR(65) NOT NULL, `Email` VARCHAR(65) NOT NULL, `Address` VARCHAR(65) NOT NULL, `Contact_Number` VARCHAR(65) NOT NULL, `Password` VARCHAR(65) NOT NULL ) ENGINE = InnoDB;

        Data data = new Data();
        public int ID { get; private set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Password { get; set; }
        public List<Admin> GetAllAdmins()
        {
            List<Admin> admins = new List<Admin>();
            string query = "Select * From `admin`";
            MySqlDataReader reader = data.SelectQuery(query);
            while (reader.Read())
            {
                Admin admin = new Admin();
                FillUser(reader, admin);
                admins.Add(admin);
            }
            return admins;
        }
        public Admin GetAdminByID(int id)
        {
            Admin admin = new Admin();
            string query = $"Select * From `admin` Where ID = '{id}'";
            MySqlDataReader reader = data.SelectQuery(query);
            while (reader.Read())
            {
                FillUser(reader, admin);
            }
            return admin;
        }
        public Admin FillUser(MySqlDataReader reader, Admin admin)
        {
            admin.ID = reader.GetInt32(0);
            admin.Firstname = reader.GetString(1);
            admin.Lastname = reader.GetString(2);
            admin.Email = reader.GetString(3);
            admin.Address = reader.GetString(4);
            admin.ContactNumber = reader.GetString(5);
            admin.Password = reader.GetString(6);
            return admin;
        }
        public bool AddAdmin(Admin admin)
        {
            if (!admin.CheckAllFields(admin)) return false;
            string query = $"INSERT INTO `admin` (`ID`, `Firstname`, `Lastname`, `Email`, `Address`, `Contact_Number`, `Password`) VALUES (NULL, '{admin.Firstname}', '{admin.Lastname}', '{admin.Email}', '{admin.Address}', '{admin.ContactNumber}', '{admin.Password}');";
            if (data.NotSelectQuery(query) == 1)
            {
                return true;
            }
            return false;
        }

        public bool CheckAllFields(Admin admin)
        {
            if (admin.Firstname != null && admin.Lastname != null && admin.Email != null && admin.Address != null && admin.ContactNumber != null && admin.Password != null) return true;
            return false;
        }
        public bool UpdateAdmin(Admin admin,int id)
        {
            if (!admin.CheckAllFields(admin: admin)) return false;
            string query = $"UPDATE `admin` SET `Firstname` = '{admin.Firstname}', `Lastname` = '{admin.Lastname}', `Email` = '{admin.Email}', `Address` ='{admin.Address}', `Contact_Number` = '{admin.ContactNumber}', `Password` = '{admin.Password}' WHERE `admin`.`ID` = {id};";
            if (data.NotSelectQuery(query) == 1)
            {
                return true;
            }
            return false;
        }
    }
}
