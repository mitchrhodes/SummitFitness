using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Duration { get; set; }
        public int EventId { get; set; }
        public string DistanceProgress { get; set; }
        public string Date { get; set; }


    }
}
