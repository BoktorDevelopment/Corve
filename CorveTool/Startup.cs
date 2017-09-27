using CorveTool.DAL.Context;
using CorveTool.DAL.Models;
using CorveTool.DAL.Repositories;
using CorveTool.Slack;
using Hangfire;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using System;

[assembly: OwinStartup(typeof(CorveTool.Startup))]

namespace CorveTool
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                sharedOptions.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddAzureAd(options => Configuration.Bind("AzureAd", options))
            .AddCookie();

            services.AddDbContext<DatabaseContext>();

            DatabaseContext.ConnectionString = Configuration.GetConnectionString("DatabaseContext");
            services.AddDbContext<DatabaseContext>();

            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("DatabaseContext")));

            services.AddMvc();
            //services.AddSingleton<IRepository<ScheduleTask>>(new ScheduleTaskRepository(new DatabaseContext()));
            //services.AddSingleton<IRepository<Tasks>>(new TaskRepository(new DatabaseContext()));
            //services.AddSingleton<IRepository<CheckList>>(new CheckListRepository(new DatabaseContext()));
            //services.AddSingleton<IRepository<Users>>(new UsersRepository(new DatabaseContext()));
            //services.AddSingleton<IRepository<Schedules>>(new SchedulesRepository(new DatabaseContext()));
            services.AddScoped<IRepository<ScheduleTask>, ScheduleTaskRepository>();
            services.AddScoped<IRepository<Tasks>, TaskRepository>();
            services.AddScoped<IRepository<CheckList>, CheckListRepository>();
            services.AddScoped<IRepository<Users>, UsersRepository>();
            services.AddScoped<IRepository<Schedules>, SchedulesRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseHangfireDashboard();
            app.UseHangfireServer();

         
                SlackClientTest slackclient = new SlackClientTest();


            RecurringJob.AddOrUpdate(() => slackclient.Postmessage(), "0 9 * * *");

        }
    }
}
