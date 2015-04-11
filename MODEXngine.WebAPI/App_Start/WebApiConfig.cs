using System.Net.Http.Formatting;
using System.Web.Http;

namespace MODEXngine.WebAPI {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            config.Formatters.Add(new BsonMediaTypeFormatter());

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}