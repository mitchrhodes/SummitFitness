using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    interface IHistoryDAO
    {
        public List<Goal> GetGoals();
        public List<Event> GetEvents();
    }
}
