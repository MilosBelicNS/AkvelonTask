using AkvelonTaskMilosBelic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkvelonTaskMilosBelic.Interfaces
{
   public interface IProjectRepository
    {

        
        IEnumerable<Project> GetByPriority(Filter filter);
        IEnumerable<Project> GetAll(string sortType);
        Project GetById(int id);
        void Create(Project project);
        void Update(Project project);
        void Delete(int id);
        void AddTaskToProject(Project project, ProjectTask projectTask);
        void DeleteTaskFromProject(Project project, ProjectTask projectTask);
    }
}
