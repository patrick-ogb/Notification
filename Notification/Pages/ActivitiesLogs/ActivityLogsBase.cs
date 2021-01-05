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
    public class ActivityLogsBase : ComponentBase
    {
        
        [Inject]
        protected IActivityLogService ActivityLogService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        DialogService DialogService { set; get; }

        protected DateTime? StartDate { get; set; } = DateTime.Now.AddDays(0);
        protected DateTime? EndDate { get; set; } = DateTime.Now.AddDays(0);
        protected ActivityLogDateRangeVM activityLogDateRangeVM { get; set; } = new ActivityLogDateRangeVM();
        protected List<ActivityLogVM> activityLogVMs { get; set; } = new List<ActivityLogVM>();

        protected async override Task OnInitializedAsync()
        {
            activityLogVMs = await ActivityLogService.FetchAllAsync();
        }

        protected void EditActivityLog(int Id)
        {
            NavigationManager.NavigateTo($"/activitylogedit/{Id}");
        }

        protected async Task DeleteActivityLog(int id)
        {
            bool? result = await DialogService.Confirm("Are you sure?", "DELETE ACTIVITY LOG", new ConfirmOptions() { OkButtonText = "Yes", CancelButtonText = "No", ShowClose = false });

            if (result.Value == true)
            {
                var deletedNotification = await ActivityLogService.DeleteAsync(id);
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
