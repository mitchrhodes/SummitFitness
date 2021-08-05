using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {

        [HttpPost]
        public ActionResult<bool> AddGoal(Goal goal)
        {
            bool result = false;
            try
            {
                result = goalDAO.AddGoal(goal);
                return Ok(result);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

