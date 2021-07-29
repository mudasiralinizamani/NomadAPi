using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NomadDashboardAPI.Contexts;
using NomadDashboardAPI.Interfaces;
using NomadDashboardAPI.Models;
using NomadDashboardAPI.Services;
using System;
using System.Text;

namespace NomadDashboardAPI
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
            // Injecting AppSettings
            services.Configure<AppSettings>(Configuration.GetSection("ApplcationSettings"));

            // Dependency Injection
            services.AddScoped<ILead, ILeadService>();
            services.AddScoped<INotifications, INotificationsService>();
            services.AddScoped<IProject, IProjectService>();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NomadDashboardAPI", Version = "v1" });
            });

            // Adding UserDb Context
            services.AddDbContext<UserContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddDbContext<APIContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddIdentityCore<User>().AddRoles<IdentityRole>().AddEntityFrameworkStores<UserContext>();

            services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            }
            );

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // JWT Authentication Configration - Mudasir Ali

            var Key = Encoding.UTF8.GetBytes(Configuration["ApplcationSettings:JET_SECRECT_KEY"].ToString());

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,
                };
            });

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NomadDashboardAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(m => m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}