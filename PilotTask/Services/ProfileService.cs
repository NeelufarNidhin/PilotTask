using System;
using PilotTask.DAL;
using PilotTask.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PilotTask.Services
{
	public class ProfileService : IProfileService
	{
        private readonly IProfileDAL _profileDAL;
		public ProfileService(IProfileDAL profileDAL)
		{
            _profileDAL = profileDAL;
		}

        public bool CreateProfileDetails(Profiles profile)
        {
            bool IsInserted = false;

            try
            {
                IsInserted = _profileDAL.InsertProfile(profile);

               
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

             return IsInserted;
        }

        public bool DeleteProfileDetails(int profileId)
        {
            bool isDeleted = false;
            try
            {
                isDeleted = _profileDAL.DeleteProfile(profileId);


            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return isDeleted;


        }

        public List<Profiles> GetAllProfileDetails()
        {
            List<Profiles> profiles = _profileDAL.GetAllProfiles();
           
            return profiles;
        }

        public List<Profiles> GetProfileById(int profileId)
        {
           return _profileDAL.GetProfileById(profileId);
           
        }

        public bool UpdateProfileDetails(Profiles profile)
        {
            bool IsUpdated = false;

            try
            {
                IsUpdated = _profileDAL.UpdateProfile(profile);


            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return IsUpdated;
        }
    }
}

