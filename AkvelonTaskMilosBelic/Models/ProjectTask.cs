using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AkvelonTaskMilosBelic.Models
{

     public enum TaskStatus
    {
        ToDo ,
        InProgress ,
        Done 
    }


    public class ProjectTask
    {

        public int Id { get; set; }
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