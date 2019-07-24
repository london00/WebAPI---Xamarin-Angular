using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System;
using System.Text;
using UdemyDotNetCoreAngular.Configuration;
using UdemyDotNetCoreAngular.DAL;
using UdemyDotNetCoreAngular.Domain;
using UdemyDotNetCoreAngular.Domain.Models;

namespace UdemyDotNetCoreAngular
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
            #region Configuration
            services.Configure<PhotoSetting>(Configuration.GetSection("PhotoSetting"));
            services.Configure<JWTSetting>(Configuration.GetSection("JWT"));
            #endregion

            #region Dependency Injection
            services.AddScoped<IVehicleDAL, VehicleDAL>();
            services.AddScoped<IMakeDAL, MakeDAL>();
            services.AddScoped<IVehicleDAL, VehicleDAL>();
            services.AddScoped<IFeatureDAL, FeatureDAL>();
            services.AddScoped<IPhotoDAL, DAL.PhotoDAL>();
            services.AddScoped<IContext, DAL.Context>();
            #endregion


#pragma warning disable CS0618 // Type or member is obsolete
            services.AddAutoMapper();
#pragma warning restore CS0618 // Type or member is obsolete

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            #region JWT

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var key = Configuration.GetSection("JWT")["Key"];
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
                //options.Authority = Configuration.GetSection("JWT")["Authority"];
                //options.Audience = Configuration.GetSection("JWT")["Audience"];

                options.SaveToken = false;
                options.RequireHttpsMetadata = false;
            });

            #endregion
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });

            #region Identity framework

            services.AddDbContext<VegaDBContext>(c => c.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddDefaultIdentity<User>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<VegaDBContext>();
            //.AddDefaultTokenProviders();

            #endregion

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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
