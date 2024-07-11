using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using PilotTask.Models;
using PilotTask.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PilotTask.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        // GET: Task
        public ActionResult Index(int profileId)
        {
            IEnumerable<Tasks> taskList = _taskService.GetAllTaskDetailsByProfileId(profileId);
            ViewBag.ProfileId = profileId;
            return View(taskList);
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            var task = _taskService.GetTaskById(id).FirstOrDefault();
            if(task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        //// GET: Task/Create
        public ActionResult Create(int profileId)
        {
            var task = new Tasks { ProfileId = profileId };
            return View(task);
        }

        // POST: Task/Create
        [HttpPost]
       
        public ActionResult Create(Tasks task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _taskService.CreateTaskDetails(task);

                    if (result)
                    {
                        TempData["SuccessMessage"] = "Task Added Successfuly";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to add Task ";
                    }

                    return RedirectToAction(nameof(Index), new {profileId = task.ProfileId });
                }
               
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return View(message);
            }

            return View(task);
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var task = _taskService.GetTaskById(id).FirstOrDefault();
                if (task == null)
                {
                    return NotFound();
                }
                return View(task);
            }
            catch (Exception ex)
            {

                string message = ex.Message;
                return View(message);

            }
            
        }

        
        [HttpPost, ActionName("Edit")]

        public ActionResult EditTask( Tasks task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _taskService.UpdateTaskDetails(task);

                    if (result)
                    {
                        TempData["SuccessMessage"] = "Task Updated Successfuly";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to update Task ";
                    }

                    return RedirectToAction(nameof(Index), new { profileId = task.ProfileId });
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return View(message);
            }

            return View(task);
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var task = _taskService.GetTaskById(id).FirstOrDefault();

                if (task == null)
                {
                    return NotFound();
                }
                return View(task);
            }
            catch (Exception ex)
            {

                string message = ex.Message;
                return View(message);

            }
        }

      
        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteTasK(int id)
        {
            try
            {
                var task = _taskService.GetTaskById(id).FirstOrDefault();

                if(task == null)
                {
                    return NotFound();
                }
                var result = _taskService.DeleteTaskDetails(id);

                if (result)
                {
                    TempData["SuccessMessage"] = "Task Delete Successfuly";
                }
                else
                {
                    TempData["ErrorMessage"] = "Unable to delete Task ";
                }
                return RedirectToAction(nameof(Index),new { profileId = task.ProfileId });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }
    }
}