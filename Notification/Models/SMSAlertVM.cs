using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Models
{
    public class SMSAlertVM
    {
        public int Id { get; set; }
        public string MobileNo { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string ReceiverName { get; set; }
        public string UserType { get; set; }
        public string BackOfficeUser_SubscriberUser { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateProcessed { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
        public string Reeson { get; set; }
        public string CreatedBy { get; set; }
        public int Sendtries { get; set; }
    }
}
