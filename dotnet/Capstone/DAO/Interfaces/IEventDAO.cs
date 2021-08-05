using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    public interface IEventDAO
    {
        public bool AddEvent(Event e);
        public List<Event> GetEvents();
        public bool SignUp(SignUpInfo info);
    }
}
