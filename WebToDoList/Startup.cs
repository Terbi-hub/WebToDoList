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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TaskContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();
            services.AddTransient<TimeService>();
        }

        public void Configure(IApplicationBuilder app, TimeService time)
        {
            //DefaultFilesOptions op = new DefaultFilesOptions();
            //app.UseRouting();
            //op.DefaultFileNames.Clear();
            //op.DefaultFileNames.Add("Index.html");
            //app.UseDefaultFiles(op);
            //app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }  
    }
}

