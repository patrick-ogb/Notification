using Microsoft.AspNetCore.Components;
using Notification.Models;
using Notification.Services.Contracts;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Pages.EmailAlert
{
    public class EmailAlertsBase : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        DialogService DialogService { set; get; }
        [Inject]
        public IEmailAlertService EmailAlertService { get; set; }
        public List<EmailAlertVM> EmailAlertVMs { get; set; } = new List<EmailAlertVM>();

        protected async override Task OnInitializedAsync()
        {
            EmailAlertVMs = await EmailAlertService.FetchAllAsync();
        }

        protected void CrtEmailAlert()
        {
            int Id = 0;
            NavigationManager.NavigateTo($"/createemailalert/{Id}");
        }
        protected void EditEmailAlert(int Id)
        {
            NavigationManager.NavigateTo($"/createemailalert/{Id}");
        }

        protected async Task DeleteEmailAlert(int id)
        {
            bool? result = await DialogService.Confirm("Are you sure?", "DELETE  EMAIL ALERT", new ConfirmOptions() { OkButtonText = "Yes", CancelButtonText = "No", ShowClose = false });

            if (result.Value == true)
            {
                var deletedNotification = await EmailAlertService.DeleteAsync(id);
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
