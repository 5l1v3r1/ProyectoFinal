
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProyectoFinal.CORE;
using ProyectoFinal.DAL;
using ProyectoFinal.IFR.Email;
using ProyectoFinal.CORE.Contracts;
using ProyectoFinal.Application;
using Microsoft.AspNetCore.Http.Features;
using ProyectoFinal.CORE.Contracts.VirusTotal;
using ProyectoFinal.Application.VirusTotal;
using ProyectoFinal.CORE.Contracts.Cuckoo;
using ProyectoFinal.Application.Cuckoo;
using ProyectoFinal.CORE.Contracts.ThreatCrowd;
using ProyectoFinal.Application.ThreatCrowd;
using Microsoft.Extensions.Logging;
using log4net.Repository.Hierarchy;
using ILoggerFactory = Microsoft.Extensions.Logging.ILoggerFactory;

namespace ProyectoFinal.Web
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"))
             
                    );

            //services.AddDbContextPool<ApplicationDbContext>(options => 
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddIdentity<ApplicationUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            //.AddEntityFrameworkStores<ApplicationDbContext>()

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc();

            
            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue; // In case of multipart
            });

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //inyeccion de dependencias de controladores etc.
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddSingleton<IEmailConfiguration>(Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IRoleManager, RoleManager>();
            services.AddScoped<IMalwareManager, MalwareManager>();
            services.AddScoped<IVirusTotalManager, VirusTotalManager>();
            services.AddScoped<IVirusTotalScanManager, VirusTotalScanManager>();
            services.AddScoped<ICuckooInfoManager, CuckooInfoManager>();
            services.AddScoped<ICuckooTargetManager, CuckooTargetManager>();
            services.AddScoped<ITargetPidsManager, TargetPidsManager>();
            services.AddScoped<ITargetUrlsManager, TargetUrlsManager>();
            services.AddScoped<ICuckooDroppedManager, CuckooDroppedManager>();
            services.AddScoped<IDroppedPidsManager, DroppedPidsManager>();
            services.AddScoped<IDroppedUrlsManager, DroppedUrlsManager>();
            services.AddScoped<ICuckooStaticManager, CuckooStaticManager>();
            services.AddScoped<IPeExportsManager, PeExportsManager>();
            services.AddScoped<IPeImportsManager, PeImportsManager>();
            services.AddScoped<IPeResourcesManager, PeResourcesManager>();
            services.AddScoped<IPeSectionsManager, PeSectionsManager>();
            services.AddScoped<IStaticSignaturesManager, StaticSignaturesManager>();
            services.AddScoped<IStaticKeysManager, StaticKeysManager>();
            services.AddScoped<ICuckooBehaviorManager, CuckooBehaviorManager>();
            services.AddScoped<ICuckooSigantureManager, CuckooSignatureManager>();
            services.AddScoped<IProcessTreeManager, ProcessTreeManager>();
            services.AddScoped<IBehaviorSummaryManager, BehaviorSummaryManager>();
            services.AddScoped<IImportsManager, ImportsManager>();
            services.AddScoped<IExportsManager, ExportsManager>();
            services.AddScoped<IProcessTreeManager, ProcessTreeManager>();
            services.AddScoped<IScreenShotManager, ScreenShotManager>();
            services.AddScoped<ITCDomainsManager, TCDomainsManager>();
            services.AddScoped<ITCEmailsManager, TCEmailsManager>();
            services.AddScoped<ITCHashesManager, TCHashesManager>();
            services.AddScoped<ITCIpsManager, TCIpsManager>();
            services.AddScoped<ITCReferencesManager, TCReferencesManager>();
            services.AddScoped<ITCScansManager, TCScansManager>();
            services.AddScoped<ITCSubdomainsManager, TCSubdomainsManager>();
            services.AddScoped<IThreatCrowdInfoManager, ThreatCrowdInfoManager>();
            services.AddScoped<ITCResolutionManager, TCResolutionManager>();
            services.AddScoped<ICommentManager, CommentManager>();
            services.AddScoped<ICuckooStringsManager, CuckooStringsManager>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
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

                endpoints.MapAreaControllerRoute(
                 name: "Admin",
                 areaName: "Admin",
                 pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

               
                endpoints.MapRazorPages();
            });
        }
    }
}
