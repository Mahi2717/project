using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Airticket.Data;
using Microsoft.OpenApi.Models;
using Airticket.Service;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Airticket
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
            services.AddCors();
            services.AddControllers().AddJsonOptions(
                options =>
                {
                    { options.JsonSerializerOptions.PropertyNamingPolicy = null; };
                    { options.JsonSerializerOptions.DictionaryKeyPolicy = null; }
                }
                ); ;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "A API",
                    Version = "v1",
                    Description = ",,,,,",
                    Contact = new OpenApiContact
                    {
                        Name = "sam",
                        Email = string.Empty,
                        Url = new Uri("https://mahima2717angular.azurewebsites.net"),
                    },
                });
            });

            services.AddDbContext<TicketDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("TicketDbContext")));
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdminLoginService, AdminLoginService>();
            services.AddScoped<IAdminService, AdminService>();

            services.AddScoped<ITokenGeneration, TokenGeneration>();
            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwtOptions =>
            {
                var key = Configuration.GetValue<string>("JwtConfig:Key");
                var keyBytes = Encoding.UTF8.GetBytes(key);
                jwtOptions.SaveToken = true;
                jwtOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false
                };
            });
            services.AddSingleton<ITokenGeneration, TokenGeneration>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "A API v1");
            });
            app.UseHttpsRedirection();
            app.UseCors(options => options.WithOrigins("https://mahima2717angular.azurewebsites.net").AllowAnyMethod().AllowAnyHeader());
            

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
