using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TuduManayer.Domain.Todo;
using TuduManayer.Domain.Todo.Create;
using TuduManayer.Domain.Todo.Delete;
using TuduManayer.Domain.Todo.FindById;
using TuduManayer.Domain.Todo.Search;
using TuduManayer.Domain.Todo.Update;
using TuduManayer.Domain.Todo.Validation;
using TuduManayer.Repository.Postgres.EntityFramework;
using TuduManayer.Repository.Postgres.EntityFramework.Todo;
using TuduManayer.Repository.Postgres.EntityFramework.Todo.Delete;
using TuduManayer.Repository.Postgres.EntityFramework.Todo.Save;
using TuduManayer.Repository.Postgres.EntityFramework.Todo.Search;
using TuduManayer.Repository.Postgres.EntityFramework.Todo.Update;

namespace TuduManayer.web.react
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
            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });

            services.AddTransient<Configuration>();
            services.AddTransient<DataBaseContextFactory>();
            services.AddTransient<Validator>();
            services.AddTransient<IExistTodoRepository, ExistTodoRepository>();
            services.AddTransient<ISearchTodoService, SearchTodoService>();
            services.AddTransient<ISearchTodoRepository, SearchTodoRepository>();
            services.AddTransient<IDeleteTodoService, DeleteTodoService>();
            services.AddTransient<IDeleteTodoRepository, DeleteTodoRepository>();
            services.AddTransient<ICreateTodoService, CreateTodoService>();
            services.AddTransient<ISaveTodoRepository, SaveTodoRepository>();
            services.AddTransient<IUpdateTodoService, UpdateTodoService>();
            services.AddTransient<IFindByTodoIdService, FindByTodoIdService>();
            services.AddTransient<IFindTodoRepository, FindTodoRepository>();
            services.AddTransient<IUpdateTodoRepository, UpdateTodoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}