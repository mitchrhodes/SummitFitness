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

    }
}
