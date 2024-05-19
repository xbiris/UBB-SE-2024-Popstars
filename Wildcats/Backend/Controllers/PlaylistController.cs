using ISS_Wildcats.Backend.Models;
using ISS_Wildcats.Backend.Service;

namespace ISS_Wildcats.Backend.Controllers
{
    public class PlaylistController : IPlaylistController
    {
        private readonly IPlaylistService playlistService;

        public PlaylistController(IPlaylistService playlistService)
        {
            this.playlistService = playlistService;
        }

        public Playlist GetPlaylist(int playlistId)
        {
            return playlistService.GetPlaylist(playlistId);
        }

        public void AddSong(int playlistId, int songId)
        {
            playlistService.AddSong(playlistId, songId);
        }

        public void RemoveSong(int playlistId, int songId)
        {
            playlistService.RemoveSong(playlistId, songId);
        }

        public void UpdatePlaylistName(int playlistId, string newName)
        {
            playlistService.UpdatePlaylistName(playlistId, newName);
        }

        public void DeletePlaylist(int playlistId)
        {
            playlistService.DeletePlaylist(playlistId);
        }
    }
}
