using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace SE_project
{
	public class CreatorRepo
	{
		private SqlConnection connection;

		public CreatorRepo()
		{
			string connectionString =
				ConfigurationLoaderFactory.GetConfigurationLoader("appconfig.json").
				GetValue<string>("DatabaseConnection"); ;
			connection = new SqlConnection(connectionString);
		}

		public void AddCreator(Creator creator, string hashedPass)
		{
			string query = "INSERT INTO Creator (fullname, username, email, country, birthdate, socialmedialink, description, password) VALUES (@FullName, @Username, @Email, @Country, @Birthdate, @SocialMediaLink, @Description, @Password)";
			SqlCommand command = new SqlCommand(query, connection);

			command.Parameters.AddWithValue("@FullName", creator.fullname);
			command.Parameters.AddWithValue("@Username", creator.username);
			command.Parameters.AddWithValue("@Email", creator.email);
			command.Parameters.AddWithValue("@Country", creator.country);
			command.Parameters.AddWithValue("@Birthdate", creator.birthday);
            command.Parameters.AddWithValue("@SocialMediaLink", creator.socialmedialink);
            command.Parameters.AddWithValue("@Description", creator.description);
			command.Parameters.AddWithValue("@Password", hashedPass);
			
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

		public void DeleteCreator(Creator creator)
		{
			string query = "DELETE FROM Creator WHERE id = @Id";
			SqlCommand command = new SqlCommand(query, connection);

			command.Parameters.AddWithValue("@Id", creator.id);

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

		public Creator GetCreatorById(int creatorId)
		{
			string query = "SELECT id, username, fullname, email, country, birthdate, socialmedialink, description FROM Creator WHERE id = @Id";
			SqlCommand command = new SqlCommand(query, connection);
			command.Parameters.AddWithValue("@Id", creatorId);

			try
			{
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				if (reader.Read())
				{
					return new Creator(
						reader["username"].ToString(),
						reader["fullname"].ToString(),
						reader["email"].ToString(),
						reader["country"].ToString(),
						reader["birthdate"].ToString(),
						reader["socialemedialink"].ToString(),
						reader["description"].ToString()
                    );
				}
				return null;
			}
			finally
			{
				connection.Close();
			}
		}
	}
}
