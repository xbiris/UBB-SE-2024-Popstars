using ISS_Wildcats.Backend.Models;

namespace ISS_Wildcats.Backend.Repos
{
    public interface IPlaylistRepo
    {
        Playlist GetPlaylist(int playlistId);
        void AddSong(int playlistId, int songId);
        void RemoveSong(int playlistId, int songId);
        void UpdatePlaylist(Playlist playlist);
        void DeletePlaylist(int playlistId);
    }
}
