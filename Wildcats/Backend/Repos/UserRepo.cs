using System;
using ISS_Wildcats.Backend.Models;
using Microsoft.Data.SqlClient;

namespace ISS_Wildcats.Backend.Repos
{
    public class UserRepo
    {
        private SqlConnection connection;

        public UserRepo()
        {
            string connectionString = "Data Source=DESKTOP-LDJ0KI4\\SQLEXPRESS;Initial Catalog=se_2024;Integrated Security=True;Encrypt=False;";
            connection = new SqlConnection(connectionString);
        }

        public User GetUserById(int userId)
        {
            User user = null;
            string query = "SELECT id, fullname, username, email, birthdate, password FROM NormalUser WHERE id = @UserId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserId", userId);

            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User()
                        {
                            UserID = (int)reader["id"],
                            Name = (string)reader["fullname"],
                            Username = (string)reader["username"],
                            Email = (string)reader["email"],
                            BirthDate = Convert.ToDateTime(reader["birthdate"]),
                            Password = (string)reader["password"]
                        };
                    }
                }
            }
            finally
            {
                connection.Close();
            }
            return user;
        }

        public void AddUser(User user)
        {
            string query = "INSERT INTO NormalUser (fullname, username, email, birthdate, password) VALUES (@FullName, @Username, @Email, @Birthdate, @Password)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FullName", user.Name);
            command.Parameters.AddWithValue("@Username", user.Username);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Birthdate", user.BirthDate.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@Password", user.Password);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateUser(User user)
        {
            string query = "UPDATE NormalUser SET fullname = @FullName, username = @Username, email = @Email, birthdate = @Birthdate, password = @Password WHERE id = @UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FullName", user.Name);
            command.Parameters.AddWithValue("@Username", user.Username);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Birthdate", user.BirthDate.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@UserID", user.UserID);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteUser(int userId)
        {
            string query = "DELETE FROM NormalUser WHERE id = @UserId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserId", userId);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
