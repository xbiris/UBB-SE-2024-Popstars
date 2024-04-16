using System.IO;
using System.Windows;

namespace SE_project.Services
{
	public class SongService : IService
	{
		private SongRepo _songRepo;

		public SongService()
		{
			_songRepo = new SongRepo();
		}

		public void AddSong(string title, string filePath)
		{
			if (!IsValidAudioFile(filePath))
			{
				throw new ArgumentException("Invalid audio file format");
			}

			if (filePath.Length == 0)
            {
				throw new ArgumentException("Please upload a file");
			}

			if (title.Length == 0)
            {
				throw new ArgumentException("Please enter a title");
			}
			var song = new Song(title, filePath);
			_songRepo.AddSong(song);
		}

		private bool IsValidAudioFile(string filePath)
		{
			string extension = Path.GetExtension(filePath).ToLower();
			return extension == ".mp3" || extension == ".wav" || extension == ".ogg";
		}

		public void DeleteSong(int songId)
		{
			Song song = _songRepo.GetSongById(songId);
			if (song != null)
			{
				_songRepo.DeleteSong(song);
			}
		}

		public Song GetSongById(int songId)
		{
			return _songRepo.GetSongById(songId);
		}

		public List<Song> GetSongsFromAlbum(int albumId)
		{
			return _songRepo.GetSongsFromAlbum(albumId);
		}
	}
}
