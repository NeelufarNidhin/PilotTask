using System;
using PilotTask.Models;

namespace PilotTask.DAL
{
	public interface IProfileDAL
	{
        List<Profiles> GetAllProfiles();
        bool InsertProfile(Profiles profile);
        List<Profiles> GetProfileById(int ProfileId);
        bool UpdateProfile(Profiles profile);
        bool DeleteProfile(int profileId);
    }
}

