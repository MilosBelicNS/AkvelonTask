using AkvelonTaskMilosBelic.Interfaces;
using AkvelonTaskMilosBelic.Models;
using AkvelonTaskMilosBelic.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AkvelonTaskMilosBelic.Services
{
    public class ProjectTaskService :IProjectTaskService
    {

        public IProjectTaskRepository repository { get; set; }

        public ProjectTaskService(IProjectTaskRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<ProjectTaskDTO> GetAll()
        {
            return repository.GetAll().Select(x => new ProjectTaskDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Priority = x.Priority,
                Description = x.Description,
                TaskStatus = x.TaskStatus
            });

        }

        public IEnumerable<ProjectTaskDTO> GetTasksFromProject(ProjectDTO projectDTO)
        {
           
            var targetListTasks = projectDTO.ProjectTasksDTO
                             .Select(x => new ProjectTask() {
                                 Id = x.Id,
                                 Name = x.Name,
                                 Priority = x.Priority,
                                 Description = x.Description,
                                 TaskStatus = x.TaskStatus
                             }).ToList();

            var project = new Project()
            {

                Name = projectDTO.Name,
                Priority = projectDTO.Priority,
                StartDate = projectDTO.StartDate,
                EndDate = projectDTO.EndDate,
                Status = projectDTO.Status,
                ProjectTasks = targetListTasks
            };

            var result = repository.GetTasksFromProject(project);

            return result.Select(x => new ProjectTaskDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Priority = x.Priority,
                Description = x.Description,
                TaskStatus = x.TaskStatus
            });
        }

        public ProjectTaskDTO GetById(int id)
        {
            var projectTask = repository.GetById(id);

            return new ProjectTaskDTO()
            {
                Id = projectTask.Id,
                Name = projectTask.Name,
                Priority = projectTask.Priority,
                Description = projectTask.Description,
                TaskStatus = projectTask.TaskStatus
            };
        }

        public void Create(ProjectTaskRequest projectTaskRequest)
        {
            var projectTask = new ProjectTask()
            {

                Name = projectTaskRequest.Name,
                Priority = projectTaskRequest.Priority,
                Description = projectTaskRequest.Description,
                TaskStatus = projectTaskRequest.TaskStatus
            };

            repository.Create(projectTask);

            
        }


        public void Update(int id, ProjectTaskRequest projectTaskRequest)
        {

            var projectTask = new ProjectTask()
            {
                Id = id,
                Name = projectTaskRequest.Name,
                Priority = projectTaskRequest.Priority,
                Description = projectTaskRequest.Description,
                TaskStatus = projectTaskRequest.TaskStatus
            };
            repository.Update(projectTask);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}