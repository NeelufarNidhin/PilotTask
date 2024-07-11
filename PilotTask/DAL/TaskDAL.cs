using System;
using System.Data;
using System.Data.SqlClient;
using PilotTask.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PilotTask.DAL
{
    public class TaskDAL : ITaskDAL
    {
        private readonly string _connString;
        public TaskDAL(IConfiguration configuration)
		{
          _connString = configuration.GetConnectionString("DefaultConnection");
        }

      public List<Tasks> GetAllTasks()
        {
            var taskList = new List<Tasks>();
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetAllTasks";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtTasks = new DataTable();
                connection.Open();
                sqlDA.Fill(dtTasks);
                connection.Close();

                foreach (  DataRow data in dtTasks.Rows)
                {
                    taskList.Add(new Tasks
                    {
                        Id = Convert.ToInt32(data["Id"]),
                        ProfileId = Convert.ToInt32(data["ProfileId"]),
                        TaskName = data["TaskName"].ToString(),
                        TaskDescription = data["TaskDescription"].ToString(),
                        StartTime = Convert.ToDateTime(data["StartTime"]),
                        Status = Convert.ToInt32(data["Status"])


                    }); 
                }

            }

            return taskList;

        }

        public bool InsertTask( Tasks task)
        {
            int i = 0;

            using (SqlConnection connection = new SqlConnection(_connString))
            {
                SqlCommand command = new SqlCommand("sp_InsertTasks", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProfileId", task.ProfileId);
                command.Parameters.AddWithValue("@TaskName", task.TaskName);
                command.Parameters.AddWithValue("@TaskDescription", task.TaskDescription);
                command.Parameters.AddWithValue("@StartTime", task.StartTime);
                command.Parameters.AddWithValue("@Status", task.Status);

                connection.Open();
                i = command.ExecuteNonQuery();
                connection.Close();

            }

            if(i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Tasks> GetTaskById(int id)
        {
            var taskList = new List<Tasks>();
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetTaskById";
                command.Parameters.AddWithValue("@Id", id);
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtTasks = new DataTable();
                connection.Open();
                sqlDA.Fill(dtTasks);
                connection.Close();

                foreach (DataRow data in dtTasks.Rows)
                {
                    taskList.Add(new Tasks
                    {
                        Id = Convert.ToInt32(data["Id"]),
                        ProfileId = Convert.ToInt32(data["ProfileId"]),
                        TaskName = data["TaskName"].ToString(),
                        TaskDescription = data["TaskDescription"].ToString(),
                        StartTime = Convert.ToDateTime(data["StartTime"]),
                        Status = Convert.ToInt32(data["Status"])


                    });
                }

            }

            return taskList;


        }

        public bool UpdateTask(Tasks task)
        {
            int i = 0;

            using (SqlConnection connection = new SqlConnection(_connString))
            {
                SqlCommand command = new SqlCommand("sp_UpdateTasks", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", task.Id);
                command.Parameters.AddWithValue("@ProfileId", task.ProfileId);
                command.Parameters.AddWithValue("@TaskName", task.TaskName);
                command.Parameters.AddWithValue("@TaskDescription", task.TaskDescription);
                command.Parameters.AddWithValue("@StartTime", task.StartTime);
                command.Parameters.AddWithValue("@Status", task.Status);

                connection.Open();
                i = command.ExecuteNonQuery();
                connection.Close();

            }

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteTask(int Id)
        {
            int i = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connString))
                {
                    SqlCommand command = new SqlCommand("sp_DeleteTask", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", Id);

                    connection.Open();
                    i = command.ExecuteNonQuery();
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Tasks> GetAllTasksByProfileId(int profileId)
        {
            var taskList = new List<Tasks>();
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetTaskByProfileId";
                command.Parameters.AddWithValue("@ProfileId", profileId);
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtTasks = new DataTable();
                connection.Open();
                sqlDA.Fill(dtTasks);
                connection.Close();

                foreach (DataRow data in dtTasks.Rows)
                {
                    taskList.Add(new Tasks
                    {
                        Id = Convert.ToInt32(data["Id"]),
                        ProfileId = Convert.ToInt32(data["ProfileId"]),
                        TaskName = data["TaskName"].ToString(),
                        TaskDescription = data["TaskDescription"].ToString(),
                        StartTime = Convert.ToDateTime(data["StartTime"]),
                        Status = Convert.ToInt32(data["Status"])


                    });
                }

            }

            return taskList;
        }
    }

        

}

