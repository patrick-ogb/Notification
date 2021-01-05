using Notification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Services.Contracts
{
   public interface ISMSAlertService
    {
        Task<int> CreateAsync(SMSAlertCrtVM sMSAlertCrtVM);
        Task<int> UpdateAsync(SMSAlertCrtVM sMSAlertCrtVM);
        Task<List<SMSAlertVM>> FetchAllAsync();
        Task<SMSAlertCrtVM> FetchByIdAsync(int Id);
        Task<int> DeleteAsync(int Id);
    }
}
