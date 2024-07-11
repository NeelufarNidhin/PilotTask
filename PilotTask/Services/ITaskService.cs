using System;
using PilotTask.Models;

namespace PilotTask.Services
{
	public interface ITaskService
	{
        List<Tasks> GetAllTaskDetails();
        bool CreateTaskDetails(Tasks task);
        List<Tasks> GetTaskById(int id);
        bool UpdateTaskDetails(Tasks task);
        bool DeleteTaskDetails(int id);
        List<Tasks> GetAllTaskDetailsByProfileId(int profileId);
    }
}

