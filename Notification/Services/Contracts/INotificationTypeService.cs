using Notification.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notification.Services.Contracts
{
    public interface INotificationTypeService
    {
        Task<int> CreateAsync(NotificationTypeCrtVM notificationTypeCrtVM);
        Task<int> UpdateAsync(NotificationTypeCrtVM notificationTypeCrtVM);
        Task<List<NotificationTypeVM>> FetchAllAsync();
        Task<NotificationTypeCrtVM> FetchByIdAsync(int Id);
        Task<int> DeleteAsync(int Id);

    }
}
