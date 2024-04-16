using System;
using SE_project;
using SE_project.Services;
using System.Windows;
using System.Windows.Forms;

namespace SE_project.Presentation
{
	public class PresentationSpotify
	{
		private CreatorService _creatorService;
		public SongService _songService;
		public AlbumService _albumService;

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

		public void AddSongToList(string title, string songUrl) {
			try
			{
				_albumService.AddSongToList(title, songUrl);
				Console.WriteLine("Song added successfully.");
			}
			catch (Exception ex)
			{
				//Console.WriteLine($"Error adding song: {ex.Message}");
				throw ex;
			}
		}

		public void AddSong(string title, string songUrl)
		{
			try
			{
				_songService.AddSong(title, songUrl);
				Console.WriteLine("Song added successfully.");
			}
			catch (Exception ex)
			{
				//Console.WriteLine($"Error adding song: {ex.Message}");
				throw ex;
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


		private void SelectFile_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				String selectedFilePath = openFileDialog.FileName;
			}
		}


	}
}
