using Microsoft.AspNetCore.Mvc;
using Capstone.Models;
using Capstone.Security;
using Capstone.DAO.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenGenerator tokenGenerator;
        private readonly IPasswordHasher passwordHasher;
        private readonly IUserDAO userDAO;

        public LoginController(ITokenGenerator _tokenGenerator, IPasswordHasher _passwordHasher, IUserDAO _userDAO)
        {
            tokenGenerator = _tokenGenerator;
            passwordHasher = _passwordHasher;
            userDAO = _userDAO;
        }

        [AllowAnonymous]
        [HttpGet]
        public string Status()
        {
            string message = "Server started. ";
            try
            {
                //reads users table to comfirm database connection
                List<User> users = userDAO.GetUsers();
                message += "Running with " + users.Count + " users.";
            }
            catch (SqlException ex)
            {
                message += "Unable to communicate with database. Reporting this error: " + ex.Message;
            }

            return message;
        }

        [Authorize(Roles = "admin")]
        [HttpGet("admin")]
        public string AdminStatus()
        {
            string message = "Message from Admin user was sucessful.";
            return message;
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate(LoginUser userParam)
        {
            // Default to bad username/password message
            IActionResult result = Unauthorized(new { message = "Username or password is incorrect" });

            // Get the user by username
            User user = userDAO.GetUser(userParam.Username);

            // If we found a user and the password hash matches
            if (user != null && passwordHasher.VerifyHashMatch(user.PasswordHash, userParam.Password, user.Salt))
            {
                // Create an authentication token
                string token = tokenGenerator.GenerateToken(user.UserId, user.Username, user.Role);

                // Create a ReturnUser object to return to the client
                LoginResponse retUser = new LoginResponse() { User = new ReturnUser() { UserId = user.UserId, Username = user.Username, Role = user.Role }, Token = token };

                // Switch to 200 OK
                result = Ok(retUser);
            }

            return result;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(RegisterUser userParam)
        {
            IActionResult result;

            User existingUser = userDAO.GetUser(userParam.Username);
            if (existingUser != null)
            {
                return Conflict(new { message = "Username already taken. Please choose a different username." });
            }

            User user = userDAO.AddUser(userParam.Username, userParam.Password, userParam.Role);
            if (user != null)
            {
                result = Created(user.Username, null); //values aren't read on client
            }
            else
            {
                result = BadRequest(new { message = "An error occurred and user was not created." });
            }

            return result;
        }
    }
}
