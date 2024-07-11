using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PilotTask.Models
{
	public class Tasks
	{
        [Key]
        public int Id { get; set; }
        public int ProfileId { get; set; }
        [Required]
        [DisplayName("Task Name")]
        public string TaskName { get; set; }
        [Required]
        [DisplayName("Description")]
        public string TaskDescription { get; set; }
        [Required]
        [DisplayName("Start Time")]
        public DateTime StartTime { get; set; }
        [Required]
        public int Status { get; set; }
        
    }
}

