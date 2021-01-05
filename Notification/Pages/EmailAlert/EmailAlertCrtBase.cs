using Microsoft.AspNetCore.Components;
using Notification.Models;
using Notification.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Pages.EmailAlert
{
    public class EmailAlertCrtBase : ComponentBase
    {
        [Inject]
        public IEmailAlertService EmailAlertService { get; set; }
        [Inject]
        NavigationManager navigationManager { get; set; }

        public EmailAlertCrtVM EmailAlertCrtVM { get; set; } = new EmailAlertCrtVM();

        [Parameter] public string Id { get; set; }
        private int NotificationId { get; set; } = 0;

        protected async override Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var id = int.Parse(Id);
                if (id > 0)
                {
                    EmailAlertCrtVM = await EmailAlertService.FetchByIdAsync(id);
                    NotificationId = EmailAlertCrtVM.Id;
                }

            }
        }
        protected async Task CrtOrUptEmailAlert()
        {
            if (NotificationId > 0)
            {
                await EmailAlertService.UpdateAsync(EmailAlertCrtVM);
            }
            else
            {
                await EmailAlertService.CreateAsync(EmailAlertCrtVM);
            }
            navigationManager.NavigateTo("/emailalerts");
        }
        protected void Cancel()
        {
            navigationManager.NavigateTo("/emailalerts");
        }
    }
}
