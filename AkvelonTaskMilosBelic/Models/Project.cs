using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AkvelonTaskMilosBelic.Models
{

    public enum Status
    {
        NotStarted, 
        Active,
        Completed
    }
    public class Project
    {

        public int Id { get; set; }
        [Required]
        public int Priority { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        public Status Status { get; set; }

        
        public List<ProjectTask> ProjectTasks { get; set; }

    }
}




