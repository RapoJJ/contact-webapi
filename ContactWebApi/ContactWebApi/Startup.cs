﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactWebApi.Models;
using ContactWebApi.Repositories;
using ContactWebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ContactWebApi
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
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactService, ContactService>();

            services.AddDbContext<ContactdbContext>(opt =>
                {
                    opt.UseSqlServer(Configuration.GetConnectionString("AzurePersonDBContext"));
                });

            // CORS Policy
            services.AddCors(options => options.AddPolicy("AllowAnyPolicy",
                builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAnyPolicy");

            app.UseMvc();
        }
    }
}
