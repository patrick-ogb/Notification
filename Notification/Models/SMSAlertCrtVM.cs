using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Models
{
    public class SMSAlertCrtVM
    {
        public int Id { get; set; }
        [Required]
        public string MobileNo { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string ReceiverName { get; set; }
    }
}
