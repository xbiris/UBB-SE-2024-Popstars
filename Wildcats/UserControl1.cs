using System;
using System.Drawing;
using System.Windows.Forms;

namespace ISS_Wildcats
{
    public partial class UserControl1 : UserControl
    {
        private PasswordForm passwordForm = new PasswordForm();
        private UserNameForm userNameForm = new UserNameForm();
        public UserControl1()
        {
            InitializeComponent();
            this.Visible = false;
            // Attach event handlers for all labels

            // Attach special hover and leave event handlers for labels 1, 7, 8, 9, 10, and 11
            label1.MouseHover += SpecialLabel_MouseHover;
            label1.MouseLeave += SpecialLabel_MouseLeave;
            label10.MouseHover += SpecialLabel_MouseHover;
            label10.MouseLeave += SpecialLabel_MouseLeave;
            label11.MouseHover += SpecialLabel_MouseHover;
            label11.MouseLeave += SpecialLabel_MouseLeave;
            this.Dock = DockStyle.Right;
            passwordForm.Visible = false;
            userNameForm.Visible = false;
        }

        private void SpecialLabel_MouseHover(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                label.Font = new Font("Odor Mean Chey", 16);
            }
        }

        private void SpecialLabel_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                label.Font = new Font("Odor Mean Chey", 14);
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void Label2_Click(object sender, EventArgs e)
        {
        }

        private void Label11_Click_1(object sender, EventArgs e)
        {
            if (passwordForm.Visible == false)
            {
                passwordForm.Visible = true;
            }
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                this.Visible = false;
            }
        }

        private void Label9_Click(object sender, EventArgs e)
        {
        }

        private void Label10_Click(object sender, EventArgs e)
        {
            if (userNameForm.Visible == false)
            {
                userNameForm.Visible = true;
            }
        }
    }
}
