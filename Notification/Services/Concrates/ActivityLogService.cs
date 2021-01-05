using AutoMapper;
using Notification.Application.Interfaces;
using Notification.Core.Entities;
using Notification.Models;
using Notification.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Services.Concrates
{
    public class ActivityLogService : IActivityLogService
    {
        private readonly IActivityLogRepository activityLogRepository;
        public IMapper Mapper { get; }
        public ActivityLogService(IActivityLogRepository activityLogRepository, IMapper mapper)
        {
            this.activityLogRepository = activityLogRepository;
            Mapper = mapper;
        }
        ActivityLog activityLog = new ActivityLog();
        ActivityLogDateRange activityLogDateRange = new ActivityLogDateRange();

        public async Task<List<ActivityLogDateRangeVM>> FetchByDateRangeAsync(ActivityLogDateRangeVM activityLogDateRangeVM)
        {
            activityLogDateRange.StartDate = activityLogDateRangeVM.StartDate;
            activityLogDateRange.EndDate = activityLogDateRangeVM.EndDate;
            var notificationTypes = await activityLogRepository.FetchByDateRange(activityLogDateRange);
            var results = Mapper.Map<List<ActivityLogDateRangeVM>>(notificationTypes);
            return results;
        }

        public async Task<List<ActivityLogVM>> FetchByUrl(string Url)
        {
         var activityLogObj =   await activityLogRepository.FetchByUrl(Url);
            var results = Mapper.Map<List<ActivityLogVM>>(activityLogObj);
            return results;
        }

        public async Task<List<ActivityLogVM>> FetchAllAsync()
        {
            var entityObj = await activityLogRepository.GetAllAsync();
            var results = Mapper.Map<List<ActivityLogVM>>(entityObj);
            return results;
        }

        public async Task<List<ActivityLogVM>> FetchByApplicationName(string applicationName)
        {
            var activityLogObj = await activityLogRepository.FetchByApplicationName(applicationName);
            var results = Mapper.Map<IEnumerable<ActivityLogVM>>(activityLogObj);
            return results.ToList();
        }

        public async Task<int> UpdateAsync(ActivityLogVM activityLogVM)
        {
            var emailAlertEntity = Mapper.Map(activityLogVM, activityLog);
            var result = await activityLogRepository.UpdateAsync(emailAlertEntity);
            return result;
        }

        public async Task<ActivityLogVM> FetchByIdAsync(int Id)
        {
            var activityLogEntity = await activityLogRepository.GetByIdAsync(Id);
            var result = Mapper.Map<ActivityLogVM>(activityLogEntity);
            return result;
        }

        public async Task<int> DeleteAsync(int Id)
        {
            var result = await activityLogRepository.DeleteAsync(Id);
            return result;
        }
    }
}
