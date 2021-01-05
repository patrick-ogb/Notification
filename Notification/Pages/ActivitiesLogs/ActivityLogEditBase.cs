using Microsoft.AspNetCore.Components;
using Notification.Models;
using Notification.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Pages.ActivitiesLogs
{
    public class ActivityLogEditBase : ComponentBase
    {
        [Inject]
        public IActivityLogService ActivityLogService { get; set; }

        [Inject]
        NavigationManager navigationManager { get; set; }

        public ActivityLogVM ActivityLogVM { get; set; } = new ActivityLogVM();

        [Parameter] public string activitylog { get; set; }
        private int NotificationId { get; set; } = 0;

        private string PageLinkName { get; set; }

        protected async override Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(activitylog))
            {
                if (int.TryParse(activitylog, out int Id))
                {
                    ActivityLogVM = await ActivityLogService.FetchByIdAsync(Id);
                    NotificationId = ActivityLogVM.Id;
                }
                else
                {
                    var values = activitylog.Split("_");
                    Id = int.Parse(values[0]);
                    PageLinkName = values[1];

                    ActivityLogVM = await ActivityLogService.FetchByIdAsync(Id);
                    NotificationId = ActivityLogVM.Id;
                }

            }
        }
        protected async Task EditActivityLog()
        {
            if (NotificationId > 0)
            {
                await ActivityLogService.UpdateAsync(ActivityLogVM);
            }
            
            if (NotificationId > 0 && PageLinkName == "ActivityLogDateRange")
            {
                navigationManager.NavigateTo("/activitylogdaterange");
            }
            else if (NotificationId > 0 && PageLinkName == "ActivityLogUrl")
            {
                navigationManager.NavigateTo("/activityloggetbyurl");
            }
            else if (NotificationId > 0 && PageLinkName == "ActivityAppName")
            {
                navigationManager.NavigateTo("/activityloggetbyappname");
            }
            else 
            {
                navigationManager.NavigateTo("/activitlogs");
            }
        }

        protected void Cancel()
        {
            if (NotificationId > 0 && PageLinkName == "ActivityLogDateRange")
            {
                navigationManager.NavigateTo("/activitylogdaterange");
            }
            else if (NotificationId > 0 && PageLinkName == "ActivityLogUrl")
            {
                navigationManager.NavigateTo("/activityloggetbyurl");
            }
            else if (NotificationId > 0 && PageLinkName == "ActivityAppName")
            {
                navigationManager.NavigateTo("/activityloggetbyappname");
            }
            else
            {
                navigationManager.NavigateTo("/activitlogs");
            }

        }
    }
}
