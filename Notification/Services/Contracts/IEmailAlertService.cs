using Notification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Services.Contracts
{
    public interface IEmailAlertService
    {
        Task<int> DeleteAsync(int Id);
        Task<List<EmailAlertVM>> FetchAllAsync();
        Task<EmailAlertCrtVM> FetchByIdAsync(int Id);
        Task<int> CreateAsync(EmailAlertCrtVM emailAlertCrtVM);
        Task<int> UpdateAsync(EmailAlertCrtVM emailAlertCrtVM);
    }
}
