using SE_project.Services; // Import your SongService
using Microsoft.Win32; // Import OpenFileDialog if not already imported
using System;
using System.IO;
using System.Windows;
using SE_project.Presentation;
using SE_project.Services;
using wpfui;

namespace YourNamespace
{

	public partial class MainWindow : Window
	{
        PresentationSpotify presentation;
		public MainWindow()
        {
            InitializeComponent();

            wpfui.MainWindow mainWindow = new wpfui.MainWindow();

            mainWindow.Show();

            PresentationSpotify presentation = new PresentationSpotify();

			this.Hide();
		}

        private void SelectFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                FilePathTextBox.Text = filePath;
            }
        }

        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            string songName = SongNameTextBox.Text; 
            string filePath = FilePathTextBox.Text;

            if (filePath.Length > 0)
            {
                try
                {
                    presentation.AddSong(songName, filePath); // Assuming AddSong method only requires song name and file path
                    MessageBox.Show("Song uploaded successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show($"Error uploading song: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else
            {
                MessageBox.Show("Please upload a file");
            }
        }

            
    }


}
