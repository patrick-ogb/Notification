using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Core.Entities
{
   public class ActivityLogDateRange
    {
        public int Id { get; set; }
        public string ApplicationName { get; set; }
        public string Url { get; set; }
        public string ActivityTyp_Request_Response { get; set; }
        public string Data { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserName { get; set; }
        public string IPAddress { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
