using System;
using PilotTask.Models;

namespace PilotTask.Services

{
	public interface IProfileService
	{
        List<Profiles> GetAllProfileDetails();
        bool CreateProfileDetails(Profiles profile);
        List<Profiles> GetProfileById(int profileId);
        bool UpdateProfileDetails(Profiles profile);
        bool DeleteProfileDetails(int profileId);
    }
}

