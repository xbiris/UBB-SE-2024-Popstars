using System;
using System.Windows.Media;
using ISS_Wildcats.Backend.Models;
using ISS_Wildcats.Backend.Repos;

namespace ISS_Wildcats.Backend.Service
{
    public class SongService : ISongService
    {
        private MediaPlayer player;
        private readonly ISongRepo songRepo;
        private int songId;

        public SongService(ISongRepo songRepo, int songId)
        {
            this.songRepo = songRepo;
            this.songId = songId;
            player = new MediaPlayer();
        }

        public void ChangeSongId(int newSongId)
        {
            this.songId = newSongId;

            if (player.HasAudio)
            {
                player.Stop();
            }
            // Play immediately afterwards
            Play();
        }

        public void Play()
        {
            try
            {
                player.Open(new Uri(songRepo.GetSongById(songId).SongUrl));
                player.Play();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to play song: {e.Message}");
            }
        }

        public void Pause()
        {
            if (player.CanPause)
            {
                player.Pause();
            }
        }

        public void Seek(int seconds)
        {
            TimeSpan newPosition = new TimeSpan(0, 0, seconds);
            player.Position = newPosition;
        }
    }
}
