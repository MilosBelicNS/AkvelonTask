using AkvelonTaskMilosBelic.Interfaces;
using AkvelonTaskMilosBelic.Repository;
using AkvelonTaskMilosBelic.Services;
using Microsoft.Practices.Unity;
using ProductService.Resolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AkvelonTaskMilosBelic
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            //UnityDependency IOC
            var container = new UnityContainer();


            //injecting repository in service
            container.RegisterType<IProjectRepository, ProjectRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IProjectTaskRepository, ProjectTaskRepository>(new HierarchicalLifetimeManager());

            //injecting service in controller
            container.RegisterType<IProjectTaskService, ProjectTaskService>(new HierarchicalLifetimeManager());
            container.RegisterType<IProjectService, ProjectService>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
