using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace CyberSecurityBot
{
    public class DatabaseHelper
    {
        private string connectionString =
            "server=localhost;database=CyberSecurityBot;uid=root;pwd=Azwi@1898;";

        public void AddTask(TaskItem task)
        {
            using (MySqlConnection conn =
                   new MySqlConnection(connectionString))
            {
                conn.Open();

                string query =
                @"INSERT INTO Tasks
                (Title, Description, ReminderDate)
                VALUES
                (@title,@desc,@date)";

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@title", task.Title);
                cmd.Parameters.AddWithValue("@desc", task.Description);
                cmd.Parameters.AddWithValue("@date", task.ReminderDate);

                cmd.ExecuteNonQuery();
            }
        }

        public List<TaskItem> GetTasks()
        {
            List<TaskItem> tasks = new List<TaskItem>();

            using (MySqlConnection conn =
                   new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Tasks";

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                MySqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    tasks.Add(new TaskItem
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Title = Convert.ToString(reader["Title"]) ?? string.Empty,
                        Description = Convert.ToString(reader["Description"]) ?? string.Empty,
                        ReminderDate =
                            reader["ReminderDate"] == DBNull.Value
                            ? null
                            : Convert.ToDateTime(reader["ReminderDate"]),
                        IsCompleted =
                            Convert.ToBoolean(reader["IsCompleted"])
                    });
                }
            }

            return tasks;
        }

        public void DeleteTask(int id)
        {
            using (MySqlConnection conn =
                   new MySqlConnection(connectionString))
            {
                conn.Open();

                string query =
                    "DELETE FROM Tasks WHERE Id=@id";

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        public void CompleteTask(int id)
        {
            using (MySqlConnection conn =
                   new MySqlConnection(connectionString))
            {
                conn.Open();

                string query =
                @"UPDATE Tasks
                  SET IsCompleted = TRUE
                  WHERE Id=@id";

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}