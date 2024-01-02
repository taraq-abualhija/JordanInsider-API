using JordanInsider.Core.Models;
using JordanInsider.Core.Repository;
using JordanInsider.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordanInsider.Infra.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(decimal id)
        {
            return _userRepository.GetUserById(id);
        }

        public void CreateUser(User userData)
        {
            _userRepository.CreateUser(userData);
        }

        public void UpdateUser(User userData)
        {
            _userRepository.UpdateUser(userData);
        }

        public void DeleteUser(decimal id)
        {
            _userRepository.DeleteUser(id);
        }
    }
}
