using AkvelonTaskMilosBelic.Interfaces;
using AkvelonTaskMilosBelic.Models;
using AkvelonTaskMilosBelic.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AkvelonTaskMilosBelic.Services
{
    public class ProjectService : IProjectService
    {

        public IProjectRepository repository { get; set; }

        public ProjectService(IProjectRepository repository)
        {
            this.repository = repository;
        }


        public IEnumerable<ProjectDTO> GetByPriority(Filter filter)
        {
            //nije zavrsena
            
            return repository.GetByPriority(filter).Select(x => new ProjectDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Priority = x.Priority,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Status = x.Status,
                ProjectTasksDTO = x.ProjectTasks.Select(h => new ProjectTaskDTO()
                {
                    Id = h.Id,
                    Name = h.Name,
                    Priority = h.Priority,
                    Description = h.Description,
                    TaskStatus = h.TaskStatus

                }).ToList()


            }); 
        }

        public IEnumerable<ProjectDTO> GetAll(string sortType)
        {
            return repository.GetAll(sortType).Select(x => new ProjectDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Priority = x.Priority,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Status = x.Status,
                ProjectTasksDTO = x.ProjectTasks.Select(h => new ProjectTaskDTO()
                {
                    Id = h.Id,
                    Name = h.Name,
                    Priority = h.Priority,
                    Description = h.Description,
                    TaskStatus = h.TaskStatus

                }).ToList()
            });

        }

        public ProjectDTO GetById(int id)
        {
            var project = repository.GetById(id);

            

            return new ProjectDTO()
            {
                Id = project.Id,
                Name = project.Name,
                Priority = project.Priority,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Status = project.Status,
                ProjectTasksDTO = project.ProjectTasks.Select(h => new ProjectTaskDTO()
                {
                    Id = h.Id,
                    Name = h.Name,
                    Priority = h.Priority,
                    Description = h.Description,
                    TaskStatus = h.TaskStatus

                }).ToList()

            };
        }


        public void Create(ProjectRequest projectRequest)
        {

            var project = new Project()
            {

                Name = projectRequest.Name,
                Priority = projectRequest.Priority,
                StartDate = projectRequest.StartDate,
                EndDate = projectRequest.EndDate,
                Status = projectRequest.Status,
                ProjectTasks = projectRequest.ProjectTasksDTO.Select(h => new ProjectTask()
                {
                    Id = h.Id,
                    Name = h.Name,
                    Priority = h.Priority,
                    Description = h.Description,
                    TaskStatus = h.TaskStatus

                }).ToList()
            };
            repository.Create(project);
        }

        public void Update(int id, ProjectRequest projectRequest)
        {
            
                
                    var project = new Project()
                    {
                        Id = id,
                        Name = projectRequest.Name,
                        Priority = projectRequest.Priority,
                        StartDate = projectRequest.StartDate,
                        EndDate = projectRequest.EndDate,
                        Status = projectRequest.Status,
                        ProjectTasks = projectRequest.ProjectTasksDTO.Select(h => new ProjectTask()
                        {
                            Id = h.Id,
                            Name = h.Name,
                            Priority = h.Priority,
                            Description = h.Description,
                            TaskStatus = h.TaskStatus

                        }).ToList()
                    };
                    repository.Update(project);
                

            
        }

        public void Delete(int id)
        {
            
                repository.Delete(id);
                
        }

       public void AddTaskToProject(ProjectDTO projectDTO, ProjectTaskDTO projectTaskDTO)
        {
            var projectTask = new ProjectTask()
            {
                Id = projectTaskDTO.Id,
                Name = projectTaskDTO.Name,
                Priority = projectTaskDTO.Priority,
                Description = projectTaskDTO.Description,
                TaskStatus = projectTaskDTO.TaskStatus
            };

            var project = new Project()
            {
                Id = projectDTO.Id,
                Name = projectDTO.Name,
                Priority = projectDTO.Priority,
                StartDate = projectDTO.StartDate,
                EndDate = projectDTO.EndDate,
                Status = projectDTO.Status,
                ProjectTasks = projectDTO.ProjectTasksDTO.Select(h => new ProjectTask()
                {
                    Id = h.Id,
                    Name = h.Name,
                    Priority = h.Priority,
                    Description = h.Description,
                    TaskStatus = h.TaskStatus

                }).ToList()
            };

            repository.AddTaskToProject(project, projectTask);
        }

        public void DeleteTaskFromProject(ProjectDTO projectDTO, ProjectTaskDTO projectTaskDTO)
        {
            var projectTask = new ProjectTask()
            {
                Id = projectTaskDTO.Id,
                Name = projectTaskDTO.Name,
                Priority = projectTaskDTO.Priority,
                Description = projectTaskDTO.Description,
                TaskStatus = projectTaskDTO.TaskStatus
            };

            var project = new Project()
            {
                Id = projectDTO.Id,
                Name = projectDTO.Name,
                Priority = projectDTO.Priority,
                StartDate = projectDTO.StartDate,
                EndDate = projectDTO.EndDate,
                Status = projectDTO.Status,
                ProjectTasks = projectDTO.ProjectTasksDTO.Select(h => new ProjectTask()
                {
                    Id = h.Id,
                    Name = h.Name,
                    Priority = h.Priority,
                    Description = h.Description,
                    TaskStatus = h.TaskStatus

                }).ToList()
            };

            repository.DeleteTaskFromProject(project, projectTask);
        }
    }
}