using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
   public  interface IGoalDAO
    {
        public bool AddGoal(Goal goal);
        public List<Goal> GetGoals(int id);
        public bool LogGoal(Goal goal);
        

    }
}
