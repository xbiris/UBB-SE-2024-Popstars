using System.Windows;
using Microsoft.Data.SqlClient;
using SE_project.Presentation;
using SE_project.Services;

namespace SE_project
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			PresentationSpotify presentation = new PresentationSpotify();
			presentation.AddCreator("123", "123", "123@example.com", "USA", "1980-05-15", "http://twitter.com/johndoe", "An enthusiastic music producer", "pass");

			presentation.AddAlbum("Summer Vibes", "2023-07-01", "Pop", "http://example.com/photo.jpg", 1); 

			presentation.AddSong("Beach Party", "http://example.com/song.mp3", 1);

		}
	}
}
