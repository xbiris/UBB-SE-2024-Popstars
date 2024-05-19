using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISS_Wildcats.Backend.Models;

namespace ISS_Wildcats.Backend.Repos
{
    public interface IUserRepo
    {
        User Get(int userId);
        void Add(User user);
        void Update(User user);
        void Delete(int userId);
    }
}
