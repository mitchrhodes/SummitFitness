using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class GoalDAO : IGoalDAO
    {
        private readonly string connectionString;

        private User user = new User();


        public GoalDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public bool AddGoal(Goal goal)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO goals (user_id, goal_name, goal_description, goal_type, period_in_days, distance) VALUES (@user_id, @goal_name, @goal_description, @goal_type, @period_in_days, @distance)", conn);

                    cmd.Parameters.AddWithValue("@user_id", goal.UserId);
                    cmd.Parameters.AddWithValue("@goal_name", goal.Name);
                    cmd.Parameters.AddWithValue("@goal_description", goal.Description);
                    cmd.Parameters.AddWithValue("@goal_type", goal.Type);
                    cmd.Parameters.AddWithValue("@period_in_days", goal.Duration);
                    cmd.Parameters.AddWithValue("@distance", goal.Distance);

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        public List<Goal> GetGoals(int id)
        {
            List<Goal> goals = new List<Goal>();

            

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM goals WHERE user_id = @userId", conn);
                    cmd.Parameters.AddWithValue("@userId", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Goal goal = new Goal();
                        goal.GoalId= Convert.ToInt32(reader["goal_id"]);
                        goal.UserId = Convert.ToInt32(reader["user_id"]);
                        goal.Name = Convert.ToString(reader["goal_name"]);
                        goal.Description = Convert.ToString(reader["goal_description"]);
                        goal.Type = Convert.ToString(reader["goal_type"]);
                        goal.Duration = Convert.ToString(reader["period_in_days"]);
                        goal.Distance = Convert.ToString(reader["distance"]);
                        goal.Time = Convert.ToString(reader["time"]);
                        goal.DistanceProgress = Convert.ToString(reader["distance_progress"]);
                        goal.TimeProgress = Convert.ToString(reader["time_progress"]);
                      
                        goals.Add(goal);

                    }
                }
            }
            catch (Exception ex)
            {
                goals = new List<Goal>();
            }
            return goals;
        }
        public bool LogGoal(Goal goal)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE goals SET  distance_progress =(SELECT distance_progress FROM goals WHERE goal_id = @goal_id) + @distance_progress WHERE goal_id = @goal_id", conn);
                    
                    cmd.Parameters.AddWithValue("@distance_progress", goal.DistanceProgress);
                    cmd.Parameters.AddWithValue("@goal_id", goal.GoalId);

                    cmd.ExecuteNonQuery();
                }

                AddHistoryLog(goal);

                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        public bool AddHistoryLog(Goal goal)
        {
           
            goal.Date = DateTime.Now.ToShortDateString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO user_log (user_id, goal_id, distance_progress, date_time) VALUES (@user_id, @goal_id, @distance_progress, @date_time)", conn);

                    cmd.Parameters.AddWithValue("@user_id", goal.UserId);
                    cmd.Parameters.AddWithValue("@goal_id", goal.GoalId);
                    cmd.Parameters.AddWithValue("@distance_progress", goal.DistanceProgress);
                    cmd.Parameters.AddWithValue("@date_time", goal.Date);


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
