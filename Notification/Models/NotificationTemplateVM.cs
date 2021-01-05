using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Models
{
    public class NotificationTemplateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int NotificationTypeId { get; set; }
        public string NotificationTypeName { get; set; }
        [Required]
        public int NotificationChannelId { get; set; }
        public string NotificationChannelName { get; set; }
    }
}
