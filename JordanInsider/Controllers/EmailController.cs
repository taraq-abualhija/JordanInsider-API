using JordanInsider.Core.DTO;
using JordanInsider.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JordanInsider.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost(Name = "SendEmail")]
        public void SendEmail(SendEmailDTO emailDto)
        {
            _emailService.SendEmail(emailDto);
        }
    }
}
