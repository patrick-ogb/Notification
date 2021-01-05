using Notification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Services.Contracts
{
    public interface IActivityLogService
    {
        Task<int> DeleteAsync(int Id);
        Task<List<ActivityLogVM>> FetchAllAsync();
        Task<ActivityLogVM> FetchByIdAsync(int Id);
        Task<List<ActivityLogVM>> FetchByUrl(string Url);
        Task<int> UpdateAsync(ActivityLogVM activityLogVM);
        Task<List<ActivityLogVM>> FetchByApplicationName(string applicationName);
        Task<List<ActivityLogDateRangeVM>> FetchByDateRangeAsync(ActivityLogDateRangeVM activityLogDateRangeVM);
    }
}
