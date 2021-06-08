using AkvelonTaskMilosBelic.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AkvelonTaskMilosBelic.Models
{
    public class ProjectRequest
    {
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


        public List<ProjectTaskDTO> ProjectTasksDTO { get; set; }
    }
}