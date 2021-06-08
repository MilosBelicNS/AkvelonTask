using AkvelonTaskMilosBelic.Interfaces;
using AkvelonTaskMilosBelic.Models;
using AkvelonTaskMilosBelic.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AkvelonTaskMilosBelic.Controllers
{
   
    public class ProjectsController : ApiController
    {

        public IProjectService service { get; set; }

        public ProjectsController(IProjectService service)
        {
            this.service = service;
        }


        [HttpGet()]
        public IEnumerable<ProjectDTO> GetAll([FromUri] string sortType)
        {
            return service.GetAll(sortType);
        }

        [HttpPost()]
        [Route("api/Priority")]
        public IEnumerable<ProjectDTO> GetByPriority([FromUri]Filter filter)
        {
            return service.GetByPriority(filter);
        }

        [HttpGet()]
        [Route("{id:int}")]
        [ResponseType(typeof(ProjectDTO))]
        public IHttpActionResult GetById(int id)
        {
            var project = service.GetById(id);

            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }


        [HttpPost()]
        [ResponseType(typeof(ProjectDTO))]
        public IHttpActionResult Post(ProjectRequest projectRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.Create(projectRequest);
            return Created("DefaultApi", projectRequest);
        }

        [HttpPut]
        [ResponseType(typeof(ProjectDTO))]
        public IHttpActionResult Put(int id, ProjectRequest projectRequest)
        {
            var project = service.GetById(id);

            if (project == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                service.Update(id, projectRequest);
            }
            catch
            {
                return Conflict();
            }
            return StatusCode(HttpStatusCode.NoContent);
        }


        [HttpDelete]
        [ResponseType(typeof(ProjectDTO))]
        public IHttpActionResult Delete(int id)
        {
            
                service.Delete(id);
           
               return StatusCode(HttpStatusCode.NoContent);

        }

        public IHttpActionResult AddTaskToProject(ProjectDTO projectDTO, ProjectTaskDTO projectTaskDTO)
        {
            try
            {
                service.AddTaskToProject(projectDTO, projectTaskDTO);
               
            }
            catch(Exception)
            {
                return BadRequest("The project already contains a task in its task list");
            }

            return Ok();

        }
        [HttpDelete]
        [Route("api/TaskFromProject")]
        public IHttpActionResult DeleteTaskFromProject([FromBody] ProjectDTO projectDTO, [FromBody] ProjectTaskDTO projectTaskDTO)
        {
            try
            {
                service.DeleteTaskFromProject(projectDTO, projectTaskDTO);

            }
            catch (Exception)
            {
                return BadRequest("The project doesnt contains this task in its task list");
            }

            return Ok();

        }
    }
}
