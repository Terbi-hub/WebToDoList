using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.FileProviders;
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

            DefaultFilesOptions op = new DefaultFilesOptions();
            op.DefaultFileNames.Clear();
            op.DefaultFileNames.Add("content.html");
            app.UseDefaultFiles(op);
            app.UseStaticFiles();
            app.Run(async (context) =>
            {

            });
        }

        
    }
}