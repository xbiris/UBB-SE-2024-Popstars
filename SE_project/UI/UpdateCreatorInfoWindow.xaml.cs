using SE_project.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Security;
using Microsoft.Win32;

namespace SE_project.UI
{
    /// <summary>
    /// Interaction logic for UpdateCreatorInfoWindow.xaml
    /// </summary>
    public partial class UpdateCreatorInfoWindow : Window
    {
        private string PhotoPath;

        private PresentationSpotify presentation;

        public UpdateCreatorInfoWindow()
        {
            InitializeComponent();
            presentation = new PresentationSpotify();
            PhotoPath = "";
        }

        private void ChoosePhotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                PhotoPath = filePath;
            }
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SubmitUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string socialMediaLink = SocialMediaLinkTextBox.Text;
                string description = DescriptionTextField.Text;

                presentation.UpdateCreatorInfo(1, socialMediaLink, PhotoPath, description);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.Close();
            }
        }
    }

}