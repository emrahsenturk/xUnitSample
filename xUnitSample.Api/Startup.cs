using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using xUnitSample.Business.Abstract;
using xUnitSample.Business.Concrete;
using xUnitSample.DataAccess.Abstract;
using xUnitSample.DataAccess.Concrete;
using xUnitSample.DataAccess.Concrete.Context;

namespace xUnitSample.Api
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
            ConfigureDbContext(services);
            ConfigureDataAccessLayer(services);
            ConfigureBusinessLayer(services);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllers();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }

        void ConfigureDbContext(IServiceCollection services)
        {
            services.AddDbContext<xUnitSampleDbContext>(
                options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("ConnStr"));
                    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                });
        }

        private void ConfigureDataAccessLayer(IServiceCollection services)
        {
            services.AddScoped<IStudentDal, StudentDal>();
            services.AddScoped<ILessonDal, LessonDal>();
            services.AddScoped<IStudentLessonDal, StudentLessonDal>();
        }

        private void ConfigureBusinessLayer(IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<IStudentLessonService, StudentLessonService>();
        }
    }
}
