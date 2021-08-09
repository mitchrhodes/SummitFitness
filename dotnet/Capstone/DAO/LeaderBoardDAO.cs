using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Capstone.DAO
{
    public class LeaderBoardDAO: ILeaderBoardDAO
    {
       
            private readonly string connectionString;
            public LeaderBoardDAO(string dbConnectionString)
            {
                connectionString = dbConnectionString;
            }

            public List<Event> GetEvents(int id)
            {
                List<Event> events = new List<Event>();

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {

                        conn.Open();
                        SqlCommand cmd = new SqlCommand("SELECT user_log.date_time, events.name, user_log.distance_progress FROM user_log " +
                            "JOIN user_events ON user_log.user_id = user_events.user_id JOIN events ON user_events.event_id = events.event_id " +
                            "WHERE user_log.user_id = @userId AND user_log.event_id IS NOT NULL", conn);
                        cmd.Parameters.AddWithValue("@userId", id);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Event e = new Event();
                            e.Name = Convert.ToString(reader["name"]);
                            e.DistanceProgress = Convert.ToString(reader["distance_progress"]);
                            e.Date = Convert.ToDateTime(reader["date_time"]);
                            events.Add(e);

                        }
                    }
                }
                catch (Exception ex)
                {
                    events = new List<Event>();
                }
                return events;
            }

        }
    }
