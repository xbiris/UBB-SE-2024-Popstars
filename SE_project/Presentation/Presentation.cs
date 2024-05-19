using System;
using System.Windows;
using System.Windows.Forms;
using SE_project;
using SE_project.Services;

namespace SE_project.Presentation
{
	public class PresentationSpotify
	{
		private CreatorService creatorService;
		private SongService songService;
		private AlbumService albumService;

		public PresentationSpotify()
		{
			creatorService = new CreatorService();
			songService = new SongService();
			albumService = new AlbumService();
		}

        public void AddCreator(string fullname, string username, string email, string country, string birthday, string socialMediaLink, string description, string profilePicPath, string hashedPass)
		{
			try
			{
				creatorService.AddCreator(fullname, username, email, country, birthday, socialMediaLink, description, profilePicPath, hashedPass);
				Console.WriteLine("Creator added successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding creator: {ex.Message}");
			}
		}

		public void AddSongToList(string title, string songUrl)
		{
			try
			{
				albumService.AddSongToList(title, songUrl);
				Console.WriteLine("Song added successfully.");
			}
			catch (Exception ex)
			{
                // Console.WriteLine($"Error adding song: {ex.Message}");
                throw ex;
			}
		}

		public void AddSong(string title, string songUrl)
		{
			try
			{
				songService.AddSong(title, songUrl);
				Console.WriteLine("Song added successfully.");
			}
			catch (Exception ex)
			{
				// Console.WriteLine($"Error adding song: {ex.Message}");
				throw ex;
			}
		}

		public void AddAlbum(string title, string releaseDate, string genre, string photoUrl, int creatorId)
		{
			try
			{
				albumService.AddAlbum(title, releaseDate, genre, photoUrl, creatorId);
				Console.WriteLine("Album added successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding album: {ex.Message}");
			}
		}

        public void UpdateCreatorInfo(int creatorId, string socialMediaLink, string profilePicPath, string description)
        {
            try
            {
                Creator creator = creatorService.GetCreatorById(creatorId);
                if (creator != null)
                {
                    string fullname = creator.Fullname;
                    string username = creator.Username;
                    string email = creator.Email;
                    string country = creator.Country;
                    string birthday = creator.Birthday;
                    // Call the service to update the Creator
                    creatorService.UpdateCreator(creatorId, fullname, username, email, country, birthday, socialMediaLink, description, profilePicPath);
                    Console.WriteLine("Creator updated successfully.");
                }
                else
                {
                    Console.WriteLine("Creator not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating creator: {ex.Message}");
            }
        }
        public (string, string, string) GetCreatorInfoById(int creatorId)
        {
            return creatorService.GetCreatorInfoById(creatorId);
        }
    }
}
