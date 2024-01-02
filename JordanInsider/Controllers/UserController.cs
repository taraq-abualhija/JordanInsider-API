using JordanInsider.Core.Models;
using JordanInsider.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JordanInsider.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving users: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = userService.GetUserById(id);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the user: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateCoordinator")]
        public IActionResult CreateCoordinator(User userData)
        {

            try
            {
                if (userData.Roleid == null)
                {
                    userData.Roleid = 2;
                }
                userService.CreateUser(userData);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the user: " + ex.Message);
            }
        }
        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser(User userData)
        {

            try
            {
                if (userData.Roleid == null)
                {
                    userData.Roleid = 3;
                }
                userService.CreateUser(userData);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the user: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(User userData)
        {
            try
            {
                userService.UpdateUser(userData);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the user: " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                userService.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the user: " + ex.Message);
            }
        }
    }
}
