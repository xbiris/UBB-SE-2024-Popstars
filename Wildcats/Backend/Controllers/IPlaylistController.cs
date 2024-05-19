using ISS_Wildcats.Backend.Models;

namespace ISS_Wildcats.Backend.Controllers
{
    public interface IPlaylistController
    {
        Playlist GetPlaylist(int playlistId);
        void AddSong(int playlistId, int songId);
        void RemoveSong(int playlistId, int songId);
        void UpdatePlaylistName(int playlistId, string newName);
        void DeletePlaylist(int playlistId);
    }
}
