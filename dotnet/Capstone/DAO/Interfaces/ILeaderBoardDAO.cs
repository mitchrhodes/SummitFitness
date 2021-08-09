using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    public interface ILeaderBoardDAO
    {

        public List<Event> GetLeader(int eventId);
        public List<Event> LeaderComparison(int userId);
    }
}
