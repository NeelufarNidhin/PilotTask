using System;
using PilotTask.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace PilotTask.DAL
{
	public class ProfileDAL : IProfileDAL
	{
        private readonly string _connString;
       
		public ProfileDAL(IConfiguration configuration)
		{
            _connString = configuration.GetConnectionString("DefaultConnection");
		}

        

        public List<Profiles> GetAllProfiles()
        {
            var profileList = new List<Profiles>();
            try
            {


                using (SqlConnection connection = new SqlConnection(_connString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_GetAllProfiles";
                    SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                    DataTable dtProfiles = new DataTable();
                    connection.Open();
                    sqlDA.Fill(dtProfiles);
                    connection.Close();

                    foreach (DataRow data in dtProfiles.Rows)
                    {
                        profileList.Add(new Profiles
                        {
                            ProfileId = Convert.ToInt32(data["ProfileId"]),
                            FirstName = data["FirstName"].ToString(),
                            LastName = data["LastName"].ToString(),
                            DateOfBirth = Convert.ToDateTime(data["DateOfBirth"]),
                            PhoneNumber = data["PhoneNumber"].ToString(),
                            EmailId = data["EmailId"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return profileList;
        }

        public List<Profiles> GetProfileById(int ProfileId)
        {
            var profileList = new List<Profiles>();
            try
            {


                using (SqlConnection connection = new SqlConnection(_connString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_GetProfileById";
                    command.Parameters.AddWithValue("@ProfileId", ProfileId);
                    SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                    DataTable dtProfiles = new DataTable();
                    connection.Open();
                    sqlDA.Fill(dtProfiles);
                    connection.Close();

                    foreach (DataRow data in dtProfiles.Rows)
                    {
                        profileList.Add(new Profiles
                        {
                            ProfileId = Convert.ToInt32(data["ProfileId"]),
                            FirstName = data["FirstName"].ToString(),
                            LastName = data["LastName"].ToString(),
                            DateOfBirth = Convert.ToDateTime(data["DateOfBirth"]),
                            PhoneNumber = data["PhoneNumber"].ToString(),
                            EmailId = data["EmailId"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return profileList;
        }

        public bool InsertProfile(Profiles profile)
        {
            int id = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connString))
                {
                    SqlCommand command = new SqlCommand("sp_InsertProfiles", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FirstName", profile.FirstName);
                    command.Parameters.AddWithValue("@LastName", profile.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", profile.DateOfBirth);
                    command.Parameters.AddWithValue("@PhoneNumber", profile.PhoneNumber);
                    command.Parameters.AddWithValue("@EmailId", profile.EmailId);

                    connection.Open();
                    id = command.ExecuteNonQuery();
                    connection.Close();



                }

                
            }
            catch(Exception ex)
            {
                string message = ex.Message;
            }
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateProfile(Profiles profile)
        {
            int i = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connString))
                {
                    SqlCommand command = new SqlCommand("sp_UpdateProfiles", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProfileId", profile.ProfileId);
                    command.Parameters.AddWithValue("@FirstName", profile.FirstName);
                    command.Parameters.AddWithValue("@LastName", profile.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", profile.DateOfBirth);
                    command.Parameters.AddWithValue("@PhoneNumber", profile.PhoneNumber);
                    command.Parameters.AddWithValue("@EmailId", profile.EmailId);

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

       public bool DeleteProfile(int profileId)
        {
            int i = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connString))
                {
                    SqlCommand command = new SqlCommand("sp_DeleteProfile", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProfileId", profileId);

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
    }
}

