using AkvelonTaskMilosBelic.Interfaces;
using AkvelonTaskMilosBelic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace AkvelonTaskMilosBelic.Repository
{
    public class ProjectRepository: IDisposable, IProjectRepository
    {
        private ModelsDbContext db = new ModelsDbContext();



        public IEnumerable<Project> GetAll(string sortType)
        {
           if(sortType.Equals("StartDateAscending"))
            {
                return db.Projects.Include(x => x.ProjectTasks).OrderBy(x => x.StartDate);
            }
            else if(sortType.Equals("StartDateDescending"))
            {
                return db.Projects.Include(x => x.ProjectTasks).OrderByDescending(x => x.StartDate);
            }
            else if (sortType.Equals("PriorityAscending"))
            {
                return db.Projects.Include(x => x.ProjectTasks).OrderBy(x => x.Priority);
            }
            else if (sortType.Equals("PriorityDescending"))
            {
                return db.Projects.Include(x => x.ProjectTasks).OrderByDescending(x => x.Priority);
            }
            return db.Projects.Include(x => x.ProjectTasks);
        }


       public IEnumerable<Project> GetByPriority(Filter filter)
        {
            return db.Projects.Include(x => x.ProjectTasks).Where(x => x.Priority >= filter.Min && x.Priority <= filter.Max);
        }

        public Project GetById(int id)
        {
           foreach(Project project in db.Projects)
            {
                if(project.Id == id)
                {
                    return project;
                }
            }
            throw new Exception("There is no project with this id:" + id);
        }


        public void Create(Project project)
        {
            db.Projects.Add(project);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            
                foreach (Project project in db.Projects)
                {
                    if (id == project.Id)
                    {
                        db.Projects.Remove(project);
                        db.SaveChanges();
                    }
                }
          


            
        }


        public void Update(Project project)
        {
           
                db.Entry(project).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch(DbUpdateConcurrencyException)
            {
                throw;
            }
           
            
            
        }


        public void AddTaskToProject(Project project, ProjectTask projectTask)
        {

            if (!project.ProjectTasks.Contains(projectTask))
            {
                project.ProjectTasks.Add(projectTask);
                db.SaveChanges();
            }
            else
                throw new Exception("The project already contains a task in its task list");
        }

        public void DeleteTaskFromProject(Project project, ProjectTask projectTask)
        {
            if (project.ProjectTasks.Contains(projectTask))
            {
                project.ProjectTasks.Remove(projectTask);
                db.SaveChanges();
            }
            else
                throw new Exception("The project doesnt contains this task in its task list");
            
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