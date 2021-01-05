using Microsoft.AspNetCore.Components;
using Notification.Models;
using Notification.Services.Contracts;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Pages.NotificationChannel
{
    public class NotificationChannelsBase :  ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        DialogService DialogService { set; get; }
        [Inject]
        public INotificationChannelService NotificationChannelService { get; set; }
        public List<NotificationChannelVM> notificationChannelVM { get; set; } = new List<NotificationChannelVM>();

        protected async override Task OnInitializedAsync()
        {
            notificationChannelVM = await NotificationChannelService.FetchAllAsync();
        }

        protected void CrtNotificationChannel()
        {
            int Id = 0;
            NavigationManager.NavigateTo($"/createnotificationchannel/{Id}");
        }
        protected void EditNotificationChannel(int Id)
        {
            NavigationManager.NavigateTo($"/createnotificationchannel/{Id}");
        }
        
        protected async Task DeleteNotificationChannel(int id)
        {
            bool? result = await DialogService.Confirm("Are you sure?", "DELETE NOTIFICATION CHANNEL", new ConfirmOptions() { OkButtonText = "Yes", CancelButtonText = "No", ShowClose = false });

            if (result.Value == true)
            {
                var deletedNotification = await NotificationChannelService.DeleteAsync(id);
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
