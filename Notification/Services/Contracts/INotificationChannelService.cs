using Notification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Services.Contracts
{
    public interface INotificationChannelService
    {
        Task<int> CreateAsync(NotificationChannelCrtVM notificationChannelCrtVM);
        Task<int> UpdateAsync(NotificationChannelCrtVM notificationChannelCrtVM);
        Task<List<NotificationChannelVM>> FetchAllAsync();
        Task<NotificationChannelCrtVM> FetchByIdAsync(int Id);
        Task<int> DeleteAsync(int Id);
    }
}
