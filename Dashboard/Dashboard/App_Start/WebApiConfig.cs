using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using Dashboard.Models;

namespace Dashboard
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // ODATA
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Gutachter>("Gutachter");
            modelBuilder.EntitySet<Gutachten>("Gutachten");
            var edmModel = modelBuilder.GetEdmModel();

            config.Routes.MapODataRoute(
                routeName: "OData",
                routePrefix: "api",
                model: edmModel
            );

            // Enables query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            config.EnableQuerySupport();

            // new Web API attribute routes
            config.MapHttpAttributeRoutes();

            // "classic" routes
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // removes Xml Formater from WebApi for easy debugging
            //MediaTypeFormatterCollection formatters = GlobalConfiguration.Configuration.Formatters;
            //formatters.Remove(formatters.XmlFormatter);

            #if DEBUG
            // more readable output
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            #endif 

            // handle self referencing loops
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
    }
}
