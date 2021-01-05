using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Models
{
    public class ActivityLogGetByApplicationNameVM
    {
        [Required]
        public string ApplictionName { get; set; }
    }
}
