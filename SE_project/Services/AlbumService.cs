using System.IO;
using System.Windows;

namespace SE_project.Services
{
	public class AlbumService : IService
	{
		private AlbumRepo _albumRepo;
		private SongRepo _songRepo;
		private SongRepo songRepo;
		public List<Song> _songs;

		public AlbumService()
		{
			_albumRepo = new AlbumRepo();
			_songRepo = new SongRepo();
			songRepo = new SongRepo();
			_songs = new List<Song>();
		}

		public void AddAlbum(string title, string releaseDate, string genre, string photoUrl, int creatorId)
		{
			var album = new Album(title, releaseDate, genre, photoUrl, new List<Song>());
			int albumId = _albumRepo.AddAlbum(album, creatorId);
			AddAlbumIdToSongs(albumId);
			moveSongsToUploads();
			AddSongsToDb();
		}

		private void moveSongsToUploads()
        {
			foreach (Song song in _songs)
			{
				string songFinalPath = MoveFileToUploads(song.songUrl, song.albumId);
				song.songUrl = songFinalPath;
			}
		}


		private string MoveFileToUploads(string filePath, int albumId)
		{
			// Create the uploads directory if it doesn't exist
			string uploadsDirectory = Path.Combine(Environment.CurrentDirectory, "uploads");
			if (!Directory.Exists(uploadsDirectory))
			{
				Directory.CreateDirectory(uploadsDirectory);
			}

			// Get the album name based on the album ID (example logic)
			string albumName = GetAlbumById(albumId).title;

			// Create the album directory if it doesn't exist
			string albumDirectory = Path.Combine(uploadsDirectory, albumName);
			if (!Directory.Exists(albumDirectory))
			{
				Directory.CreateDirectory(albumDirectory);
			}

			// Get the file name and move it to the album directory
			string fileName = Path.GetFileName(filePath);
			string destinationFilePath = Path.Combine(albumDirectory, fileName);
			File.Move(filePath, destinationFilePath);
			return destinationFilePath;
		}

		private void AddAlbumIdToSongs(int albumId)
		{
			foreach (Song song in _songs) { 
				song.albumId = albumId; 
			}
		}
		
		private void AddSongsToDb()
		{
			foreach (Song song in _songs) {
				songRepo.AddSong(song);
			}
		}

		public void AddSongToList(string title, string songPath)
		{
			Song song = new Song(title, songPath);
			_songs.Add(song);
		}

		public Album GetAlbumById(int albumId)
		{
			return _albumRepo.GetAlbumById(albumId);
		}
	}
}
