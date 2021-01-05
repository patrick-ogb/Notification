using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Notification.Data;
using Notification.Models;
using Notification.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Pages.NotificationTemplate
{
    public class NotificationTemplateCrtBase : ComponentBase
    {
        [Inject]
        INotificationTemplateService NotificationTemplateService{get; set;}

        [Inject]
        public INotificationTypeService NotificationTypeService { get; set; }

        [Inject]
        public INotificationChannelService NotificationChannelService { get; set; }

        [Inject]
        NavigationManager navigationManager { get; set; }

        [Inject]
        ISessionStorageService SessionStorageService { set; get; }

        [Parameter] public string Id { get; set; }
        private int NotificationId { get; set; } = 0;

        protected int NotificationTypeId { get; set; } 
        protected int NotificationChannelpeId { get; set; }
        protected bool IsTypeAndChannelIds { get; set; } = false;

        protected string DefaultSelectedNotificationType { get; set; }
        protected string DefaultSelectedNotificationChannel { get; set; }
        protected NotificationNames NotificationValues { get; set; }

        protected List<NotificationTypeVM> notificationTypeVMs = new List<NotificationTypeVM>();
        protected List<NotificationChannelVM> notificationChannelVMs = new List<NotificationChannelVM>();

        protected NotificationTemplateCrtVM notificationTemplateCrtVM { get; set; } = new NotificationTemplateCrtVM();
        protected async override Task OnInitializedAsync()
        {
            NotificationValues = await SessionStorageService.GetItemAsync<NotificationNames>(Id);
            DefaultSelectedNotificationType = "Select Notification Type";
            DefaultSelectedNotificationChannel = "Select Notification Channel";
            if (!string.IsNullOrEmpty(Id))
            {
                var id = int.Parse(Id);
                if (id > 0)
                {
                    notificationTemplateCrtVM = await NotificationTemplateService.FetchByIdAsync(id);
                    NotificationId = notificationTemplateCrtVM.Id;

                    DefaultSelectedNotificationType = NotificationValues.NotificationTypeName == null
                        ? DefaultSelectedNotificationType= "Select Notification Type" : NotificationValues.NotificationTypeName;

                    DefaultSelectedNotificationChannel = NotificationValues.NotificationChannelName == null 
                        ? DefaultSelectedNotificationChannel = "Select Notification Channel" : NotificationValues.NotificationChannelName;
                }
                
                notificationTypeVMs = await NotificationTypeService.FetchAllAsync();
                notificationChannelVMs = await NotificationChannelService.FetchAllAsync();
            }
            
        }

        protected async Task CrtOrUptNotificationTemplate()
        {

            if(notificationTemplateCrtVM.Id > 0)
            {
               if(NotificationTypeId <= 0 || NotificationChannelpeId <= 0)
               {
                    notificationTemplateCrtVM.NotificationTypeId = int.Parse(NotificationValues.NotificationTypeId);
                    notificationTemplateCrtVM.NotificationChannelId = int.Parse(NotificationValues.NotificationChannelId);
               }
               await NotificationTemplateService.UpdateAsync(notificationTemplateCrtVM);
            }
            else
            {
                if (NotificationTypeId > 0 && NotificationChannelpeId > 0)
                {
                    notificationTemplateCrtVM.NotificationTypeId = NotificationTypeId;
                    notificationTemplateCrtVM.NotificationChannelId = NotificationChannelpeId;
                    await NotificationTemplateService.CreateAsync(notificationTemplateCrtVM);
                }
                IsTypeAndChannelIds = true;
            }
            navigationManager.NavigateTo("/notificationtemplate");
        }

        protected void Cancel()
        {
            navigationManager.NavigateTo("/notificationtemplate");
        }

    }
}
