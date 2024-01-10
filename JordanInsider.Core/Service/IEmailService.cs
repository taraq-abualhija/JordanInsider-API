using JordanInsider.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordanInsider.Core.Service
{
   public interface IEmailService
    {
        public void SendEmail(SendEmailDTO emailDto);

    }
}
