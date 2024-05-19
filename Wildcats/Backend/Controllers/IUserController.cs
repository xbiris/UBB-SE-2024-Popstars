using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISS_Wildcats.Backend.Controllers
{
    public interface IUserController
    {
        void ChangeName(int userId, string newName);
        void ChangeEmail(int userId, string newEmail);
        void ChangePassword(int userId, string newPassword);
        void ChangeBirthDate(int userId, DateTime newBirthDate);
        void DeleteUser(int userId);
        void PlaySong(int songId);
        void PauseSong();
        void SeekSong(int seconds);
    }
}
