using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PilotTask.Models
{
	public class Profiles
	{
        [Key]
        public int ProfileId { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("PhoneNumber")]
        public string PhoneNumber { get; set; }
        [Required]
        [DisplayName("Email")]
        public string EmailId { get; set; }
       
    }
}

