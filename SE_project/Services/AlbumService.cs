using System.IO;

namespace SE_project.Services
{
	public class AlbumService : IService
	{
		private AlbumRepo _albumRepo;
		private SongRepo _songRepo;
		private SongRepo songRepo;
		private List<Song> _songs;

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
			AddSongsToDb();
		}

		private void AddAlbumIdToSongs(int albumId)
		{
			foreach(Song song in _songs) { 
				song.albumId = albumId;
			}
		}
		
		private void AddSongsToDb()
		{
			foreach (Song song in _songs) {

				if (!IsValidAudioFile(song.songUrl))
				{
					throw new ArgumentException("Invalid audio file format");
				}

				if (song.songUrl.Length == 0)
				{
					throw new ArgumentException("Please upload a file");
				}

				if (song.title.Length == 0)
				{
					throw new ArgumentException("Please enter a title");
				}

				if (_songRepo.GetSongByUrl(song.songUrl) != null || _songRepo.getSongByTitle(song.title) != null)
				{
					throw new ArgumentException("This song already exists");
				}

				songRepo.AddSong(song);
			}
		}

		private bool IsValidAudioFile(string filePath)
		{
			string extension = Path.GetExtension(filePath).ToLower();
			return extension == ".mp3" || extension == ".wav" || extension == ".ogg";
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
