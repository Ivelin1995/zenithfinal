using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ZenithSociety2.Data;
using ZenithSociety2.Models;
using ZenithSociety2.Services;
using Microsoft.AspNetCore.Identity;

namespace ZenithSociety2
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<ZenithContext>();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            services.AddOpenIddict<ApplicationDbContext>()
        // Register the ASP.NET Core MVC binder used by OpenIddict.
        // Note: if you don't call this method, you won't be able to
        // bind OpenIdConnectRequest or OpenIdConnectResponse parameters.
        .AddMvcBinders()

        // Enable the token endpoint (required to use the password flow).
        .EnableAuthorizationEndpoint("/connect/authorize")
        .EnableTokenEndpoint("/connect/token")

        // Allow client applications to use the grant_type=password flow.
        .AllowAuthorizationCodeFlow()

        // During development, you can disable the HTTPS requirement.
        .DisableHttpsRequirement()

        // Register a new ephemeral key, that is discarded when the application
        // shuts down. Tokens signed using this key are automatically invalidated.
        // This method should only be used during development.
        .AddEphemeralSigningKey();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            ZenithContext db, ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            app.UseCors(builder =>
       builder.WithOrigins("http://localhost:4200"));

            app.UseStaticFiles();

            app.UseIdentity();

            app.UseOAuthValidation();

            app.UseOpenIddict();
            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //InitialData.Initialize(db);

            //createRolesandUsers(context, roleManager, userManager);


        }

        private async void createRolesandUsers(
    ApplicationDbContext context,
    RoleManager<IdentityRole> roleManager,
    UserManager<ApplicationUser> userManager)
        {
            // In Startup iam creating first Admin Role and creating a default Admin User   
            var adminExists = await roleManager.RoleExistsAsync("Admin");
            if (!adminExists)
            {
                // first we create Admin role
                var role = new IdentityRole();
                role.Name = "Admin";
                var roleResult = await roleManager.CreateAsync(role);

                // Here we create a Admin super user who will maintain the website                  
                var user = new ApplicationUser();
                user.UserName = "ZenithAdmin";
                user.Email = "admin@zenith.com";
                string userPWD = "!@#123QWEqwe";
                // Create an admin user for marking 
                var user2 = new ApplicationUser();
                user2.UserName = "a";
                user2.Email = "a@a.a";
                string user2PWD = "P@$$w0rd";

                //Add default User to Role Admin  
                var chkUser = await userManager.CreateAsync(user, userPWD);
                var chkUser2 = await userManager.CreateAsync(user2, user2PWD);
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRoleAsync(user, "Admin");
                    var result2 = userManager.AddToRoleAsync(user2, "Admin");
                }
            }

            // creating Creating Manager role    
            if (!await roleManager.RoleExistsAsync("Member"))
            {
                var role = new IdentityRole();
                role.Name = "Member";
                var roleResult = roleManager.CreateAsync(role);

                // Here we create a Admin super user who will maintain the website                  
                var user = new ApplicationUser();
                user.UserName = "m";
                user.Email = "m@m.c";
                string userPWD = "P@$$w0rd";

                var chkUser = await userManager.CreateAsync(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRoleAsync(user, "Member");
                }
            }
        }
    }

}
