using MVCFinalProject.DB;
using MVCFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCFinalProject.Services
{
    public class SmartphoneService
    {
        public bool Create(Smartphone phone)
        {
            using (SqlConnection con = new SqlConnection(DBConnectionString.Get()))
            {
                string query = "INSERT INTO Smartphones(Title, Description, Price) VALUES(@Title, @Description, @Price)";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Title", phone.Title);
                cmd.Parameters.AddWithValue("@Description", phone.Description);
                cmd.Parameters.AddWithValue("@Price", phone.Price);
                con.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(DBConnectionString.Get()))
            {
                string query = "DELETE FROM Smartphones WHERE Id = @Id";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        public bool Update(Smartphone phone)
        {
            using (SqlConnection con = new SqlConnection(DBConnectionString.Get()))
            {
                string query = "UPDATE Smartphones SET Title = @Title, Description = @Description, Price = @Price WHERE Id = @Id";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Title", phone.Title);
                cmd.Parameters.AddWithValue("@Description", phone.Description);
                cmd.Parameters.AddWithValue("@Price", phone.Price);
                cmd.Parameters.AddWithValue("@Id", phone.Id);
                
                con.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        public Smartphone GetById(int id)
        {
            using (SqlConnection con = new SqlConnection(DBConnectionString.Get()))
            {
                string query = "SELECT Id, Title, Description, Price FROM Smartphones WHERE Id = @Id";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Smartphone phone = new Smartphone()
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            Price = reader.GetDecimal(3)
                        };
                        return phone;
                    }
                }
            }
            return null;
        }


        public List<Smartphone> GetSmartphones()
        {
            List<Smartphone> phones = new List<Smartphone>();
            using (SqlConnection con = new SqlConnection(DBConnectionString.Get()))
            {
                string query = "SELECT Id, Title, Description, Price FROM Smartphones";
                var cmd = new SqlCommand(query, con);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Smartphone phone = new Smartphone()
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            Price = reader.GetDecimal(3)
                           
                        };
                        phones.Add(phone);
                    }
                }
            }
            return phones;
        }
    }
}