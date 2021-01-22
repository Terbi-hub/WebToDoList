using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebToDoList
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            int x = 2;
            int y = 22;
            int z = 0;
            app.Use(async (rivnanna, next) =>
            {
                z = x * y;
                await next?.Invoke();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Result: {z}");
            });
        }
    }
}