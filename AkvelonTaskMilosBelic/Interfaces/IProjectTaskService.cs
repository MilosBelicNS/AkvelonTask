using AkvelonTaskMilosBelic.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkvelonTaskMilosBelic.Interfaces
{
   public interface IProjectTaskService
    {

        IEnumerable<ProjectTaskDTO> GetAll();
        IEnumerable<ProjectTaskDTO> GetTasksFromProject(ProjectDTO projectDTO);
        ProjectTaskDTO GetById(int id);
        void Create(ProjectTaskRequest projectTaskRequest);
        void Update(int id, ProjectTaskRequest projectTaskRequest);
        void Delete(int id);
    }
}
