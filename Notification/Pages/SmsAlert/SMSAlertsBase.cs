using Microsoft.AspNetCore.Components;
using Notification.Models;
using Notification.Services.Contracts;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Pages.SmsAlert
{
    public class SMSAlertsBase : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        DialogService DialogService { set; get; }
        [Inject]
        public ISMSAlertService SMSAlertService { get; set; }
        public List<SMSAlertVM> SMSAlertVMs { get; set; } = new List<SMSAlertVM>();

        protected async override Task OnInitializedAsync()
        {
            SMSAlertVMs = await SMSAlertService.FetchAllAsync();
        }

        protected void AddSMSAlert()
        {
            int Id = 0;
            NavigationManager.NavigateTo($"/createsmsalert/{Id}");
        }
        protected void EditSMSAlert(int Id)
        {
            NavigationManager.NavigateTo($"/createsmsalert/{Id}");
        }

        protected async Task DeleteSMSAlert(int id)
        {
            bool? result = await DialogService.Confirm("Are you sure?", "DELETE  SMS ALERT", new ConfirmOptions() { OkButtonText = "Yes", CancelButtonText = "No", ShowClose = false });

            if (result.Value == true)
            {
                var deletedNotification = await SMSAlertService.DeleteAsync(id);
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
