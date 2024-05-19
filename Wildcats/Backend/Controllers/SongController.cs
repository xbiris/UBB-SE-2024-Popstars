using ISS_Wildcats.Backend.Service;

namespace ISS_Wildcats.Backend.Controllers
{
    public class SongController : ISongController
    {
        private ISongService songService;

        public SongController(ISongService songService)
        {
            this.songService = songService;
        }

        public void ChangeSongId(int newSongId)
        {
            songService.ChangeSongId(newSongId);
        }

        public void Play()
        {
            songService.Play();
        }

        public void Pause()
        {
            songService.Pause();
        }

        public void Seek(int seconds)
        {
            songService.Seek(seconds);
        }
    }
}
