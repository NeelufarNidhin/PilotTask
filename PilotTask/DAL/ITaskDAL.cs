using System;
using PilotTask.Models;

namespace PilotTask.DAL
{
	public interface ITaskDAL
	{
        List<Tasks> GetAllTasks();
        bool InsertTask(Tasks task);
        List<Tasks >GetTaskById(int id);
        bool UpdateTask(Tasks task);
        bool DeleteTask(int id);
        List<Tasks> GetAllTasksByProfileId(int profileId);
    }
}

