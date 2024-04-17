using System;
using SE_project;
using SE_project.Services;

namespace SE_project.Presentation
{
	public class PresentationSpotify
	{
		private CreatorService _creatorService;
		private SongService _songService;
		private AlbumService _albumService;

		public PresentationSpotify()
		{
			_creatorService = new CreatorService();
			_songService = new SongService();
			_albumService = new AlbumService();
		}

		

        public void AddCreator(string fullname, string username, string email, string country, string birthday, string socialMediaLink, string description, string profilePicPath, string hashedPass)
		{
			try
			{
				_creatorService.AddCreator(fullname, username, email, country, birthday, socialMediaLink, description, profilePicPath, hashedPass);
				Console.WriteLine("Creator added successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding creator: {ex.Message}");
			}
		}

		public void AddSong(string title, string songUrl, int albumId)
		{
			try
			{
				_songService.AddSong(title, songUrl, albumId);
				Console.WriteLine("Song added successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding song: {ex.Message}");
			}
		}

		public void AddAlbum(string title, string releaseDate, string genre, string photoUrl, int creatorId)
		{
			try
			{
				_albumService.AddAlbum(title, releaseDate, genre, photoUrl, creatorId);
				Console.WriteLine("Album added successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding album: {ex.Message}");
			}
		}
	}
}
