﻿using System;
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
                    cmd.Parameters.AddWithValue("@period", int.Parse(e.Duration));
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
