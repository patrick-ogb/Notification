using Microsoft.Extensions.DependencyInjection;
using Notification.Application.Interfaces;
using Notification.Infrastructure.Repository;

namespace Notification.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<INotificationTypeRepository, NotificationTypeRepository>();
            services.AddTransient<INotificationChannelRepository, NotificationChannelRepository> ();
            services.AddTransient<INotificationTemplateRepository, NotificationTemplateRepository > ();
            services.AddTransient< IEmailAlertRepository, EmailAlertRepository > ();
            services.AddTransient< ISMSAlertRepository, SMSAlertRepository > ();
            services.AddTransient< IActivityLogRepository, ActivityLogRepository > ();
        }
    }
}
