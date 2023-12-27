using JordanInsider.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordanInsider.Core.Repository
{

    public interface ILoginRepository
    {
        public User GenerateToken(User user);
    }
}
