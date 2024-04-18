using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace SE_project
{
	public class AlbumRepo
	{
		private SqlConnection connection;

		public AlbumRepo()
		{ 
			string connectionString = 
				ConfigurationLoaderFactory.GetConfigurationLoader("appconfig.json").
				GetValue<string>("DatabaseConnection"); ;
			connection = new SqlConnection(connectionString);
		}

		public int AddAlbum(Album album, int creatorId)
		{
			string query = "INSERT INTO Album (title, releasedate, genre, photourl, creator_id) VALUES (@Title, @ReleaseDate, @Genre, @PhotoUrl, @CreatorId); SELECT SCOPE_IDENTITY();";
			SqlCommand command = new SqlCommand(query, connection);

			command.Parameters.AddWithValue("@Title", album.title);
			command.Parameters.AddWithValue("@ReleaseDate", album.releaseDate);
			command.Parameters.AddWithValue("@Genre", album.genre);
			command.Parameters.AddWithValue("@PhotoUrl", album.photoUrl);
			command.Parameters.AddWithValue("@CreatorId", creatorId);

			try
			{
				connection.Open();
				int newAlbumId = Convert.ToInt32(command.ExecuteScalar());
				return newAlbumId; 
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return -1;
			}
			finally
			{
				connection.Close();
			}
		}
        public List<Album> GetAlbumsByCreatorId(int creatorId)
        {
            List<Album> albums = new List<Album>();
            string query = "SELECT id, title, releasedate, genre, photourl FROM Album WHERE creator_id = @CreatorId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CreatorId", creatorId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Album album = new Album(
                        reader["title"].ToString(),
                        reader["releasedate"].ToString(),
                        reader["genre"].ToString(),
                        reader["photourl"].ToString(),
                        new List<Song>()
                    );
                    albums.Add(album);
                }
                reader.Close();
                return albums;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }


        public Album GetAlbumById(int albumId)
		{
			Album album = null;
			string query = "SELECT id, title, releasedate, genre, photourl FROM Album WHERE id = @Id";
			SqlCommand command = new SqlCommand(query, connection);
			command.Parameters.AddWithValue("@Id", albumId);

			try
			{
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				if (reader.Read())
				{
					album = new Album(
						reader["title"].ToString(),
						reader["releasedate"].ToString(),
						reader["genre"].ToString(),
						reader["photourl"].ToString(),
						new List<Song>()
					);
				}
				reader.Close();
				return album;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return null;
			}
			finally
			{
				connection.Close();
			}
		}
	}
}
