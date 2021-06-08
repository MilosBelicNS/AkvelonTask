using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AkvelonTaskMilosBelic.Models.DTO
{
    public class ProjectTaskRequest
    {
        [Required]
        public int Priority { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public TaskStatus TaskStatus { get; set; }
    }
}