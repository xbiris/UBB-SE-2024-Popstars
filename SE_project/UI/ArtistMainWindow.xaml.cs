using SE_project;
using SE_project.Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SE_project.UI;
using SE_project.Presentation;

namespace wpfui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AlbumService _albumService;
        private SongService _songService;
        private List<Song> songList;
        private List<Album> albumList;

        private PresentationSpotify presentation;
        public MainWindow()
        {
            InitializeComponent();
            //MainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            WindowState = WindowState.Minimized;
            _albumService = new AlbumService();
            _songService = new SongService();

            presentation = new PresentationSpotify();

            List<Song> songList = PopulateListOfSongs();
            albumList = PopulateListOfAlbums();

            foreach(Song song in songList)
            {
				SongsListBox.Items.Add($"Title: {song.title}, length: {song.length}");
			}

			foreach(Album album in albumList)
            {
                AlbumListBox.Items.Add($"Title: {album.title}, genre: {album.genre}");
            }

            UpdateArtistInfo(this, EventArgs.Empty);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_Statistics(object sender, RoutedEventArgs e)
        {
            SE_project.UI.Statistics statisticsWindow = new SE_project.UI.Statistics();
            
            statisticsWindow.Show();    
        }

        private void Button_Click_PFP(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_NewAlbum(object sender, RoutedEventArgs e)
        {
            SE_project.UI.UploadAlbum uploadAlbumWindow = new SE_project.UI.UploadAlbum();

            uploadAlbumWindow.Show();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
        private List<Song> PopulateListOfSongs()
        {
            return _songService.GetSongsByCreator(1); //to be changed with id from the login page 
        }
        private List<Album> PopulateListOfAlbums()
        {
            return _albumService.GetAlbumsByCreatorId(1); //same here 
        }
        
        private void PopulateListOfAlbums(object sender, RoutedEventArgs e)
        {

        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateProfileInfoButton_Click(object sender, RoutedEventArgs e)
        {
            // called in order to send further the modified fields(artist name & artist bio) in order to update that data for that artist.

           
        }

		private void PFPButton_Click(object sender, RoutedEventArgs e)
		{
			var secondWindow = new UpdateCreatorInfoWindow();

            // subscribe to event
            secondWindow.UpdateClicked += UpdateArtistInfo;

            secondWindow.Show();
		}

        private void UpdateArtistInfo(object sender, EventArgs e)
        {
            int creatorId = 1;
            var (artistName, description, imagePath) = presentation.GetCreatorInfoById(creatorId);

            ArtistNameTextField.Content = artistName;
            BioTextField.Text = description;
            ProfilePic.Source = new BitmapImage(new Uri(imagePath));
        }

    }
}