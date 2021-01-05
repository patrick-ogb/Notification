using Microsoft.AspNetCore.Components;
using Notification.Models;
using Notification.Services.Contracts;
using Radzen;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notification.Pages.ActivitiesLogs
{
    public class ActivityLogGetByUrlBase : ComponentBase
    {
        public bool IsTrue { get; set; } = false;

        [Inject]
        protected IActivityLogService ActivityLogService { get; set; }
        [Inject]
        DialogService DialogService { set; get; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected ActivityLogGetByUrlVM activityLogGetByUrlVM { get; set; } = new ActivityLogGetByUrlVM();
        protected List<ActivityLogVM> activityLogVMs { get; set; } = new List<ActivityLogVM>();

        protected async Task SearchActivityLogByUrl()
        {
            IsTrue = true;
            activityLogVMs = await ActivityLogService.FetchByUrl(activityLogGetByUrlVM.Url.ToString());
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
