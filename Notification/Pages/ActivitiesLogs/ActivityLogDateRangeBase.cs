using Microsoft.AspNetCore.Components;
using Notification.Models;
using Notification.Services.Contracts;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Pages.ActivitiesLogs
{
    public class ActivityLogDateRangeBase : ComponentBase
    {
        [Inject]
        protected IActivityLogService ActivityLogService { get; set; }
        [Inject]
        DialogService DialogService { set; get; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected bool IsTrue { get; set; } = false;
        protected DateTime? StartDate { get; set; } = DateTime.Now.AddDays(0);
        protected DateTime? EndDate { get; set; } = DateTime.Now.AddDays(0);
        protected ActivityLogDateRangeVM activityLogDateRangeVM { get; set; } = new ActivityLogDateRangeVM();
        protected List<ActivityLogDateRangeVM> activityLogDateRangeVMs { get; set; } = new List<ActivityLogDateRangeVM>();

        protected override void OnInitialized()
        {

        }

        protected async Task AddActivityLog()
        {
            IsTrue = true;
            activityLogDateRangeVMs = await ActivityLogService.FetchByDateRangeAsync(activityLogDateRangeVM);
        }
        protected void EditActivityLog(string activityLog)
        {
            NavigationManager.NavigateTo($"/activitylogedit/{activityLog}");
        }
        protected async Task DeleteActivityLog(int Id)
        {
            bool? result = await DialogService.Confirm("Are you sure?", "DELETE ACTIVITY LOG", new ConfirmOptions() { OkButtonText = "Yes", CancelButtonText = "No", ShowClose = false });

            if (result.Value == true)
            {
                var deletedNotification = await ActivityLogService.DeleteAsync(Id);
                if (deletedNotification > 0)
                {
                }
                else
                {
                }
            }
        }


    }
}
