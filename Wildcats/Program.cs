using ISS_Wildcats.Backend.Models;

namespace ISS_Wildcats
{
    internal static class Program
    {
        public static void Main()
        {
            ApplicationConfiguration.Initialize();
            Form1 formInitial = new Form1();
            Application.Run(formInitial);
        }
    }
}
