using Microsoft.AspNetCore.Components;
using Notification.Models;
using Notification.Services.Contracts;
using System.Threading.Tasks;

namespace Notification.Pages.NotificationChannel
{
    public class NotificationChannelCrtBase : ComponentBase
    {
        [Inject]
        public INotificationChannelService NotificationChannelService { get; set; }
        [Inject]
        NavigationManager navigationManager { get; set; }

        public NotificationChannelCrtVM NotificationChannelCrtVM { get; set; } = new NotificationChannelCrtVM();

        [Parameter] public string Id { get; set; }
        private int NotificationId { get; set; } = 0;

        protected async override Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var id = int.Parse(Id);
                if (id > 0)
                {
                    NotificationChannelCrtVM = await NotificationChannelService.FetchByIdAsync(id);
                    NotificationId = NotificationChannelCrtVM.Id;
                }

            }
        }
        protected async Task CrtOrUptNotificationChannel()
        {
            if (NotificationId > 0)
            {
                await NotificationChannelService.UpdateAsync(NotificationChannelCrtVM);
            }
            else
            {
                await NotificationChannelService.CreateAsync(NotificationChannelCrtVM);
            }
            navigationManager.NavigateTo("/notificationchannel");
        }
        protected void Cancel()
        {
            navigationManager.NavigateTo("/notificationchannel");
        }
    }
}
