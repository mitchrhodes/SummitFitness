using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChangePasswordController : ControllerBase
    {
        private readonly IUserDAO userDAO;
        private readonly Security.EmailTools emailTools;
        public ChangePasswordController(IUserDAO _userDAO)
        {
           
            userDAO = _userDAO;
        }

        [HttpPut]
        public ActionResult<User> ChangePassword(User user)
        {
            User updatedUser = userDAO.ChangeUserPassword(user);

            if (updatedUser != null)
            {
                emailTools.EmailPasswordChangeConfirmation(updatedUser.Email);
                return Ok(updatedUser);
            }
            else
            {
                return NotFound("User not found");
            }

        }

    }
}
