using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Data.SqlClient;

namespace ISS_Wildcats.Backend.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }

        public string? Username { get; internal set; }
        private readonly string connectionString;
        public User()
        {
        }

        public User(string connectionString, int userID)
        {
            this.connectionString = connectionString;
            LoadUserFromDatabase(userID);
        }

        public void LoadUserFromDatabase(int userId)
        {
            SqlConnection connection = new SqlConnection(this.connectionString);
            string query = "SELECT id, fullname, email, birthdate, password FROM Creator WHERE id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", userId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    // assign proper values from db
                    this.UserID = (int)reader["id"];
                    this.Name = reader["fullname"].ToString();
                    this.Email = reader["email"].ToString();
                    object birthdateObject = reader["birthdate"];
                    if (birthdateObject != DBNull.Value && DateTime.TryParse(birthdateObject.ToString(), out DateTime birthdate))
                    {
                        // converted object to DateTime
                        this.BirthDate = birthdate;
                    }
                    else
                    {
                        this.BirthDate = DateTime.MinValue;
                    }
                    this.Password = reader["password"].ToString();
                }
                else
                {
                    // defaul values
                    this.UserID = 1;
                    this.Name = "name";
                    this.Email = "mail";
                    this.BirthDate = DateTime.MinValue;
                    this.Password = "password";
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public void Add()
        {
        }

        public static User Get(int userID, string connectionString)
        {
            return new User(connectionString, userID);
        }

        public void Update()
        {
        }

        public void Delete()
        {
        }
    }
}
