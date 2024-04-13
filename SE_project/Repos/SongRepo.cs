using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_project
{
	internal class SongRepo : Repo
	{
		// privcate db connection
		private Song song;


		public SongRepo()
		{

		}
		public void addSong(Creator creator)
		{

		}
		public void deleteSong(Creator creator)
		{

		}
		public Song getSongById(int id)
		{
			return new Song(id, "", "");
		}
		public List<Song> getSongsFromAlbum(int albumId)
		{
			return new List<Song>();
		}
		public int getNumberOfStreams(int songId)
		{
			return -1;
		}

		public int getNumberOfShares(int songId)
		{
			return -1;
		}

		public int getNumberOfPlaylists(int songId)
		{
			return -1;
		}
	}
}