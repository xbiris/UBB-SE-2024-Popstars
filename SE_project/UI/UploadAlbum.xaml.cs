using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SE_project.Presentation;
using Microsoft.Win32;

namespace SE_project.UI
{
	/// <summary>
	/// Interaction logic for UploadAlbum.xaml
	/// </summary>
	public partial class UploadAlbum : Window
	{
        private string Path;
        private string CoverPath;
        private PresentationSpotify presentation;

        public UploadAlbum()
		{
			InitializeComponent();
			WindowState = WindowState.Maximized;
            presentation = new PresentationSpotify();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
			
        }

        private void AddSong_Click(object sender, RoutedEventArgs e)
        {
            presentation.AddSongToList(SongTitleTextBox.Text, Path);

			MessageBox.Show("Song chosen: " + Path);
		}

        private void ChooseSong_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                Path = filePath;
            }
        }

        private void ChooseCover_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                CoverPath = filePath;
            }
        }

        private void UploadAlbum_Click(object sender, RoutedEventArgs e)
        {
            presentation.AddAlbum(TitleTextBox.Text, ReleaseDateTextBox.Text, GenreTextBox.Text, CoverPath, 1);
			MessageBox.Show("Album Uploaded");
		}

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void SongTitleTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
