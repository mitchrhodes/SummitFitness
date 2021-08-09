using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class UserEvent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Duration { get; set; }
        public int EventId { get; set; }
        public int EventProgress { get; set; }
        public DateTime dateTime { get; set; }


    }
}
