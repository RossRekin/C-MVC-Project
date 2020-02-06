using MVCFinalProject.DB;
using MVCFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCFinalProject.Services
{
    public class UserService
    {
        public User LoginAttempt(UserViewModel userVM)
        {
            User user = null;
            using (SqlConnection con = new SqlConnection(DBConnectionString.Get()))
            {
                var query = "SELECT Id,Email, Password, IsAdmin FROM Users Where Email = @Email AND Password = @Password";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", userVM.Email);
                cmd.Parameters.AddWithValue("@Password", userVM.Password);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        User userDb = new User
                        {
                            Id = reader.GetInt32(0),
                            Email = reader.GetString(1),
                            Password = reader.GetString(2),
                            IsAdmin = reader.GetInt32(3)
                        };
                        user = userDb;
                    }
                }
                return user;

            }

        }

        public bool Register(UserViewModel userVM)
        {           
            using (SqlConnection con = new SqlConnection(DBConnectionString.Get()))
            {
                var query = "SELECT Id,Email, Password, IsAdmin FROM Users Where Email = @Email AND Password = @Password";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", userVM.Email);
                cmd.Parameters.AddWithValue("@Password", userVM.Password);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return false;                       
                    }
                }
                query = "INSERT INTO Users(Email,Password) VALUES(@Email, @Password)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", userVM.Email);
                cmd.Parameters.AddWithValue("@Password", userVM.Password);
                int result = cmd.ExecuteNonQuery();
                return result == 1;

            }

        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection con = new SqlConnection(DBConnectionString.Get()))
            {
                string query = "SELECT id, Email, Password FROM Users";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string email = reader.GetString(1);
                        string password = reader.GetString(2);
                        User tmpUser = new User()
                        {
                            Id = id,
                            Email = email,
                            Password = password
                        };
                        users.Add(tmpUser);

                    }
                }

            }

            return users;
        }

    }

}