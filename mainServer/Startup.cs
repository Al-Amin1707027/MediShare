using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastAuth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Server;
using Server2;

namespace MediShare
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
            services.AddControllersWithViews();
            services.AddRazorPages();
            Password.Init(Configuration["AppSettings:HashPeeper"]);
            
            Database.Connect(Configuration["ConnectionStrings:DefaultConnection"]);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MediShare", Version = "v1" });
            });



            #region JWT
            services.AddSession(); // add session
            Keys.Configure(Configuration.GetSection("AppSettings"));
            var key = Encoding.ASCII.GetBytes(Keys.AuthSecret);  
            
            services.AddSession(options => {
                options.Cookie.Name = ".OpenCloud.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(60);
            });
            
            services.AddAuthentication(auth => {    
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;    
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;    
            }).AddJwtBearer(token => {    
                token.RequireHttpsMetadata = false;    
                token.SaveToken = true;    
                token.TokenValidationParameters = new TokenValidationParameters    
                {    
                    ValidateIssuerSigningKey = true,    
                    IssuerSigningKey = new SymmetricSecurityKey(key),    
                    ValidateIssuer = true,    
                    ValidIssuer = Keys.WebSiteDomain,    
                    ValidateAudience = true,    
                    ValidAudience = Keys.WebSiteDomain,    
                    RequireExpirationTime = true,    
                    ValidateLifetime = true,    
                    ClockSkew = TimeSpan.Zero    
                };
                token.Events = new JwtBearerEvents {
                    OnMessageReceived = context => {
                        context.Token = context.Request.Cookies["auth"];
                        return Task.CompletedTask;
                    }
                };
            }); 
            #endregion  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MediShare v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseStaticFiles();


            #region "JWT Token For Authentication Login"
            app.UseCookiePolicy();
            app.UseSession();
            /*app.Use(async (context, next) => {
                var JWToken = context.Session.GetString("JWToken");
                if (!string.IsNullOrEmpty(JWToken)) {
                    context.Request.Headers.Add("Authorization", "Bearer " + JWToken);    
                }
                await next();
            });*/
            app.UseAuthentication();
            app.UseAuthorization();
            #endregion 

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        
        }
    }
}
