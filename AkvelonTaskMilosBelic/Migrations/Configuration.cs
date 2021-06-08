namespace AkvelonTaskMilosBelic.Migrations
{
    using AkvelonTaskMilosBelic.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AkvelonTaskMilosBelic.Models.ModelsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AkvelonTaskMilosBelic.Models.ModelsDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            context.ProjectTasks.AddOrUpdate(
                new ProjectTask() { Name = "Menu", Priority = 2, Description = "Side menu component", TaskStatus = TaskStatus.ToDo },
                new ProjectTask() { Name = "NavBar", Priority = 3, Description = "Top navbar", TaskStatus = TaskStatus.InProgress },
                new ProjectTask() { Name = "EditModal", Priority = 1, Description = "Edit form", TaskStatus = TaskStatus.Done},
                new ProjectTask() { Name = "CreateModal", Priority = 1, Description = "Create form", TaskStatus = TaskStatus.Done},
                new ProjectTask() { Name = "LoginModal", Priority = 2, Description = "Login form", TaskStatus = TaskStatus.InProgress},
                new ProjectTask() { Name = "ChangePass", Priority = 4, Description = "Reset password form", TaskStatus =  TaskStatus.ToDo}
                );

            context.SaveChanges();

            context.Projects.AddOrUpdate(
                new Project() { Name = "DWG", Priority = 1, StartDate = new DateTime(2020, 01, 15).Date, EndDate = new DateTime(2021, 07, 10).Date, Status = Status.Active, ProjectTasks = null },
                new Project() { Name = "BBC", Priority = 2, StartDate = new DateTime(2020, 11, 10).Date, EndDate = new DateTime(2021, 03, 28).Date, Status = Status.Completed, ProjectTasks = null });
        }
    }
}
