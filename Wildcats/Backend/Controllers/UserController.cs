using System;
using ISS_Wildcats.Backend.Service;

namespace ISS_Wildcats.Backend.Controllers
{
    public class UserController : IUserController
    {
        private IUserService userService;
        private ISongController songController;

        public UserController(IUserService userService, ISongController songController)
        {
            this.userService = userService;
            this.songController = songController;
        }

        public void ChangeName(int userId, string newName)
        {
            userService.UpdateUserName(userId, newName);
        }

        public void ChangeEmail(int userId, string newEmail)
        {
            userService.UpdateUserEmail(userId, newEmail);
        }

        public void ChangePassword(int userId, string newPassword)
        {
            userService.UpdateUserPassword(userId, newPassword);
        }

        public void ChangeBirthDate(int userId, DateTime newBirthDate)
        {
            userService.UpdateUserBirthDate(userId, newBirthDate);
        }

        public void DeleteUser(int userId)
        {
            userService.DeleteUser(userId);
        }

        public void PlaySong(int songId)
        {
            songController.Play();
        }

        public void PauseSong()
        {
            songController.Pause();
        }

        public void SeekSong(int seconds)
        {
            songController.Seek(seconds);
        }
    }
}
