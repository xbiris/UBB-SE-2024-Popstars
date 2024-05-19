using ISS_Wildcats.Backend.Models;
using Microsoft.Data.SqlClient;

namespace ISS_Wildcats.Backend.Repos
{
	public class SongRepo : ISongRepo
	{
		private SqlConnection connection;

		public SongRepo()
		{
			string connectionString = "Data Source=DESKTOP-LDJ0KI4\\SQLEXPRESS;Initial Catalog=se_2024;Integrated Security=True;Encrypt=False;";
			connection = new SqlConnection(connectionString);
		}

		public void AddSong(Song song)
		{
			string query = "INSERT INTO Song (title, song_length, songUrl, album_id) VALUES (@Title, @Length, @SongUrl, @AlbumId)";
			SqlCommand command = new SqlCommand(query, connection);

			command.Parameters.AddWithValue("@Title", song.Title);
			command.Parameters.AddWithValue("@Length", song.Length);
			command.Parameters.AddWithValue("@SongUrl", song.SongUrl);
			command.Parameters.AddWithValue("@AlbumId", song.AlbumId);

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

			command.Parameters.AddWithValue("@Id", song.Id);

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

		public List<Song> GetSongsByCreator(int creatorId)
		{
			List<Song> songs = new List<Song>();
			string query = "SELECT * FROM Song WHERE album_id IN " +
						   "(SELECT id FROM Album WHERE creator_id = @CreatorId)";

			SqlCommand command = new SqlCommand(query, connection);
			command.Parameters.AddWithValue("@CreatorId", creatorId);

			try
			{
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					Song song = new Song(
						reader["title"].ToString(),
						reader["songUrl"].ToString(),
						(int)reader["length"],
						(int)reader["albumId"]);
					songs.Add(song);
				}
				reader.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				connection.Close();
			}

			return songs;
		}

		public Song GetSongById(int songId)
		{
			string query = "SELECT id, title, song_length as length, songUrl, album_id as albumId FROM Song WHERE id = @Id";
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
						reader["songUrl"].ToString(),
						(int)reader["length"],
						(int)reader["albumId"]);
				}
				return null;
			}
			finally
			{
				connection.Close();
			}
		}

		public Song GetSongByTitle(string title)
		{
			string query = "SELECT id, title, song_length as length, songUrl, album_id as albumId FROM Song WHERE title = @Title";
			SqlCommand command = new SqlCommand(query, connection);
			command.Parameters.AddWithValue("@Title", title);

			try
			{
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				if (reader.Read())
				{
					return new Song(
						reader["title"].ToString(),
						reader["songUrl"].ToString(),
						(int)reader["length"],
						(int)reader["albumId"]);
				}
				return null;
			}
			finally
			{
				connection.Close();
			}
		}

		public Song GetSongByUrl(string songPath)
		{
			string query = "SELECT id, title, song_length as length, songUrl, album_id as albumId FROM Song WHERE songUrl = @songUrl";
			SqlCommand command = new SqlCommand(query, connection);
			command.Parameters.AddWithValue("@songUrl", songPath);

			try
			{
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				if (reader.Read())
				{
					return new Song(
						reader["title"].ToString(),
						reader["songUrl"].ToString(),
						(int)reader["length"],
						(int)reader["albumId"]);
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
			string query = "SELECT id, title, song_length as length, songUrl, album_id as albumId FROM Song WHERE album_id = @AlbumId";
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
						reader["songUrl"].ToString(),
						(int)reader["length"],
						(int)reader["albumId"]));
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