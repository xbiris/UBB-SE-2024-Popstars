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
     

        public MainWindow()
        {
            InitializeComponent();
            //MainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            WindowState = WindowState.Minimized;
            _albumService = new AlbumService();
            _songService = new SongService();

            List<Song> songList = PopulateListOfSongs();

            foreach(Song song in songList)
            {

				SongsListBox.Items.Add($"Title: {song.title}, length: {song.length}");
			}

			// DataContext = this;
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
           
            return _songService.GetSongsByCreator(1);
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

			secondWindow.Show();
		}
    }
}