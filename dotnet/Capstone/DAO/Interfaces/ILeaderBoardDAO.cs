using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    public interface ILeaderBoardDAO
    {

        public List<EventLeaderBoard> GetLeader(int eventId);
        public List<EventLeaderBoard> LeaderComparison(int eventId, int userId);
    }
}
