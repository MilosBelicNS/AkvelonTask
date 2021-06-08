using AkvelonTaskMilosBelic.Controllers;
using AkvelonTaskMilosBelic.Interfaces;
using AkvelonTaskMilosBelic.Models;
using AkvelonTaskMilosBelic.Models.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace AkvelonTaskMilosBelic.Tests.Controllers
{
    [TestClass]
    public class ProjectsControllerTest
    {
        [TestMethod]
        public void GetReturnsProjectWithSameId()
        {
            // Arrange
            var mockService = new Mock<IProjectService>();
            mockService.Setup(x => x.GetById(42)).Returns(new ProjectDTO { Id = 42 });

            var controller = new ProjectsController(mockService.Object);

            // Act
            IHttpActionResult actionResult = controller.GetById(42);
            var contentResult = actionResult as OkNegotiatedContentResult<ProjectDTO>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(42, contentResult.Content.Id);
        }

        [TestMethod]
        public void GetReturnsNotFound()
        {
            // Arrange
            var mockService = new Mock<IProjectService>();
            var controller = new ProjectsController(mockService.Object);

            // Act
            IHttpActionResult actionResult = controller.GetById(10);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        

        [TestMethod]
        public void PutReturnsBadRequest()
        {
            // Arrange
            var mockService = new Mock<IProjectService>();
            var controller = new ProjectsController(mockService.Object);

            // Act
            IHttpActionResult actionResult = controller.Put(10, new ProjectRequest {   Name = "Project2" });


            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void PostReturnsMultipleObjects()
        {
            // Arrange
            List<ProjectDTO> projectDTOs = new List<ProjectDTO>();
            projectDTOs.Add(new ProjectDTO { Id = 1, Name = "Project1", Priority = 12 });
            projectDTOs.Add(new ProjectDTO { Id = 2, Name = "Project2", Priority = 22 });

            var filter = new Filter() { Min = 10, Max = 150 };

            var mockService = new Mock<IProjectService>();
            mockService.Setup(x => x.GetByPriority(filter)).Returns(projectDTOs.AsEnumerable());
            var controller = new ProjectsController(mockService.Object);

            // Act
            IEnumerable<ProjectDTO> result = controller.GetByPriority(filter);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(projectDTOs.Count, result.ToList().Count);

        }

        

        

        [TestMethod]
        public void GetReturnsMultipleObjects()
        {
            // Arrange
            List<ProjectDTO> projectDTOs = new List<ProjectDTO>();
            projectDTOs.Add(new ProjectDTO { Id = 1, Name = "ProjectDTO1" });
            projectDTOs.Add(new ProjectDTO { Id = 2, Name = "ProjectDTO2" });

            var mockService = new Mock<IProjectService>();
            mockService.Setup(x => x.GetAll(null)).Returns(projectDTOs.AsEnumerable());
            var controller = new ProjectsController(mockService.Object);

            // Act
            IEnumerable<ProjectDTO> result = controller.GetAll(null);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(projectDTOs.Count, result.ToList().Count);
            Assert.AreEqual(projectDTOs.ElementAt(0), result.ElementAt(0));
            Assert.AreEqual(projectDTOs.ElementAt(1), result.ElementAt(1));
        }




    }
}
