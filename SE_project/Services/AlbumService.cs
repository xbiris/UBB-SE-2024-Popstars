using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_project.Services
{
	public class AlbumService : IService
	{
		private AlbumRepo _albumRepo;

		public AlbumService()
		{
			_albumRepo = new AlbumRepo();
		}

		public void AddAlbum(string title, string releaseDate, string genre, string photoUrl, int creatorId)
		{
			var album = new Album(title, releaseDate, genre, photoUrl, new List<Song>());
			_albumRepo.AddAlbum(album, creatorId);
		}

		public Album GetAlbumById(int albumId)
		{
			return _albumRepo.GetAlbumById(albumId);
		}
	}
}
