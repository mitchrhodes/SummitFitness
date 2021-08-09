using Capstone.Models;
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
    public class LeaderBoardController : ControllerBase
    {
  
            private readonly ILeaderBoardDAO leaderBoardDAO;

            public LeaderBoardController(ILeaderBoardDAO _leaderBoardDAO)
            {
                ILeaderBoardDAO = _leaderbaordDAO;
            }


            [HttpGet]
            public ActionResult<List<Event>> LeaderComparison() 
            {
                int userId = int.Parse(this.User.FindFirst("sub").Value);

                List<Event> events = new List<Event>();
                try
                {
                    events = leaderBoardDAO.GetEvents(userId);
                    return Ok(events);
                }
                catch (SqlException ex)
                {
                    return NotFound("Unable to communicate with database. Reporting this error: " + ex.Message);
                }
            }

            [HttpGet("{eventId}")]
            public ActionResult<List<Event>> GetLeader(int eventId)
            {
                List<Event> events = new List<Event>();
                try
                {
                    events = leaderBoardDAO.GetLeaders(eventId);
                    return Ok(events);
                }
                catch (SqlException ex)
                {
                    return NotFound("Unable to communicate with database. Reporting this error: " + ex.Message);
                }
            }
        }
    }

