using DataLayer;
using MusicServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();
            //config.EnableSystemDiagnosticsTracing();
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ArtistSearchApi",
                routeTemplate: "api/{controller}/{action}/{name}/{page_number}/{page_size}",
                defaults: new { page_number = RouteParameter.Optional, page_size = RouteParameter.Optional },
                constraints: new { action = "Search" }
            );

            config.Routes.MapHttpRoute(
                name: "ArtistAlbums",
                routeTemplate: "api/{controller}/{id}/{action}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { action = "albums" }
            );

            //config.Routes.MapHttpRoute(
            //    name: "ApiByAction",
            //    routeTemplate: "api/{controller}/{action}",
            //    defaults: new { action = "Get" },
            //    constraints: new { action = "Search" }
            //);
        }
    }
}
