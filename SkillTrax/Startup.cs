using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using SkillTrax.Models;
using Microsoft.EntityFrameworkCore;
using SkillTrax.Services;

namespace SkillTrax
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
                //Original
                //sharedOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                //sharedOptions.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;

                //From Fist Tutorial
                //sharedOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //sharedOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                //From https://github.com/Azure-Samples/active-directory-dotnet-webapp-webapi-openidconnect-aspnetcore/blob/master/TodoListService/Startup.cs
                sharedOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            //from first tutorial
            //.AddJwtBearer(options =>
            //{
            //    options.Authority = "https://login.microsoftonline.com/c4a2137e-4842-4ed8-ac8b-ec94ed409a4d"; /*tenantId*/
            //    options.Audience = "e66ed2d7-d1b7-4031-9d2d-b3772bb84b04"; /*client Id*/
            //    options.TokenValidationParameters.ValidateLifetime = true;
            //    options.TokenValidationParameters.ClockSkew = TimeSpan.Zero;
            //});

            .AddAzureAd(options => Configuration.Bind("AzureAd", options));
            //.AddCookie();

            services.AddMvc();

            //services.AddMvc(options =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //        .RequireAuthenticatedUser()
            //        .Build();
            //    options.Filters.Add(new AuthorizeFilter(policy));
            //})
            //.AddRazorPagesOptions(options =>
            //{
            //    options.Conventions.AllowAnonymousToFolder("/Account");
            //});

            services.AddAuthorization();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ISkillDataService, SkillDataService>();
            services.AddScoped<IEmployeeDataService, EmployeeDataService>();
            //services.AddScoped<ICertificationRepository, CertificationRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowCredentials()
            .AllowAnyHeader()
            );
  

            app.UseMvc();
        }
    }
}
