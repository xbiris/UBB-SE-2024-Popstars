using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

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
			string query = "INSERT INTO Creator(fullname, username, email, country, birthdate, socialmedialink, description, profilePicPath, password)  VALUES (@FullName, @Username, @Email, @Country, @Birthdate, @SocialMediaLink, @Description, @ProfilePicPath, @Password)";
			SqlCommand command = new SqlCommand(query, connection);
			command.Parameters.AddWithValue("@FullName", creator.fullname);
			command.Parameters.AddWithValue("@Username", creator.username);
			command.Parameters.AddWithValue("@Email", creator.email);
			command.Parameters.AddWithValue("@Country", creator.country);
			command.Parameters.AddWithValue("@Birthdate", creator.birthday);
			command.Parameters.AddWithValue("@SocialMediaLink", creator.socialmedialink);
			command.Parameters.AddWithValue("@Description", creator.description);
			command.Parameters.AddWithValue("@ProfilePicPath", creator.profilePicPath);
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

		public int GetNoOfSavesPerCreator(int creatorId)
		{

			int totalSaves = 0;

			string query = "SELECT SUM(Song.no_saves) AS total_saves " +
						   "FROM Album " +
						   "INNER JOIN Song ON Album.id = Song.album_id " +
						   "WHERE Album.creator_id = @CreatorId";

			SqlCommand command = new SqlCommand(query, connection);
			{
				command.Parameters.AddWithValue("@CreatorId", creatorId);

				try
				{
					connection.Open();
					object result = command.ExecuteScalar();

					if (result != DBNull.Value)
					{
						totalSaves = Convert.ToInt32(result);
					}
				}
				finally
				{
					connection.Close();
				}
			}

			return totalSaves;
		}

        public int GetNoOfSharesPerCreator(int creatorId)
        {

            int totalShares = 0;

            string query = "SELECT SUM(Song.no_shares) AS total_shares " +
                           "FROM Album " +
                           "INNER JOIN Song ON Album.id = Song.album_id " +
                           "WHERE Album.creator_id = @CreatorId";

            SqlCommand command = new SqlCommand(query, connection);
            {
                command.Parameters.AddWithValue("@CreatorId", creatorId);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        totalShares = Convert.ToInt32(result);
                    }
                }
                finally
                {
                    connection.Close();
                }
            }

            return totalShares;
        }

        public int GetNoOfStreamsPerCreator(int creatorId)
        {

            int totalStreams = 0;

            string query = "SELECT SUM(Song.no_streams) AS total_streams " +
                           "FROM Album " +
                           "INNER JOIN Song ON Album.id = Song.album_id " +
                           "WHERE Album.creator_id = @CreatorId";

            SqlCommand command = new SqlCommand(query, connection);
            {
                command.Parameters.AddWithValue("@CreatorId", creatorId);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        totalStreams = Convert.ToInt32(result);
                    }
                }
                finally
                {
                    connection.Close();
                }
            }

            return totalStreams;
        }
        public int GetNoOfPlaylistsPerCreator(int creatorId)
        {

            int totalPlaylists = 0;

            string query = "SELECT SUM(Song.no_playlists) AS total_playlists " +
                           "FROM Album " +
                           "INNER JOIN Song ON Album.id = Song.album_id " +
                           "WHERE Album.creator_id = @CreatorId";

            SqlCommand command = new SqlCommand(query, connection);
            {
                command.Parameters.AddWithValue("@CreatorId", creatorId);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        totalPlaylists = Convert.ToInt32(result);
                    }
                }
                finally
                {
                    connection.Close();
                }
            }

            return totalPlaylists;
        }


        public Creator GetCreatorById(int creatorId)
		{
			string query = "SELECT id, username, fullname, email, country, birthdate, socialmedialink, description, profilePicPath FROM Creator WHERE id = @Id";
			SqlCommand command = new SqlCommand(query, connection);
			command.Parameters.AddWithValue("@Id", creatorId);

			try
			{
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				if (reader.Read())
				{
                    // this is the only way this function actually worked for me.
                    string[] stringArray = new string[10];
					stringArray[0] = reader["username"].ToString();
					stringArray[1] = reader["fullname"].ToString();
					stringArray[2] = reader["email"].ToString();
					stringArray[3] = reader["country"].ToString();
					stringArray[4] = reader["birthdate"].ToString();
					stringArray[5] = reader["socialmedialink"].ToString();
					stringArray[6] = reader["description"].ToString();
					stringArray[7] = reader["profilePicPath"].ToString();
                    return new Creator(
						stringArray[0],
						stringArray[1],
						stringArray[2],
						stringArray[3],
						stringArray[4],
						stringArray[5],
						stringArray[6],
						stringArray[7]
                    );
					
				}
				return null;
			}
			finally
			{
				connection.Close();
			}
		}

        public void UpdateCreator(int creatorId, Creator creator)
        {
            string query = "UPDATE Creator SET ";

            if (!string.IsNullOrEmpty(creator.socialmedialink))
            {
                query += "socialmedialink = @SocialMediaLink, ";
            }

            if (!string.IsNullOrEmpty(creator.description))
            {
                query += "description = @Description, ";
            }

            if (!string.IsNullOrEmpty(creator.profilePicPath))
            {
                query += "profilePicPath = @ProfilePicPath, ";
            }

            query = query.TrimEnd(',', ' ');

            query += " WHERE id = @Id";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SocialMediaLink", creator.socialmedialink);
            command.Parameters.AddWithValue("@Description", creator.description);
            if (!string.IsNullOrEmpty(creator.profilePicPath))
            {
                command.Parameters.AddWithValue("@ProfilePicPath", creator.profilePicPath);
            }
            command.Parameters.AddWithValue("@Id", creatorId);

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
