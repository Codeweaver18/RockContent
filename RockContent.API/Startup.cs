using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RockContent.Core.Interfaces;
using RockContent.Core.Services;
using RockContent.DataAccessLayer.DbContexts;
using RockContent.DataAccessLayer.Entities;
using RockContent.DataAccessLayer.Interfaces;
using RockContent.DataAccessLayer.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockContent.API
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
            //configuring dbcontext
            var cxn = Configuration["DbconnectionString"].ToString();

            services.AddDbContext<RockContentDbContext>(options =>options.UseSqlServer(cxn));

            services.AddTransient<IPostLikesRepository, PostLikesRepository<PostLikes>>();
            services.AddTransient<ILikePostServiceAsync, LikePostServiceAsync>();
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V1", new OpenApiInfo
                {
                    Title = "Rocket Content  Test API's",
                    Version = "V1",
                    Description = "Rocket Content Like Button Test API",
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/V1/swagger.json", "Rocket Content  Test API's"));
        }
    }
}
