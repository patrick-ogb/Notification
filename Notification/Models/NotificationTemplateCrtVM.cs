﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Models
{
    public class NotificationTemplateCrtVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public int NotificationTypeId { get; set; }

        [Required]
        public int NotificationChannelId { get; set; }
    }
}
