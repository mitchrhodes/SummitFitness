using Capstone.DAO.Interfaces;
using Capstone.Models;
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
    public class EventsController : ControllerBase
    {
        
        private readonly IEventDAO eventDAO;

        public EventsController(IEventDAO _eventDAO)
        {
            
            eventDAO = _eventDAO;
        }

        [HttpGet]
        public ActionResult<List<Event>> GetEvents()
        {
            List<Event> events = new List<Event>();
            try
            {
                events = eventDAO.GetEvents();
                return Ok(events);
            }
            catch (SqlException ex)
            {
                return NotFound("Unable to communicate with database. Reporting this error: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<bool> GetUserEvents(int id)
        {
            bool result = false;
            try
            {
                result = eventDAO.GetUserEvents(id);
                return Ok();
            }
            catch (SqlException ex)
            {
                return NotFound("Unable to communicate with database. Reporting this error: " + ex.Message);
                
            }
        }
        [HttpPost]
        public ActionResult<bool> SignUp(SignUpInfo info)
        {
            bool result = false;
            try
            {
                result = eventDAO.SignUp(info);
                return Ok(result);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
