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
        private readonly IEventDAO eventDAO;

        public AdminController(IUserDAO _userDAO, IEventDAO _eventDAO)
        {
            userDAO = _userDAO;
            eventDAO = _eventDAO;
        }
        [Authorize(Roles = "admin")]
        [HttpGet]

        public ActionResult<List<User>> GetUsers()
        {
            List<User> users = new List<User>();
            try
            {
                users = userDAO.GetUsers();
                return Ok(users);
            }
            catch (SqlException ex)
            {
                return NotFound("Unable to communicate with database. Reporting this error: " + ex.Message);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPut]

        public ActionResult<bool> UpdateAdmin(User user)
        {
            bool result = false;
            try
            {
                result = userDAO.UpdateToAdmin(user.Username);
                return Ok(result);
            }
            catch (SqlException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult<bool> AddEvent(Event e)
        {
            bool result = false;
            try
            {
                result = eventDAO.AddEvent(e);
                return Ok(result);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}



