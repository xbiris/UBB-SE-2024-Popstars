using System.Windows;

namespace SE_project
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			AlbumRepo albumRepo = new AlbumRepo();
			List<Song> songs = new List<Song>();
			songs.Add(new Song("piesa", "url"));
			songs.Add(new Song("piesa1", "url"));
			Album album = new Album("test", "release", "pop", "url", songs);

			albumRepo.AddAlbum(album, 1);

			outputTextBlock.Text = "Album added successfully!";

			Album album1 = albumRepo.GetAlbumById(1);
			outputTextBlock.Text = album1.title;
		}
	}
}
