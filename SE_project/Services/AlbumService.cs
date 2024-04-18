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

			AddSongsToDb();
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
        public List<Album> GetAlbumsByCreatorId(int creatorId)
		{
			return _albumRepo.GetAlbumsByCreatorId(creatorId);
		}


        public Album GetAlbumById(int albumId)
		{
			return _albumRepo.GetAlbumById(albumId);
		}
	}
}
