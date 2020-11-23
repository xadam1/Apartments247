using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class Database
    {
        // TODO connectionString musí být v app.config
        string CONNECTION_STRING = @"Data Source=DESKTOP-VH88587\SQLEXPRESS;Initial Catalog=Database;Integrated Security=True"; // ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;
        public (bool, DAL.Models.User) DALGetUserByCredentials(string name, string password)
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                SqlDataReader reader = new SqlCommand($"SELECT * FROM Users WHERE Username='{name}' and Password='{password}'", con).ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return (true, new DAL.Models.User(reader));
                }
                return (false, null);
            }
        }

        // UserFactory
        public DAL.Models.User[] DALGetAllUsers()
        {
            List<DAL.Models.User> result = new List<DAL.Models.User>();
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                SqlDataReader reader = new SqlCommand($"SELECT * from Users", con).ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new DAL.Models.User(reader));
                }
                return result.ToArray();
            }
        }

        public bool DALCreateAccount(string name, string password, string email)
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                SqlDataReader reader = new SqlCommand($"SELECT * FROM Users WHERE Username='{name}'", con).ExecuteReader();
                if (reader.HasRows)
                {
                    return false;
                }

                new SqlCommand($"INSERT INTO Users (Username, Password, Email, IsAdmin) VALUES ('{name}', '{password}', '{email}', 0)", con).ExecuteNonQuery();
            }
            return true;
        }

        public void DALChangeUser(DAL.Models.User user)
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                new SqlCommand($"UPDATE Users SET Username='{user.Username}', Password='{user.Password}', Email='{user.Email}', IsAdmin={(user.IsAdmin ? 1 : 0)} WHERE Id={user.Id}", con).ExecuteNonQuery();
            }
        }

        public string[] DALListGroups(DAL.Models.User user)
        {
            List<string> result = new List<string>();

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                SqlDataReader reader = new SqlCommand($"SELECT Name FROM Groups", con).ExecuteReader();
                while (reader.Read())
                {
                    result.Add(reader.GetString(0));
                }
            }

            return result.ToArray();
        }

        public DAL.Models.UnitGroup DALGetGroupByID(int group)
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                SqlDataReader reader = new SqlCommand($"SELECT * FROM Groups WHERE Id={group}", con).ExecuteReader();
                reader.Read();
                return new DAL.Models.UnitGroup(reader);
            }
        }

        public void DALChangeGroup(DAL.Models.UnitGroup unitGroup)
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                new SqlCommand($"UPDATE Groups SET Name={unitGroup.Name}, Color={unitGroup.Color}, Note={unitGroup.Note}, Address={unitGroup.Address} WHERE Id={unitGroup.Id}", con).ExecuteNonQuery();
            }
        }

        public DAL.Models.Unit DALGetUnitByID(int unit)
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                SqlDataReader reader = new SqlCommand($"SELECT * FROM Units Where Id={unit}", con).ExecuteReader();
                reader.Read();
                return new DAL.Models.Unit(reader);
            }
        }

        public void DALChangeUnit(DAL.Models.Unit unit)
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                new SqlCommand($"UPDATE Unit SET Name='{unit.Name}', CurrentCapacity='{unit.CurrentCapacity}', MaxCapacity='{unit.MaxCapacity}', Type='{unit.Type}' WHERE Id={unit.Id}", con).ExecuteNonQuery();
            }
        }
    }
}
