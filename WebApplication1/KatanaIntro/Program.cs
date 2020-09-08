using Owin;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Http;

namespace KatanaIntro
{
    //using in HellpWorldComponent constructor

    using AppFunc = Func<IDictionary<string, object>, Task>;
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:8080";

            //using WebApp explicitly start a server providing the url
            using (WebApp.Start < Startup > (url))
            {
                Console.WriteLine("Started");
                Console.ReadKey();//Keep running until someone presses the key
                Console.WriteLine("Stopping.....");

            }
        }
    }
    public class Startup
    {
        
        public void Configuration(IAppBuilder app) //Using Owin
        {
            /*//app.UserWelcomePage();//Welcome page 
            app.Run(ctx =>
            {
                return ctx.Response.WriteAsync("Hello World!!");
                //For every request it will return Hello World
            });*/
            
            //middleware

            
            app.Use(async (environment, next) =>
            {

                Console.WriteLine("Requesting for" + environment.Request.Path);
                
                await next();
                //anything after next will come as response
                Console.WriteLine("Response :" + environment.Response.StatusCode);

            });

            ConfigureWebApi(app);

            app.Use<HelloWorldComponent>();
        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "DefaultApi ",
                "ap/{controller}/{id}", 
                new { id = RouteParameter.Optional });
            app.UseWebApi(config);
        }
    }
    public class HelloWorldComponent
    {
        AppFunc _next;
        public HelloWorldComponent(AppFunc next)
        {
            _next = next;
        }
        public Task Invoke(IDictionary<string,object> environment)
        {
            //await _next(environment);use of async
            var response = environment["Owin ResponseBody"] as Stream;
            using(var writer=new StreamWriter(response))
            {
                return writer.WriteAsync("Helloo....");
            }

        }

        //using extension

        /* in configuration UseHelloWorld can be used as UseHelloWorldPage()
         public static class AppBuilderExtension
        {
            public static void UseHelloWorld(this IAppBuilder app)
            {
                app.Use<HelloWorldComponent>();
            }
        }*/
    }
}
