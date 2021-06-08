using AkvelonTaskMilosBelic.Interfaces;
using AkvelonTaskMilosBelic.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AkvelonTaskMilosBelic.Controllers
{
   
    public class ProjectTasksController : ApiController
    {

        public IProjectTaskService service { get; set; }

        public ProjectTasksController(IProjectTaskService service)
        {
            this.service = service;
        }


        
        public IEnumerable<ProjectTaskDTO> GetAll()
        {
            return service.GetAll();
        }

        [Route("api/Projects/TasksFromProject")]
        public IEnumerable<ProjectTaskDTO> GetTasksFromProject(ProjectDTO projectDTO)
        {
            return service.GetTasksFromProject(projectDTO);
        }

       
        [ResponseType(typeof(ProjectTaskDTO))]
        public IHttpActionResult GetById(int id)
        {
            var projectTask = service.GetById(id);

            if (projectTask == null)
            {
                return NotFound();
            }
            return Ok(projectTask);
        }

        [HttpPost()]
        [ResponseType(typeof(ProjectTaskDTO))]
        public IHttpActionResult Post(ProjectTaskRequest projectTaskRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.Create(projectTaskRequest);
            return Created("DefaultApi", projectTaskRequest);
        }


        [HttpPut]
        [ResponseType(typeof(ProjectTaskDTO))]
        public IHttpActionResult Put(int id, ProjectTaskRequest projectTaskRequest)
        {
            var projectTask = service.GetById(id);

            if (projectTask == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                service.Update(id, projectTaskRequest);
            }
            catch
            {
                return Conflict();//I think that Conflict() will be the best status code if we have concurrency problem
            }


            return StatusCode(HttpStatusCode.NoContent);
        }



        [HttpDelete]
        [ResponseType(typeof(ProjectTaskDTO))]
        public IHttpActionResult Delete(int id)
        {
            
            service.Delete(id);
           
            
            return StatusCode(HttpStatusCode.NoContent);

        }

        



    }
}
