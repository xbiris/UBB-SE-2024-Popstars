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
		public int id { get; set; }
		public string title { get; set; }
		public string releaseDate { get; set; }
		public string genre { get; set; }
		public string photoUrl { get; set; }

		public List<Song> Songs { get; set; }
	
		public Album(string title, string releaseDate, string genre, string photoUrl, List<Song> Songs) {
			this.title = title;
			this.releaseDate = releaseDate;
			this.genre = genre;
			this.photoUrl = photoUrl;
			this.Songs = Songs;
		}

		public int getNumberOfSongs() {
			return -1;
		}

		public int getLength()
		{
			int length = 0;
			foreach (Song song in Songs) {
				length += song.Length;
			}
			return length;
		}
	}
}
