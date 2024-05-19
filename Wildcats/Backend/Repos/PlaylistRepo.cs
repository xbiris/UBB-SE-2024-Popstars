using System;
using System.Collections.Generic;
using ISS_Wildcats.Backend.Models;
using Microsoft.Data.SqlClient;

namespace ISS_Wildcats.Backend.Repos
{
    public class PlaylistRepo : IPlaylistRepo
    {
        private readonly string connectionString;

        public PlaylistRepo(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Playlist GetPlaylist(int playlistId)
        {
            Playlist playlist = null;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT Playlist.id, Playlist.playlist_name, Playlist.creator_id, PlaylistSong.song_id " +
                            "FROM Playlist " +
                            "LEFT JOIN PlaylistSong ON Playlist.id = PlaylistSong.playlist_id " +
                            "WHERE Playlist.id = @PlaylistID";
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PlaylistID", playlistId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        bool isFirstRow = true;
                        while (reader.Read())
                        {
                            if (isFirstRow)
                            {
                                playlist = new Playlist()
                                {
                                    PlaylistID = reader.GetInt32(reader.GetOrdinal("id")),
                                    Name = reader.GetString(reader.GetOrdinal("playlist_name")),
                                    CreatorID = reader.GetInt32(reader.GetOrdinal("creator_id")),
                                    SongIDs = new List<int>()
                                };
                                isFirstRow = false;
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("song_id")))
                            {
                                playlist.SongIDs.Add(reader.GetInt32(reader.GetOrdinal("song_id")));
                            }
                        }
                    }
                }
            }
            return playlist ?? throw new ArgumentException("Playlist not found in the database.");
        }

        public void AddSong(int playlistId, int songId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "INSERT INTO PlaylistSong (playlist_id, song_id) VALUES (@PlaylistID, @SongID)";
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PlaylistID", playlistId);
                    cmd.Parameters.AddWithValue("@SongID", songId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void RemoveSong(int playlistId, int songId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "DELETE FROM PlaylistSong WHERE playlist_id = @PlaylistID AND song_id = @SongID";
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PlaylistID", playlistId);
                    cmd.Parameters.AddWithValue("@SongID", songId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePlaylist(Playlist playlist)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "UPDATE Playlist SET playlist_name = @Name WHERE id = @PlaylistID";
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", playlist.Name);
                    cmd.Parameters.AddWithValue("@PlaylistID", playlist.PlaylistID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeletePlaylist(int playlistId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "DELETE FROM PlaylistSong WHERE playlist_id = @PlaylistID; " +
                            "DELETE FROM Playlist WHERE id = @PlaylistID";
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PlaylistID", playlistId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
