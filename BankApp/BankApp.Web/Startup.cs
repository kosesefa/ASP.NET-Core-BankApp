using BankApp.Web.Data.Context;
using BankApp.Web.Data.Ýnterfaces;
using BankApp.Web.Data.Reporsitories;
using BankApp.Web.Data.UnitOfWork;
using BankApp.Web.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BankContext>(opt =>
            {
                opt.UseSqlServer("server=SEFAK;database=BankDb;integrated security=true;");
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserMapper, UserMapper>();           
            services.AddControllersWithViews();
            services.AddScoped<IAccountMapper, AccountMapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();//wwwroot klasörünü dýþarý açýyor.

            app.UseStaticFiles(new StaticFileOptions //node_modules'ü dýþarý açýyor.
            {
                FileProvider = new PhysicalFileProvider
                    (Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
                RequestPath = "/node_modules"

            });
 
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
