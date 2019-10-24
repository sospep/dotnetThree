using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
//using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting;

using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using dotnetThree.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
// email pw recovery 
using Microsoft.AspNetCore.Identity.UI.Services;
using WebPWrecover.Services;
// 
using dotnetThree.Models.AccountViewModels;
using dotnetThree.Models.ManageViewModels;


namespace dotnetThree
{
    public class Startup
    {
        
        /* 
        public Startup(IHostingEnvironment env)
        public Startup(IWebHostEnvironment env)
        {
         //Configuration = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();  
         emailSettings = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();            
        }
         
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    
        {            
       ConnectionString = Configuration["ConnectionStrings:connectionstring"]; // Get Connection String from Appsetting.json
        }
        */
        public IConfigurationRoot Configuration { get; set; }
        public IWebHostEnvironment _env;

        public Startup(IWebHostEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
            .SetBasePath( _env.ContentRootPath)
            // .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }
        
        /* 

        public Startup(IConfiguration configuration)
        {
            // Configuration = configuration;
            Configuration = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();

        }
        
        public IConfiguration Configuration { get; }
        */

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")));
            /* 
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            */

            // services.AddIdentity<ApplicationUser, IdentityRole>()
            services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
            // 
            services.AddMvc();
            // 
            services.AddControllersWithViews();

            // requires
            // using Microsoft.AspNetCore.Identity.UI.Services;
            // using WebPWrecover.Services;
            services.AddTransient<IEmailSender, EmailSender>();
            // 
            services.Configure<AuthMessageSenderOptions>(Configuration);
            // Add our Emails so it can be injected into controllers
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            // required ?
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // EmailSettings = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
            // var EmailSettings = Configuration["EmailSettings:SMTPSettings"]; 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                // EDIT - add TEMP
                // app.UseDeveloperExceptionPage();
                // app.UseDatabaseErrorPage();
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
