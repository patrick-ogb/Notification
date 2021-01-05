using Notification.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Interfaces
{
   public interface IActivityLogRepository : IGenericRepository<ActivityLog>
    {
        Task<IReadOnlyList<ActivityLog>> FetchByUrl(string Url);
        Task<List<ActivityLogDateRange>> FetchByDateRange(ActivityLogDateRange dateReangeEntity);
        Task<IReadOnlyList<ActivityLog>> FetchByApplicationName(string ApplicationName);
    }
}
