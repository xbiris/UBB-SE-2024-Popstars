using System;
using ISS_Wildcats.Backend.Models;
using ISS_Wildcats.Backend.Repos;

namespace ISS_Wildcats.Backend.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepo userRepo;

        public UserService(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        public User GetUser(int userId)
        {
            return userRepo.Get(userId);
        }

        public void AddUser(User user)
        {
            userRepo.Add(user);
        }

        public void UpdateUser(User user)
        {
            userRepo.Update(user);
        }

        public void DeleteUser(int userId)
        {
            userRepo.Delete(userId);
        }

        public void UpdateUserName(int userId, string newName)
        {
            var user = userRepo.Get(userId);
            user.Name = newName;
            userRepo.Update(user);
        }

        public void UpdateUserEmail(int userId, string newEmail)
        {
            var user = userRepo.Get(userId);
            user.Email = newEmail;
            userRepo.Update(user);
        }

        public void UpdateUserPassword(int userId, string newPassword)
        {
            var user = userRepo.Get(userId);
            user.Password = newPassword;
            userRepo.Update(user);
        }

        public void UpdateUserBirthDate(int userId, DateTime newBirthDate)
        {
            var user = userRepo.Get(userId);
            user.BirthDate = newBirthDate;
            userRepo.Update(user);
        }
    }
}
