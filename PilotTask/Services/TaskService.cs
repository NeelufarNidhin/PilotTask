using System;
using PilotTask.DAL;
using PilotTask.Models;

namespace PilotTask.Services
{
	public class TaskService : ITaskService
    {
		private readonly ITaskDAL _taskDAL;
        public TaskService(ITaskDAL taskDAL)
        {
            _taskDAL = taskDAL;
        }

        public bool CreateTaskDetails(Tasks task)
        {
            bool IsInserted = false;

            try
            {
                IsInserted = _taskDAL.InsertTask(task);
            }
            catch(Exception ex)
            {
                string message = ex.Message;
            }

            return IsInserted;
        }

        public bool DeleteTaskDetails(int id)
        {
            bool isDeleted = false;
            try
            {
                isDeleted = _taskDAL.DeleteTask(id);


            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return isDeleted;
        }

        public List<Tasks> GetAllTaskDetails()
        {
            List<Tasks> tasks = _taskDAL.GetAllTasks();

            return tasks;
        }

        public List<Tasks> GetAllTaskDetailsByProfileId(int profileId)
        {
            return _taskDAL.GetAllTasksByProfileId(profileId);
        }

        public List<Tasks> GetTaskById(int id)
        {
            return  _taskDAL.GetTaskById(id).ToList();
           
        }

        public bool UpdateTaskDetails(Tasks task)
        {
            bool IsUpdated = false;

            try
            {
                IsUpdated = _taskDAL.UpdateTask(task);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return IsUpdated;
        }
    }
}

