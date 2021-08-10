using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace Capstone.DAO
{
    public class LeaderBoardDAO : ILeaderBoardDAO
    {

        private readonly string connectionString;
        public LeaderBoardDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<EventLeaderBoard> GetLeader(int id)
        {
            List<EventLeaderBoard> eventLeaders = new List<EventLeaderBoard>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TOP 5 user_events.distance_progress, events.name, users.username " +
                        "FROM user_events JOIN users ON users.user_id = user_events.user_id " +
                        "JOIN events ON events.event_id = user_events.event_id WHERE events.event_id = @eventId " +
                        "ORDER BY user_events.distance_progress DESC", conn);
                    cmd.Parameters.AddWithValue("@eventId", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        EventLeaderBoard leaders = new EventLeaderBoard();
                        leaders.EventName = Convert.ToString(reader["name"]);
                        leaders.DistanceProgress = Convert.ToInt32(reader["distance_progress"]);
                        leaders.UserName = Convert.ToString(reader["username"]);
                        eventLeaders.Add(leaders);
                    }
                }
            }
            catch (Exception ex)
            {
                eventLeaders = new List<EventLeaderBoard>();
            }
            return eventLeaders;
        }

        public List<EventLeaderBoard> LeaderComparison(int eventId, int userId)
        {
            List<EventLeaderBoard> eventLeaders = new List<EventLeaderBoard>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT user_events.distance_progress, events.name, users.username FROM user_events " +
                        "JOIN users ON users.user_id = user_events.user_id " +
                        "JOIN events ON events.event_id = user_events.event_id " +
                        "WHERE events.event_id = @eventId AND users.user_id = @userId", conn);
                    cmd.Parameters.AddWithValue("@eventId", eventId);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        EventLeaderBoard leaders = new EventLeaderBoard();
                        leaders.EventName = Convert.ToString(reader["name"]);
                        leaders.DistanceProgress = Convert.ToInt32(reader["distance_progress"]);
                        leaders.UserName = Convert.ToString(reader["username"]);
                        eventLeaders.Add(leaders);
                    }
                }
            }
            catch (SqlException ex)
            {
                eventLeaders = new List<EventLeaderBoard>();
            }
            return eventLeaders;
        }
    }

}

