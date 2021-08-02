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
        private readonly Security.EmailTools emailTools = new Security.EmailTools();
        public ChangePasswordController(IUserDAO _userDAO)
        {
           
            userDAO = _userDAO;
        }

        [HttpPut]
        public ActionResult<bool> ChangePassword(UpdatedPasswordUser user)

        {

            bool result = userDAO.ChangeUserPassword(user);

            if (result)
            {
                emailTools.EmailPasswordChangeConfirmation(user.EmailAddress);
                return Ok();
            }
            else
            {
                return NotFound("User not found");
            }

        }

    }
}
