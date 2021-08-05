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

    }
}
