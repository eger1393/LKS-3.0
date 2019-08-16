using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System;
using System.Threading.Tasks;
using LKS.Data;
using LKS.Data.Implementation;
using LKS.Data.Providers;
using LKS.Data.Repositories;
using LKS.Infrastructure.Authenticate;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace LKS.Web.SPA
{
	public class Startup
    {
		private const string JwtKey = "bRhYJRlZvBj2vW4MrV5HVdPgIE6VMtCFB0kTtJ1m";

		public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			// ������� ������������������ �������� ������ ��� �������� �������
			services.AddMvc()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
				.AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
			services.AddDbContext<DataContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

			services.AddDistributedMemoryCache();
			services.AddSession();

			RegistrationInterfaces(services);
			ConfigureAuthentication(services);

		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsProduction())
            {
				app.UseHsts();
			}
			
			app.UseSession();
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
			app.UseAuthentication();

			app.UseMvc().UseWhen(context => true, builder =>
			{
				builder.UseSpa(spa =>
				{
					spa.Options.SourcePath = "ClientApp";

					if (env.IsDevelopment())
					{
						spa.UseReactDevelopmentServer(npmScript: "start");
					}
				});
			});

			//app.UseMvc(routes =>
			//{
			//    routes.MapRoute(
			//        name: "default",
			//        template: "{controller}/{action=Index}/{id?}");
			//});

			//app.UseSpa(spa =>
			//{
			//    spa.Options.SourcePath = "ClientApp";

			//    if (env.IsDevelopment())
			//    {
			//        spa.UseReactDevelopmentServer(npmScript: "start");
			//    }
			//});
		}

		private void RegistrationInterfaces(IServiceCollection services)
		{
			services.AddTransient<IStudentRepository, StudentRepository>();
			services.AddTransient<IRelativeRepository, RelativeRepository>();
			services.AddTransient<ITroopRepository, TroopRepository>();
			services.AddTransient<IPrepodRepository, PrepodRepository>();
			services.AddTransient<ICycleRepository, CycleRepository>();
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IPasswordProvider, PasswordProvider>();
		}

		private void ConfigureAuthentication(IServiceCollection services)
		{
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.ClaimsIssuer = "LKS-server";
					options.SaveToken = true;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidIssuer = "LKS-server",
						ValidateAudience = false, //TODO
						ValidAudience = "LKS-client",
						ValidateLifetime = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtKey)),
						ValidateIssuerSigningKey = true,
						ClockSkew = TimeSpan.Zero
					};
					options.Events = new JwtBearerEvents
					{
						OnAuthenticationFailed = context =>
						{
							if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
							{
								context.Response.Headers.Add("Token-Expired", "true");
							}
							return Task.CompletedTask;
						}
					};
				});

			services.AddSingleton<IJwtAuth>(new JwtAuth(JwtKey, 2592000, "LKS-server", "LKS-client"));
		}
	}
}
