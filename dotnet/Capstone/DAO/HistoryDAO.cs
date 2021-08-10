using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class HistoryDAO : IHistoryDAO
    {
        private readonly string connectionString;
        public HistoryDAO(string dbConnectionString)
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
                    SqlCommand cmd = new SqlCommand("SELECT date_time, distance_progress, event_id FROM user_log WHERE user_id = @user_id AND event_id IS NOT NULL;", conn);
                    cmd.Parameters.AddWithValue("@user_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Event e = new Event();
                        e.EventId = Convert.ToInt32(reader["event_id"]);
                        e.DistanceProgress = Convert.ToString(reader["distance_progress"]);
                        e.Date = (Convert.ToDateTime(reader["date_time"])).ToShortDateString();
                        
                        events.Add(e);
                    }
                }
                foreach (Event e in events)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("SELECT name FROM events WHERE event_id = @event_id", conn);
                        cmd.Parameters.AddWithValue("@event_id", e.EventId);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            e.Name = Convert.ToString(reader["name"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                events = new List<Event>();
            }
            return events;
        }

        public List<Goal> GetGoals(int id)
        {
            List<Goal> goals = new List<Goal>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT date_time, distance_progress, goal_id FROM user_log WHERE user_id = @user_id AND goal_id IS NOT NULL;", conn);
                    cmd.Parameters.AddWithValue("@user_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Goal goal = new Goal();
                        goal.GoalId = Convert.ToInt32(reader["goal_id"]);
                        goal.DistanceProgress = Convert.ToString(reader["distance_progress"]);
                        goal.Date = (Convert.ToDateTime(reader["date_time"])).ToShortDateString();
                        goals.Add(goal);
                    }
                }
                foreach (Goal goal in goals)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("SELECT goal_name FROM goals WHERE goal_id = @goal_id", conn);
                        cmd.Parameters.AddWithValue("@goal_id", goal.GoalId);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            goal.Name = Convert.ToString(reader["goal_name"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                goals = new List<Goal>();
            }
            return goals;
        }


    }
}
