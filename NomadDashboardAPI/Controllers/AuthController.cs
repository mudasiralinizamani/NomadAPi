using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NomadDashboardAPI.Models;
using NomadDashboardAPI.ViewModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NomadDashboardAPI.Controllers
{
    // Route = api/auth/
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IOptions<AppSettings> _appSettings;

        public AuthController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _appSettings = appSettings;
        }

        // For Creating User as Empployee - Mudasir Ali
        // Route = /api/Auth/Employee/
        [HttpPost]
        [Route("Employee")]
        public async Task<object> Employee(EmployeeSignupModel model)
        {
            string currentDate = DateTime.Now.ToString("d/M/yyyy");

            var email = await _userManager.FindByEmailAsync(model.Email);

            if (email == null)
            {
                var appUser = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    IsActive = false,
                    CreatedAt = currentDate,
                    Email = model.Email,
                    LastIp = "",
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.UserName,
                    ProfilePic = model.ProfilePic,
                };

                try
                {
                    var result = await _userManager.CreateAsync(appUser, model.Password);
                    // To Create a new Employee Role - Mudasir Ali
                    //IdentityRole newRole = new IdentityRole()
                    //{
                    //    Name = "Employee"
                    //};
                    if (result.Succeeded)
                    {
                        //await _roleManager.CreateAsync(newRole);
                        var role = await _userManager.AddToRoleAsync(appUser, "Employee");
                    }

                    return Ok(result);
                }
                catch (Exception)
                {
                    return Ok(new { succeeded = false, code = "ServerError", description = "Something went wrong in the Server !" });
                }
            }
            else
            {
                return Ok(new { succeeded = false, error = "DuplicateEmail", description = "Email '" + model.Email + "' is already taken" });
            }
        }

        // For Creating User as Client - Mudasir Ali
        // Route = /api/Auth/Client/
        [HttpPost]
        [Route("Client")]
        public async Task<object> Client(ClientSignupModel model)
        {
            string currentDate = DateTime.Now.ToString("d/M/yyyy");

            var email = await _userManager.FindByEmailAsync(model.Email);

            if (email == null)
            {
                var appUser = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    IsActive = false,
                    CreatedAt = currentDate,
                    Email = model.Email,
                    LastIp = "",
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.UserName,
                    ProfilePic = model.ProfilePic,
                };

                try
                {
                    var result = await _userManager.CreateAsync(appUser, model.Password);
                    // To Create a new Client Role - Mudasir Ali
                    // IdentityRole newRole = new IdentityRole()
                    // {
                    //    Name = "Client"
                    // };
                    if (result.Succeeded)
                    {
                        // await _roleManager.CreateAsync(newRole);
                        var role = await _userManager.AddToRoleAsync(appUser, "Client");
                    }

                    return Ok(result);
                }
                catch (Exception)
                {
                    return Ok(new { succeeded = false, code = "ServerError", description = "Something went wrong in the Server !" });
                }
            }
            else
            {
                return Ok(new { succeeded = false, error = "DuplicateEmail", description = "Email '" + model.Email + "` is already taken" });
            }
        }

        // Route = /api/Auth/Signin
        [HttpPost]
        [Route("Signin")]
        public async Task<ActionResult> SigninUser(SigninModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            var password = await _userManager.CheckPasswordAsync(user, model.Password);
            try
            {
                if (user == null)
                {
                    return Ok(new { succeeded = false, code = "UsernameNotFound", description = "Username '" + model.UserName + "' was not Found" });
                }
                else if (user != null && !user.IsActive)
                {
                    return Ok(new { succeeded = false, code = "NotActivated", description = "Your Account is not Activated '" + model.UserName + "'" });
                }
                else if (user != null && !password)
                {
                    return Ok(new { succeeded = false, code = "IncorrectPassword", description = "Incorrect Password for '" + model.UserName + "'" });
                }
                else if (user != null && password && user.IsActive)
                {
                    var tokenDescription = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                          new Claim("UserID", user.Id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(336),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Value.JET_SECRECT_KEY)), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var secuarityToken = tokenHandler.CreateToken(tokenDescription);
                    var token = tokenHandler.WriteToken(secuarityToken);

                    return Ok(new { succeeded = true, description = "Successfully Authenticated", token = token });
                }
                else
                {
                    return Ok(new { succeeded = false, code = "InvalidCredentials", description = "Username or Password in Incorrect" });
                }
            }
            catch (Exception)
            {
                return Ok(new { succeeded = false, code = "ServerError", description = "Something went wrong in the Server !" });
            }
        }

        // This is Fucntion will return the user by token - Mudasir Ali
        // Route = /api/Auth/GetUser/
        [HttpGet]
        [Authorize]
        [Route("GetUser")]
        public async Task<object> GetUser()
        {
            string userId = User.Claims.First(i => i.Type == "UserID").Value;
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                return Ok(new { succeeded = true, user = user });
            }
            catch (Exception)
            {
                return Ok(new { succeeded = false, code = "ServerError", description = "Something went wrong in Server !" });
            }
        }
    }
}