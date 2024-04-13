using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_project.Services
{
	public class SongService : IService
	{
		private SongRepo _songRepo;

		public SongService()
		{
			_songRepo = new SongRepo();
		}

		public void AddSong(string title, string songUrl, int albumId)
		{
			var song = new Song(title, songUrl);
			_songRepo.AddSong(song, albumId);
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
