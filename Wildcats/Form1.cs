using System.Windows;
using System.Windows.Forms;
using ISS_Wildcats.Backend.Controllers;
using ISS_Wildcats.Backend.Models;
using ISS_Wildcats.Backend.Repos;
using ISS_Wildcats.Backend.Service;

namespace ISS_Wildcats
{
	public partial class Form1 : Form
	{
		private bool playing = false;
		private ISongRepo songRepo;
		private ISongService songService;
		private ISongController songController; // main component that is used
		public Form1()
		{
			InitializeComponent();
            songRepo = new SongRepo();
            songService = new SongService(songRepo, 1);
            songController = new SongController(songService);
        }

		private void LabelAccount_Click(object sender, EventArgs e)
		{
		}

		private void GroupBox1_Enter(object sender, EventArgs e)
		{
		}

		private void Button1_Click(object sender, EventArgs e)
		{
		}

		private void TextBox1_TextChanged(object sender, EventArgs e)
		{
		}

		private void Button3_Click(object sender, EventArgs e)
		{
		}

		private void Button4_Click(object sender, EventArgs e)
		{
		}

		private void Button6_Click(object sender, EventArgs e)
		{
		}

		private void Label1_Click(object sender, EventArgs e)
		{
		}

		private void SplitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void Button7_Click(object sender, EventArgs e)
		{
			this.userControl11.Visible = true;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
		}

		private void PictureBox9_Click(object sender, EventArgs e)
		{
			PlayPause();
		}

		private void Button5_Click(object sender, EventArgs e)
		{
		}

		private void Panel12_Paint(object sender, PaintEventArgs e)
		{
		}

		private void Panel10_Paint(object sender, PaintEventArgs e)
		{
		}

		private void Panel2_Paint(object sender, PaintEventArgs e)
		{
		}

		private void Panel3_Paint(object sender, PaintEventArgs e)
		{
		}

		private void PictureBox1_Click(object sender, EventArgs e)
		{
			PlayChange();
		}

		private void PictureBox2_Click(object sender, EventArgs e)
		{
			ChangeSongId(2);
		}

		private void PictureBox3_Click(object sender, EventArgs e)
		{
			ChangeSongId(3);
		}

		private void PictureBox4_Click(object sender, EventArgs e)
		{
			ChangeSongId(4);
		}

		private void Label2_Click(object sender, EventArgs e)
		{
		}

		private void ChangeSongId(int songId)
		{
			if (!playing)
			{
				songController.ChangeSongId(songId);
				playing = true;
			}
			else
			{
				songController.ChangeSongId(songId);
				playing = true;
			}
		}

		private void PlayPause()
        {
			if (!playing)
			{
				songController.Play();
				playing = true;
			}
			else
			{
				songController.Pause();
				playing = false;
			}
		}

		private void PlayChange()
		{
			if (!playing)
			{
				songController.Play();
				playing = true;
			}
			else
			{
				songController.ChangeSongId(1);
				playing = true;
			}
		}
	}
}
