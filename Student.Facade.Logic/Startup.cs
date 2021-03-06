﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudentCommon.Logic.Log;
using StudentDao.DataBaseContext;
using StudentDao.Repository;
using Microsoft.EntityFrameworkCore;
using Student.Business.Logic;
using System.Net.Http.Headers;

namespace Student.Facade.Logic
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
            services.AddDbContext<AlumnoContext>();

            services.AddTransient<StudentCommon.Logic.Log.ILogger, Log4netAdapter>();

            services.AddTransient<IRepository, RepositorySql >();

            services.AddTransient<IBusiness, StudentBL>();

            services.AddMvc(options =>
            {
                options.FormatterMappings.SetMediaTypeMappingForFormat
                ("xml", Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat
                ("json", Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json"));
            })
            .AddXmlSerializerFormatters();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
