using Microsoft.AspNetCore.Components;
using Notification.Data;
using Notification.Models;
using Notification.Services.Contracts;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Pages.NotificationType
{
    public class NotificationTypesBase : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        DialogService DialogService { set; get; }
        [Inject]
        public INotificationTypeService NotificationTypeService { get; set; }
        public List<NotificationTypeVM> notificationTypevm { get; set; } = new List<NotificationTypeVM>();

        protected async override Task OnInitializedAsync()
        {
            notificationTypevm = await NotificationTypeService.FetchAllAsync();
        }

        protected void CrtNotificationType()
        {
            int Id = 0;
            NavigationManager.NavigateTo($"/createnotificationtype/{Id}");
        }
        protected void EditNotificationType(int Id)
        {
            NavigationManager.NavigateTo($"/createnotificationtype/{Id}");
        }
        
        protected async Task DeleteNotificationType(int id)
        {
            bool? result = await DialogService.Confirm("Are you sure?", "DELETE NOTIFICATION TYPE", new ConfirmOptions() { OkButtonText = "Yes", CancelButtonText = "No", ShowClose = false });

            if (result.Value == true)
            {
                var deletedNotification = await NotificationTypeService.DeleteAsync(id);
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
