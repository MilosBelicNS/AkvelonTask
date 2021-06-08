using AkvelonTaskMilosBelic.Interfaces;
using AkvelonTaskMilosBelic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace AkvelonTaskMilosBelic.Repository
{
    public class ProjectTaskRepository : IDisposable, IProjectTaskRepository
    {

        private ModelsDbContext db = new ModelsDbContext();

       

        public IEnumerable<ProjectTask> GetAll()
        {
            return db.ProjectTasks;
        }

        public ProjectTask GetById(int id)
        {
            foreach (ProjectTask projectTask in db.ProjectTasks)
            {
                if (projectTask.Id == id)
                {
                    return projectTask;
                }
            }
            throw new Exception("There is no task with this id:" + id);
        }

        public IEnumerable<ProjectTask> GetTasksFromProject(Project project)
        {

            Project dbProject = db.Projects.Find(project);

            return dbProject.ProjectTasks.AsEnumerable();

        }

        


        public void Create(ProjectTask projectTask)
        {
            db.ProjectTasks.Add(projectTask);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
           foreach(ProjectTask projectTask in db.ProjectTasks)
            {
                if (id == projectTask.Id)
                {
                    db.ProjectTasks.Remove(projectTask);
                    db.SaveChanges();
                }
            }

           
            
        }


        public void Update(ProjectTask projectTask)
        {
            db.Entry(projectTask).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
             //we use entity framework and do not use transactions
             //in case we have a problem of concurrent execution, I think it would be good to use this exception
        }
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
    }
}