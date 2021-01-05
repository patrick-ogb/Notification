using Notification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Services.Contracts
{
   public interface INotificationTemplateService
    {
        Task<int> CreateAsync(NotificationTemplateCrtVM notificationTemplateCrtVM);
        Task<int> UpdateAsync(NotificationTemplateCrtVM notificationTemplateCrtVM);
        Task<List<NotificationTemplateVM>> FetchAllAsync();
        Task<NotificationTemplateCrtVM> FetchByIdAsync(int Id);
        Task<int> DeleteAsync(int Id);
    }
}
