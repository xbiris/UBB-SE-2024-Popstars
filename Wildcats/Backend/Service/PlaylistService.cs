using ISS_Wildcats.Backend.Models;
using ISS_Wildcats.Backend.Repos;

namespace ISS_Wildcats.Backend.Service
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepo playlistRepo;

        public PlaylistService(IPlaylistRepo playlistRepo)
        {
            this.playlistRepo = playlistRepo;
        }

        public Playlist GetPlaylist(int playlistId)
        {
            return playlistRepo.GetPlaylist(playlistId);
        }

        public void AddSong(int playlistId, int songId)
        {
            playlistRepo.AddSong(playlistId, songId);
        }

        public void RemoveSong(int playlistId, int songId)
        {
            playlistRepo.RemoveSong(playlistId, songId);
        }

        public void UpdatePlaylistName(int playlistId, string newName)
        {
            Playlist playlist = playlistRepo.GetPlaylist(playlistId);
            playlist.Name = newName;
            playlistRepo.UpdatePlaylist(playlist);
        }

        public void DeletePlaylist(int playlistId)
        {
            playlistRepo.DeletePlaylist(playlistId);
        }
    }
}
