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
            int id = int.Parse(this.User.FindFirst("sub").Value);
            try
            {
                events = eventDAO.GetEvents(id);
                return Ok(events);
            }
            catch (SqlException ex)
            {
                return NotFound("Unable to communicate with database. Reporting this error: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<List<Event>> GetUserEvents(int id)
        {
            List<Event> events = new List<Event>();
            try
            {
                events = eventDAO.GetUserEvents(id);
                return Ok(events);
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
        [HttpPut]
        public ActionResult<bool> AddProgressToEvent (UserEvent userEvent)
        {

            int id = int.Parse(this.User.FindFirst("sub").Value);
            userEvent.UserId = id;
            bool result = false;
            try
            {
                result = eventDAO.AddProgressToEvent(userEvent);
                return Ok(result);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
