using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Data
{
    public class NotificationNames
    {
        public string NotificationTypeId { get; set; }
        public string NotificationChannelId { get; set;}
        public string NotificationTypeName { get; set; }
        public string NotificationChannelName { get; set; }

        public NotificationNames(){}
        public NotificationNames(string notificationTypeName, 
            string notificationChannelName,
            string notificationTypeId,
            string notificationChannelId)
        {
            NotificationTypeName = notificationTypeName;
            NotificationChannelName = notificationChannelName;
            NotificationTypeId = notificationTypeId;
            NotificationChannelId = notificationChannelId;
        }
    }
}
