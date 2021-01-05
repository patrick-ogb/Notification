using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Models
{
    public class ActivityLogVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="User name must be provided")]
        public string UserName { get; set; }
        [Required]
        public string IPAddress { get; set; }
        [Required(ErrorMessage ="Application name must be provided")]
        public string ApplicationName { get; set; }
        [Required]
        public string Url { get; set; }
        public DateTime DateCreated { get; set; }
        [Required(ErrorMessage ="Activiy type must be provided")]
        public string ActivityTyp_Request_Response { get; set; }
        [Required]
        public string Data { get; set; }
    }
}
