using Microsoft.AspNetCore.Components;
using Notification.Application.Interfaces;
using Notification.Models;
using Notification.Services.Contracts;
using System.Threading.Tasks;

namespace Notification.Pages.NotificationType
{
    public class NotificationTypeCrtBase : ComponentBase
    {
        [Inject]
        public INotificationTypeService NotificationTypeService { get; set; }

        [Inject]
        NavigationManager navigationManager { get; set; }

        public NotificationTypeCrtVM NotificationTypeCrt { get; set; } = new NotificationTypeCrtVM();

        [Parameter] public string Id { get; set; }
        private int NotificationId { get; set; } = 0;

        protected async override Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var id = int.Parse(Id);
                if (id > 0)
                {
                    NotificationTypeCrt = await NotificationTypeService.FetchByIdAsync(id);
                    NotificationId = NotificationTypeCrt.Id;
                }

            }
        }
        protected async Task CrtOrUptNotificationType()
        {
            if (NotificationId > 0)
            {
                await NotificationTypeService.UpdateAsync(NotificationTypeCrt);
            }
            else
            {
                await NotificationTypeService.CreateAsync(NotificationTypeCrt);
            }
            navigationManager.NavigateTo("/notificationtypes");
        }

        protected void Cancel()
        {
            navigationManager.NavigateTo("/notificationtypes");
        }
    }
}
