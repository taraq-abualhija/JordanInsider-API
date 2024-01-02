using JordanInsider.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordanInsider.Core.Service
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserById(decimal id);
        void CreateUser(User userData);
        void UpdateUser(User userData);
        void DeleteUser(decimal id);
    }
}
