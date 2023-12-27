using JordanInsider.Core.Models;
using JordanInsider.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JordanInsider.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;
        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult GenarateToken([FromBody] User login)
        {
            var token = loginService.GenearteToken(login);

            if (token != null)
            {
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }


        }

    }
}
