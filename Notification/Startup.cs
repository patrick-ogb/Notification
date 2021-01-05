using AutoMapper;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Notification.Data;
using Notification.Infrastructure;
using Notification.Services.Concrates;
using Notification.Services.Contracts;
using Notification.Services.MappingProfile;
using Radzen;
using System.Net.Http;

namespace Notification
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddInfrastructure();
            services.AddScoped<NotificationService>();
            services.AddScoped<DialogService>();
            services.AddScoped<TooltipService>();
            services.AddScoped<ContextMenuService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<ISessionStorageService, SessionStorageService>();
            services.AddSingleton<WeatherForecastService>();

            services.AddScoped<INotificationTypeService, NotificationTypeService>();
            services.AddScoped<INotificationChannelService,  NotificationChannelService> ();
            services.AddScoped< INotificationTemplateService, NotificationTemplateService > ();
            services.AddScoped< IEmailAlertService, EmailAlertService > ();
            services.AddScoped < ISMSAlertService , SMSAlertService > ();
            services.AddScoped < IActivityLogService, ActivityLogService > ();

            services.AddAutoMapper(typeof(NotificationTypesMappingProfile));
            services.AddAutoMapper(typeof(NotificationChannelMappingProfile));
            services.AddAutoMapper(typeof(NotificationTemplateMappingProfile));
            services.AddAutoMapper(typeof(EmailAlertMappingProfile));
            services.AddAutoMapper(typeof(SMSAlertMappingProfile));
            services.AddAutoMapper(typeof(ActivityLogMappingProfile));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
