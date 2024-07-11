using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using PilotTask.Models;
using PilotTask.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PilotTask.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        // GET: Profile
        public ActionResult Index()
        {
            IEnumerable<Profiles> profiles = _profileService.GetAllProfileDetails();

            return View(profiles);
        }

        
        
        // GET: Profile/Details/5
        public ActionResult Details(int profileId)
        {
            var profile = _profileService.GetProfileById(profileId).FirstOrDefault();
            return View(profile);
        }

        // GET: Profile/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        
        public ActionResult Create(Profiles profile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _profileService.CreateProfileDetails(profile);

                    if (result)
                    {
                        TempData["SuccessMessage"] = "Profile Added Successfuly";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to add Profile ";
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
               
            catch(Exception ex)
            {
                string message = ex.Message;
                return View(message);
            }
            return View(profile);
        }


        public ActionResult Edit(int profileId)
        {
            try
            {
                var profile = _profileService.GetProfileById(profileId).FirstOrDefault();

                if (profile == null)
                {
                    return NotFound();
                }
                return View(profile);
            }
            catch (Exception ex)
            {

                string message = ex.Message;
                return View(message);

            }
           
        }


        [HttpPost, ActionName("Edit")]
        public ActionResult UpdateProfile( Profiles profile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _profileService.UpdateProfileDetails(profile);

                    if (result)
                    {
                        TempData["SuccessMessage"] = "Profile Updated Successfuly";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to add Profile ";
                    }
                    return RedirectToAction("Index");
                }
            }

            catch (Exception ex)
            {
                string message = ex.Message;
                return View(message);
            }
            return View(profile);
        }

       
        // GET: Profile/Delete/5
        public ActionResult Delete(int profileId)
        {
            try
            {
                var profile = _profileService.GetProfileById(profileId).FirstOrDefault();

                if (profile == null)
                {
                    return NotFound();
                }
                return View(profile);
            }
            catch (Exception ex)
            {

                string message = ex.Message;
                return View(message);

            }
        }

        // POST: Profile/Delete/5
        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteProfile(int profileId)
        {
            try
            {
                var result = _profileService.DeleteProfileDetails(profileId);

                if (result)
                {
                    TempData["SuccessMessage"] = "Profile Delete Successfuly";
                }
                else
                {
                    TempData["ErrorMessage"] = "Unable to deleteProfile ";
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }
    }
}