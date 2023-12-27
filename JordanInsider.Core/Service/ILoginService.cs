using JordanInsider.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordanInsider.Core.Service
{
    public interface ILoginService
    {
        public string GenearteToken(User user); 

    }
}
