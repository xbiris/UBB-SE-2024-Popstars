using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace SE_project
{
	public class SongRepo
	{
		private SqlConnection connection;

		public SongRepo()
		{
			string connectionString =
				ConfigurationLoaderFactory.GetConfigurationLoader("appconfig.json").
				GetValue<string>("DatabaseConnection"); ;
			connection = new SqlConnection(connectionString);
		}

		public void AddSong(Song song, int albumId)
		{
			string query = "INSERT INTO Song (title, song_length, songUrl, album_id) VALUES (@Title, @Length, @SongUrl, @AlbumId)";
			SqlCommand command = new SqlCommand(query, connection);

			command.Parameters.AddWithValue("@Title", song.title);
			command.Parameters.AddWithValue("@Length", song.length);
			command.Parameters.AddWithValue("@SongUrl", song.songUrl);
			command.Parameters.AddWithValue("@AlbumId", albumId);

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

		public void DeleteSong(Song song)
		{
			string query = "DELETE FROM Song WHERE id = @Id";
			SqlCommand command = new SqlCommand(query, connection);

			command.Parameters.AddWithValue("@Id", song.id);

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

		public Song GetSongById(int songId)
		{
			string query = "SELECT id, title, length, songUrl FROM Song WHERE id = @Id";
			SqlCommand command = new SqlCommand(query, connection);
			command.Parameters.AddWithValue("@Id", songId);

			try
			{
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				if (reader.Read())
				{
					return new Song(
						reader["title"].ToString(),
						reader["songUrl"].ToString()
					);
				}
				return null;
			}
			finally
			{
				connection.Close();
			}
		}
		

		public List<Song> GetSongsFromAlbum(int albumId)
		{
			List<Song> songs = new List<Song>();
			string query = "SELECT id, title, length, songUrl FROM Song WHERE album_id = @AlbumId";
			SqlCommand command = new SqlCommand(query, connection);
			command.Parameters.AddWithValue("@AlbumId", albumId);

			try
			{
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					songs.Add(new Song(
						reader["title"].ToString(),
						reader["songUrl"].ToString()
					));
				}
				return songs;
			}
			finally
			{
				connection.Close();
			}

		}
	}
}
