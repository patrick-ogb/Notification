using Notification.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Interfaces
{
    public interface INotificationTemplateRepository : IGenericRepository<NotificationTemplate>
    {
        Task<int> FetchByNotificationTypeId(int id);
        Task<int> FetchByNotificationChannelId(int id);
    }
}
