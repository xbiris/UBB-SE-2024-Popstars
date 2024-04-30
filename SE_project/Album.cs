using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace SE_project
{
	public class Album
	{
		public int Id { get; set; }
		public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string PhotoUrl { get; set; }

		public List<Song> Songs { get; set; }
		public Album(string title, string releaseDate, string genre, string photoUrl, List<Song> Songs) {
			this.Title = title;
			this.ReleaseDate = releaseDate;
			this.Genre = genre;
			this.PhotoUrl = photoUrl;
			this.Songs = Songs;
		}

		public int GetNumberOfSongs()
		{
			return -1;
		}

		public int GetLength()
		{
			int length = 0;
			foreach (Song song in Songs) 
			{
				length += song.Length;
			}
			return length;
		}
	}
}
