using System.IO;
using System.Windows;

namespace SE_project.Services
{
	public class AlbumService : IService
	{
		private AlbumRepo albumRepo;
		private SongRepo songRepo1;
		private SongRepo songRepo;
		public List<Song> Songs;

		public AlbumService()
		{
			albumRepo = new AlbumRepo();
			songRepo1 = new SongRepo();
			songRepo = new SongRepo();
			Songs = new List<Song>();
		}

		public void AddAlbum(string title, string releaseDate, string genre, string photoUrl, int creatorId)
		{
			var album = new Album(title, releaseDate, genre, photoUrl, new List<Song>());
			int albumId = albumRepo.AddAlbum(album, creatorId);
			AddAlbumIdToSongs(albumId);

			AddSongsToDb();
		}

		private void AddAlbumIdToSongs(int albumId)
		{
			foreach (Song song in Songs)
			{
				song.AlbumId = albumId;
			}
		}
		private void AddSongsToDb()
		{
			foreach (Song song in Songs)
			{
				songRepo.AddSong(song);
			}
		}

		public void AddSongToList(string title, string songPath)
		{
			Song song = new Song(title, songPath);
			Songs.Add(song);
		}
        public List<Album> GetAlbumsByCreatorId(int creatorId)
		{
			return albumRepo.GetAlbumsByCreatorId(creatorId);
		}

        public Album GetAlbumById(int albumId)
		{
			return albumRepo.GetAlbumById(albumId);
		}
	}
}
