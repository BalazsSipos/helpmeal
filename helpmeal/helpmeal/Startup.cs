﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodService.Services.BlobService;
using helpmeal.Models.Identity;
using helpmeal.Services.IngredientService;
using helpmeal.Services.MealService;
using helpmeal.Services.Profiles;
using helpmeal.Services.UnitService;
using helpmeal.Services.RecipeService;
using helpmeal.Services.User;
using helpmeal.Services.UserSettings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace helpmeal
{
    public class Startup
    {
        private IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IBlobStorageService, BlobStorageService>();
            services.AddTransient<IUnitService, UnitService>();
            services.AddTransient<IIngredientService, IngredientService>();
            services.AddIdentity<AppUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                services.AddDbContext<ApplicationDbContext>(build =>
                {
                    build.UseMySql(configuration.GetConnectionString("AzureConnection"));
                });
                // Automatically perform database migration
                services.BuildServiceProvider().GetService<ApplicationDbContext>().Database.Migrate();
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(build =>
                {
                    build.UseMySql(configuration.GetConnectionString("DefaultConnection"));
                });
            }
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserSettingsService, UserSettingsService>();
            services.AddTransient<IMealService, MealService>();
            services.AddTransient<IRecipeService, RecipeService>();

            services.SetUpAutoMapper();
            services.AddMvc();
            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = "878629613299-5h3qgsic9d4bi8vq1ctuki2146u7qhf0.apps.googleusercontent.com";
                    options.ClientSecret = "7_zykgr08DESNJqMmQc8j8PF";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext applicationDbContext)
        {
            ApplicationDbInitializer.SeedUnits(applicationDbContext);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}
