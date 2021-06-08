using AkvelonTaskMilosBelic.Models;
using AkvelonTaskMilosBelic.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkvelonTaskMilosBelic.Interfaces
{
    public interface IProjectService
    {

        IEnumerable<ProjectDTO> GetByPriority(Filter filter);
        IEnumerable<ProjectDTO> GetAll(string sortType);
        ProjectDTO GetById(int id);
        void Create(ProjectRequest projectRequest);
        void Update(int id, ProjectRequest projectRequest);
        void Delete(int id);
        void AddTaskToProject(ProjectDTO projectDTO, ProjectTaskDTO projectTaskDTO);
        void DeleteTaskFromProject(ProjectDTO projectDTO, ProjectTaskDTO projectTaskDTO);

    }
}
