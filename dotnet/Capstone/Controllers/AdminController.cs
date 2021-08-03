using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserDAO userDAO;
        [Authorize(Roles = "admin")]
        [HttpGet]

        public ActionResult<List<User>> GetUsers()


        {
            List<User> users = new List<User>();

            try
            {
                users = userDAO.GetUsers();

            }

            catch (SqlException ex)
            {
                return NotFound("Unable to communicate with database. Reporting this error: " + ex.Message);

            }

            return users;

        }


    }

    
}
