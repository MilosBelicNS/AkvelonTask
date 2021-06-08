using AkvelonTaskMilosBelic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AkvelonTaskMilosBelic.Interfaces
{
    public interface IProjectTaskRepository
    {
        IEnumerable<ProjectTask> GetAll();
        IEnumerable<ProjectTask> GetTasksFromProject(Project project);
        ProjectTask GetById(int id);
        void Create(ProjectTask projectTask);
        void Update(ProjectTask projectTask);
        void Delete(int id);
    }
}
