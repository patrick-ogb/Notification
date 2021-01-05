using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Notification.Data;
using Notification.Models;
using Notification.Services.Contracts;
using Radzen;
using System; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Pages.NotificationTemplate
{
    public class NotificationTemplatesBase : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        DialogService DialogService { set; get; }

        [Inject]
        public INotificationTemplateService NotificationTemplateService { get; set; }

        [Inject]
        ISessionStorageService SessionStorageService { set; get; }

        public List<NotificationTemplateVM> notificationTempatevms { get; set; } = new List<NotificationTemplateVM>();

        protected async override Task OnInitializedAsync()
        {
            notificationTempatevms = await NotificationTemplateService.FetchAllAsync();
        }

        protected void CrtNotificationTemplate()
        {
            int Id = 0;
            NavigationManager.NavigateTo($"/createnotificationtemplate/{Id}");
        }
        protected void EditNotificationType(string notifictionValues)
        {
            if (!string.IsNullOrEmpty(notifictionValues))
            {
                var parts = notifictionValues.Split("_");
                var Id = parts[0];
                string notificationTypeName = parts[1];
                string notificationChannelName = parts[2];
                string notificationTypeId = parts[3];
                string notificationChannelId = parts[4];
                SessionStorageService.SetItemAsync(Id, new NotificationNames(notificationTypeName,
                                                                                notificationChannelName,
                                                                                notificationTypeId,
                                                                                notificationChannelId));
                NavigationManager.NavigateTo($"/createnotificationtemplate/{Id}");
            }
        }

        protected async Task DeleteNotificationTemplate(int id)
        {
            bool? result = await DialogService.Confirm("Are you sure?", "DELETE NOTIFICATION TEMPLATE", new ConfirmOptions() { OkButtonText = "Yes", CancelButtonText = "No", ShowClose = false });

            if (result.Value == true)
            {
                var deletedNotification = await NotificationTemplateService.DeleteAsync(id);
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
