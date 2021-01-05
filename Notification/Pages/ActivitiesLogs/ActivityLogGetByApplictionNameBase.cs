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
    public class ActivityLogGetByApplictionNameBase : ComponentBase
    {
        public bool IsTrue { get; set; } = false;

        [Inject]
        protected IActivityLogService ActivityLogService { get; set; }
        [Inject]
        DialogService DialogService { set; get; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected ActivityLogGetByApplicationNameVM model { get; set; } = new ActivityLogGetByApplicationNameVM();
        protected List<ActivityLogVM> activityLogVMs { get; set; } = new List<ActivityLogVM>();

        protected async Task SearchActivityLogByAppName()
        {
            IsTrue = true;
            activityLogVMs = await ActivityLogService.FetchByApplicationName(model.ApplictionName.ToString());
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
