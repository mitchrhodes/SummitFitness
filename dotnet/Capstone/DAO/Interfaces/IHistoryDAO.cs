using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    public interface IHistoryDAO
    {
        public List<Goal> GetGoals(int id);
        public List<Event> GetEvents(int id);
    }
}
