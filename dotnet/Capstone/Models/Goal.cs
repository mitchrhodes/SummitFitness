using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Goal
    {
        public int GoalId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Type { get; set; }

        public string Distance { get; set; }
        public string Time { get; set; }
        public string DistanceProgress { get; set; }

        public string TimeProgress { get; set; }
        public string Date { get; set; }
       


    }
}
