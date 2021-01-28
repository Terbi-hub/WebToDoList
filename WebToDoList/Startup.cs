using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebToDoList.Servises;
using WebToDoList.DataTasks;

namespace WebToDoList
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<TaskContext>(options => options.UseSqlServer());
            services.AddTransient<TimeService>();
        }

        public void Configure(IApplicationBuilder app, TimeService time)
        {
            DefaultFilesOptions op = new DefaultFilesOptions();
            app.UseRouting();
            op.DefaultFileNames.Clear();
            op.DefaultFileNames.Add("content.html");
            app.UseDefaultFiles(op);
            app.UseStaticFiles();
            
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Текущее время: {time.GetTime()}");
            });
        }  
    }
}