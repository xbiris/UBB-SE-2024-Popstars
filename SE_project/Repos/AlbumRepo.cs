using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_project
{
	internal class AlbumRepo : Repo
	{
		// private db connection
		private Album album;


		public AlbumRepo()
		{

		}
		public void addAlbum(Album album)
		{

		}
		public void deleteAlbum(Album album)
		{

		}
		public Album getAlbumById(int albumId)
		{
			return new Album(albumId, "", "", "", "", new List<Song>());
		}
		public List<Album> getAlbumByCreator(int creatorId)
		{
			return new List<Album>();
		}
	}
}