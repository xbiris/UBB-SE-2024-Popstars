using System.Diagnostics;

namespace merged
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string secondAppPath = @"C:\Users\denis\source\repos\UBB-SE-2024-Popstars\Wildcats\bin\Release\net8.0-windows\Wildcats.exe";

            try
            {
                Process.Start(secondAppPath);

                // Close the current form (Form1)
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error launching the application: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TODO: make this work 
            string thirdAppPath = @"c:\users\denis\source\repos\ubb-se-2024-popstars\se_project\bin\release\net8.0-windows\publish\win-x64\SE_project.exe";
            string workingDirectory = Path.GetDirectoryName(thirdAppPath);

            ProcessStartInfo startInfo = new ProcessStartInfo(thirdAppPath);
            startInfo.WorkingDirectory = workingDirectory;
            try
            {
                Process.Start(thirdAppPath);

                // Close the current form (Form1)
                //this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error launching the application: {ex.Message}");
            }
        }
    }
}
