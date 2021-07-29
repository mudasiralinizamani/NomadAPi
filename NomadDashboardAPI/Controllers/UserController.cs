using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NomadDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NomadDashboardAPI.Controllers
{
    // Route = /api/User/
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        // Route = /api/User/GetUserRole/
        [HttpGet]
        [Route("GetUserRole/{userName}")]
        public async Task<ActionResult> GetUserRole(string userName)
        {
            var appuser = await _userManager.FindByNameAsync(userName);
            try
            {
                if (appuser != null)
                {
                    var userRole = await _userManager.GetRolesAsync(appuser);

                    return Ok(new { succeeded = true, roles = userRole });
                }
                else
                {
                    return Ok(new { succeeded = false, code = "UsernameNotFound", description = "Username '" + userName + "' was not Found" });
                }
            }
            catch (Exception)
            {
                return Ok(new { succeeded = false, code = "ServerError", description = "Something went wrong in the Server !" });
            }
        }

        // Route = /api/user/GetAllUsers/
        [HttpGet]
        [Route("GetAllUsers")]
        public ActionResult GetAllUsers()
        {
            // try
            // {
            var users = _userManager.Users;

            return Ok(users);
            // }
            // catch (Exception)
            // {
            //     return Ok(new { succeeded = false, code = "ServerError", description = "Something went wrong in Server !" });
            // }
        }

        // Route = /api/User/GetUserByUserName/
        [HttpGet]
        [Route("GetUserByUserName/{username}")]
        public async Task<ActionResult> GetUserByUserName(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            try
            {
                if (user != null)
                {
                    return Ok(new { succeeded = true, user = user });
                }
                else
                {
                    return Ok(new { succeeded = false, code = "UsernameNotFound", description = "Username '" + username + "' was not Found" });
                }
            }
            catch (Exception)
            {
                return Ok(new { succeeded = false, code = "ServerError", description = "Something went wrong in Server !" });
            }
        }

        // Route = /api/Users/GetAllUsersCount/
        // This method will return a number of total user in DataBase
        [HttpGet]
        [Route("GetAllUsersCount")]
        public ActionResult GetAllUsersCount()
        {
            try
            {
                List<User> count = _userManager.Users.ToList();
                return Ok(new { succeeded = true, count = count.Count });
            }
            catch (Exception)
            {
                return Ok(new { succeeded = false, code = "ServerError", description = "Something went wrong in Server !" });
            }
        }
    }
}