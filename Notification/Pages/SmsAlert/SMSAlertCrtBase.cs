using Microsoft.AspNetCore.Components;
using Notification.Models;
using Notification.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Pages.SmsAlert
{
    public class SMSAlertCrtBase : ComponentBase
    {
        [Inject]
        public ISMSAlertService SMSAlertService { get; set; }
        [Inject]
        NavigationManager navigationManager { get; set; }

        public SMSAlertCrtVM SMSAlertCrtVM { get; set; } = new SMSAlertCrtVM();

        [Parameter] public string Id { get; set; }
        private int SmsAlertId { get; set; } = 0;

        protected async override Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var id = int.Parse(Id);
                if (id > 0)
                {
                    SMSAlertCrtVM = await SMSAlertService.FetchByIdAsync(id);
                    SmsAlertId = SMSAlertCrtVM.Id;
                }

            }
        }
        protected async Task CrtOrUptEmailAlert()
        {
            if (SmsAlertId > 0)
            {
                await SMSAlertService.UpdateAsync(SMSAlertCrtVM);
            }
            else
            {
                await SMSAlertService.CreateAsync(SMSAlertCrtVM);
            }
            navigationManager.NavigateTo("/smsalerts");
        }
        protected void Cancel()
        {
            navigationManager.NavigateTo("/smsalerts");
        }
    }
}
