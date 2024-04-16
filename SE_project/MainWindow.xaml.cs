using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Data.SqlClient;
using SE_project.Presentation;
using SE_project.Services;
using wpfui;

namespace SE_project
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			wpfui.MainWindow mainWindow = new wpfui.MainWindow();

			mainWindow.Show();

			PresentationSpotify presentation = new PresentationSpotify();

			string profilePictureUri = "photo123.jpg";
			Uri imageUri = new Uri(profilePictureUri, UriKind.Relative);
			BitmapImage imageBitmap = new BitmapImage(imageUri);

			presentation.AddCreator("123", "123", "123@example.com", "USA", "1980-05-15", "http://twitter.com/johndoe", "An enthusiastic music producer", profilePictureUri, "pass");

			presentation.AddAlbum("Summer Vibes", "2023-07-01", "Pop", "http://example.com/photo.jpg", 1); 

			presentation.AddSong("Beach Party", "http://example.com/song.mp3", 1);

			this.Hide();

		}
	}
}
