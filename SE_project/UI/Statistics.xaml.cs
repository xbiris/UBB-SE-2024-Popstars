using SE_project.Presentation;
using SE_project.Services;
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

namespace SE_project.UI
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        private CreatorService _creatorService;

        public Statistics()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            _creatorService = new CreatorService();

            //text boxes populated at initialization 
             
            NoSaves.Text  =  _creatorService.GetNoOfSavesPerCreator(1).ToString(); //to be modified with actual id 
            NoShares.Text  = _creatorService.GetNoSharesPerCreator(1).ToString();
            NoStreams.Text  = _creatorService.GetNoStreamsPerCreator(1).ToString();
            NoPlaylists.Text = _creatorService.GetNoStreamsPerCreator(1).ToString();

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
        
        private void NoShares_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
