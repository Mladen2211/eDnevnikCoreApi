using eDnevnik.Interface;
using eDnevnik.Services;
using eDnevnikApi.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnikApi
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
            //services.AddRazorPages();


            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });


            services.AddSwaggerGen();

            services.AddDbContext<eDnevnikContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DB")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddAutoMapper(typeof(eDnevnikContext));

            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "http://10.15.1.9:8080",
                    ValidAudience = "http://10.15.1.9:8080",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eDnevnikSecretKey@2021"))
                };
            });

            services.AddScoped<IAcademicDiscipline, AcademicDisciplineService>();
            services.AddScoped<IAppointment,AppointmentService>();
            services.AddScoped<ICity,CityService>();
            services.AddScoped<IClass,ClassService>();
            services.AddScoped<IClassSubject,ClassSubjectService>();
            services.AddScoped<ICounty,CountyService>();
            services.AddScoped<IMunicipality,MunicipalityService>();
            services.AddScoped<IPermission,PermissionService>();
            services.AddScoped<IRole,RoleService>();
            services.AddScoped<IRolePermission,RolePermissionService>();
            services.AddScoped<ISchedule,ScheduleService>();
            services.AddScoped<ISchool,SchoolService>();
            services.AddScoped<ISubject,SubjectService>();
            services.AddScoped<IUser,UserService>();
            services.AddScoped<IUserRole,UserRoleService>();
            services.AddScoped<IUserSchool,UserSchoolService>();


            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //}

            app.UseAuthentication();
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value) &&
                !context.Request.Path.Value.StartsWith("/api/"))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            }
                );
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseCors("EnableCORS");


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
    
}
