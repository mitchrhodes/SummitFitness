using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class EventLeaderBoard
    {
        public string EventName { get; set; }
        public string UserName { get; set; }
        public int DistanceProgress { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
    }
}
