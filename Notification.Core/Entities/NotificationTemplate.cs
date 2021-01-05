using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Core.Entities
{
   public class NotificationTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NotificationTypeId { get; set; }
        public string NotificationTypeName { get; set; }
        public int NotificationChannelId { get; set; }
        public string NotificationChannelName { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
    }
}
