using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using xUnitSample.Business.Abstract;
using xUnitSample.Business.Concrete;
using xUnitSample.DataAccess.Abstract;
using xUnitSample.DataAccess.Concrete;

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
            ConfigureDataAccessLayer(services);
            ConfigureBusinessLayer(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseMvc();
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
