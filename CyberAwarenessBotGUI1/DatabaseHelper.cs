using Microsoft.Data.SqlClient; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberAwarenessBotGUI1
{
    public static class DatabaseHelper
    {
        // Moving the CyberTask class inside DatabaseHelper ensures Visual Studio sees it perfectly.
        public class CyberTask
        {
            public int Id { get; set; }
            public string Title { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public int? ReminderDays { get; set; }
            public bool IsCompleted { get; set; }
        }

        // Connection string pointing to the local SQL Server Management Studio database instance.
        private static string connectionString = "Server=LabVM2049939\\SQLEXPRESS;Database=CyberAwarenessDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // 1. ADD TASK: Inserts a new security task into the SQL Server Database. Implemented the CRUD functionality that creates, reads, updates and deletes data after every change to ensure the database is always synced.
        public static bool AddTask(string title, string description, int? reminderDays)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO tasks (title, description, reminder_days, is_completed) VALUES (@title, @desc, @reminder, 0);";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@title", title);
                        command.Parameters.AddWithValue("@desc", description);
                        command.Parameters.AddWithValue("@reminder", (object)reminderDays ?? DBNull.Value);

                        connection.Open();
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                
                System.Diagnostics.Debug.WriteLine("Error adding task: " + ex.Message);
                return false;
            }
        }

        // 2. VIEW ALL TASKS: Retrieves all existing records from the database into a list.
        public static List<CyberTask> GetAllTasks()
        {
            List<CyberTask> taskList = new List<CyberTask>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT id, title, description, reminder_days, is_completed FROM tasks;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CyberTask task = new CyberTask
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                                    Title = reader.IsDBNull(reader.GetOrdinal("title")) ? string.Empty : reader.GetString(reader.GetOrdinal("title")),
                                    Description = reader.IsDBNull(reader.GetOrdinal("description")) ? string.Empty : reader.GetString(reader.GetOrdinal("description")),
                                    ReminderDays = reader.IsDBNull(reader.GetOrdinal("reminder_days")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("reminder_days")),
                                    IsCompleted = reader.GetBoolean(reader.GetOrdinal("is_completed"))
                                };
                                taskList.Add(task);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error fetching tasks: " + ex.Message);
            }
            return taskList;
        }

        // 3. MARK TASK COMPLETED: Updates the completion inside the table row.
        public static bool CompleteTask(int taskId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE tasks SET is_completed = 1 WHERE id = @id;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", taskId);
                        connection.Open();
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error completing task: " + ex.Message);
                return false;
            }
        }

        // 4. DELETE TASK: Completely removes the specified task row from storage.
        public static bool DeleteTask(int taskId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM tasks WHERE id = @id;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", taskId);
                        connection.Open();
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error deleting task: " + ex.Message);
                return false;
            }
        }
    }
}
