using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_project
{
	public class Song
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int Length { get; set; }
		public string SongUrl { get; set; }
		public int AlbumId { get; set; }

		public Song(string title, string songUrl)
		{
			this.Title = title;
			this.SongUrl = songUrl;
		}
	}
}
