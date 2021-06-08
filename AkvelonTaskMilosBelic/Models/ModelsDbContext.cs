using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AkvelonTaskMilosBelic.Models
{
    public class ModelsDbContext : DbContext
    {

        public ModelsDbContext() : base("name=AkvelonTask")
        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }


    }
}