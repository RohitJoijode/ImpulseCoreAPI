using FluentAssertions.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImpulseCoreAPI.BAL;
//using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Swashbuckle.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ImpulseCoreAPI
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
            services.AddMvc();
            services.AddControllers();
            services.AddDbContext<DbEngine>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("BloggingDatabase")));

            #region Below Line Mension that and Port Acceptable For (Angular 11 Core)
            services.AddCors(cors => cors.AddPolicy("MyPolicy",builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));
            #endregion

            services.AddScoped<ImpulseCoreAPI.BAL.IRepository.IHome,ImpulseCoreAPI.BAL.Repository.HomeRepository>();
            services.AddScoped<ImpulseCoreAPI.BAL.IRepository.IAdventureWorks,ImpulseCoreAPI.BAL.Repository.AdventureWorksRepo>();
            services.AddScoped<ImpulseCoreAPI.BAL.IRepository.IMenuRepo, ImpulseCoreAPI.BAL.Repository.MenuRepo>();
            services.AddScoped<ImpulseCoreAPI.BAL.IRepository.IRsaHelperRepo,ImpulseCoreAPI.BAL.Repository.RSAHelperRepo>();
            //services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //services.AddSwaggerGen();
            //MVC
            //services.AddControllersWithViews(options =>
            //{
            //}).AddNewtonsoftJson();

            //services.PostConfigure<MvcNewtonsoftJsonOptions>(options => {
            //    options.SerializerSettings.ContractResolver = new MyCustomContractResolver()
            //    {
            //        NamingStrategy = new CamelCaseNamingStrategy()
            //    };
            //    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //});
            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1",new Info { title = "My API", version = "v1" });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x => {
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = "",
                    ValidAudience = "",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWTConfig:key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            #region Below Line called For (Angular 11 Core)
            app.UseCors("MyPolicy");
            #endregion

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //// This middleware serves generated Swagger document as a JSON endpoint
            app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json","Employee API V1");
            //    c.RoutePrefix = string.Empty;
            //});
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

        }
        //public void SwaggerDoc()
        //{
        //    //Services.AddSwaggerGen(c =>
        //    //{
        //    //    c.SwaggerDoc("v1", new OpenApiInfo
        //    //    {
        //    //        Version = "v1",
        //    //        Title = "Employee API",
        //    //        Description = "Employee Management API",
        //    //        TermsOfService = new Uri("https://pragimtech.com"),
        //    //        Contact = new OpenApiContact
        //    //        {
        //    //            Name = "Venkat",
        //    //            Email = "kudvenkat@gmail.com",
        //    //            Url = new Uri("https://twitter.com/kudvenkat"),
        //    //        },
        //    //        License = new OpenApiLicense
        //    //        {
        //    //            Name = "PragimTech Open License",
        //    //            Url = new Uri("https://pragimtech.com"),
        //    //        }
        //    //    });
        //    //});
        //}
    }
}
