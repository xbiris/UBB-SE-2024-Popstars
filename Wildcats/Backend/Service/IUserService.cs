using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISS_Wildcats.Backend.Models;

namespace ISS_Wildcats.Backend.Service
{
    public interface IUserService
    {
        User GetUser(int userId);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        void UpdateUserName(int userId, string newName);
        void UpdateUserEmail(int userId, string newEmail);
        void UpdateUserPassword(int userId, string newPassword);
        void UpdateUserBirthDate(int userId, DateTime newBirthDate);
    }
}
