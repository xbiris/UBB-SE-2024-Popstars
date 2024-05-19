using ISS_Wildcats.Backend.Models;

namespace ISS_Wildcats.Backend.Service
{
    public interface IPlaylistService
    {
        Playlist GetPlaylist(int playlistId);
        void AddSong(int playlistId, int songId);
        void RemoveSong(int playlistId, int songId);
        void UpdatePlaylistName(int playlistId, string newName);
        void DeletePlaylist(int playlistId);
    }
}
