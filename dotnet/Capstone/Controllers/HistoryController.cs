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
    public class HistoryController : ControllerBase
    {

        private readonly IHistoryDAO historyDAO;

        public HistoryController(IHistoryDAO _historyDAO)
        {
            historyDAO = _historyDAO;
        }


        [HttpGet]
        public ActionResult<List<Event>> GetEvents()
        {
            int id = int.Parse(this.User.FindFirst("sub").Value);
            
            List<Event> events = new List<Event>();
            try
            {
                events = historyDAO.GetEvents(id);
                return Ok(events);
            }
            catch (SqlException ex)
            {
                return NotFound("Unable to communicate with database. Reporting this error: " + ex.Message);
            }
        }


        [HttpGet("{goal}")]
        public ActionResult<List<Goal>> GetGoals()
        {
            int id = int.Parse(this.User.FindFirst("sub").Value);

            List<Goal> goals = new List<Goal>();
            try
            {
                goals = historyDAO.GetGoals(id);
                return Ok(goals);
            }
            catch (SqlException ex)
            {
                return NotFound("Unable to communicate with database. Reporting this error: " + ex.Message);
            }
        }
    }
}
