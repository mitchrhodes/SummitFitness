using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.DAO.Interfaces;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class EventDAO : IEventDAO
    {
        private readonly string connectionString;
       
        public EventDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public bool AddEvent(Event e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO events (name, description, type, period_in_days) VALUES (@name, @description, @type, @period)", conn);
                    cmd.Parameters.AddWithValue("@name", e.Name);
                    cmd.Parameters.AddWithValue("@description", e.Description);
                    cmd.Parameters.AddWithValue("@type", e.Type);
                    cmd.Parameters.AddWithValue("@period", (e.Duration));
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }
        public List<Event> GetEvents()
        {
            List<Event> events = new List<Event>();
           
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT event_id, name, description, type, period_in_days FROM events", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Event e = new Event();
                        e.EventId = Convert.ToInt32(reader["event_id"]);
                        e.Name = Convert.ToString(reader["name"]);
                        e.Type = Convert.ToString(reader["type"]);
                        e.Description = Convert.ToString(reader["description"]);
                        e.Duration = Convert.ToString(reader["period_in_days"]);
                       events.Add (e);

                    }
}
            }
            catch (Exception ex)
            {
                events = new List<Event>();
            }
            return events;
        }

        public bool SignUp(SignUpInfo info)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO user_events (event_id, user_id) VALUES (@event_id, @user_id)", conn);
                    cmd.Parameters.AddWithValue("@event_id", info.EventId);
                    cmd.Parameters.AddWithValue("@user_id", info.UserId);
                    
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }
    }
}

//        public List<Event> GetEvents()
//        {
//            List<Event> events = new List<Event>();

//            try
//            {
//                using (SqlConnection conn = new SqlConnection(connectionString))
//                {
//                    conn.Open();
//                    SqlCommand cmd = new SqlCommand(sqlGetPets, conn);
//                    SqlDataReader reader = cmd.ExecuteReader();
//                    while (reader.Read())
//                    {
//                        Event event = new Event();
//                        event.Name = Convert.ToString(reader["name"]);
//                        event.Type = Convert.ToString(reader["type"]);
//                        event.Description = Convert.ToString(reader["description"]);
//                        event.Duration = Convert.ToInt32(reader["period_in_days"]);
//                        events.Add (event);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Event = new List<Event>();
//            }
//            return event;
//        }
//    }
//}

//}

   

           
   
       