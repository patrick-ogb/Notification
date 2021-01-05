using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Models
{
    public class ActivityLogDateRangeVM
    {
        public int Id { get; set; }
        public string ApplicationName { get; set; }
        public string Url { get; set; }
        public DateTime DateCreated { get; set; }
        public string ActivityTyp_Request_Response { get; set; }
        public string Data { get; set; }
        public string UserName { get; set; }
        public string IPAddress { get; set; }

        [Required]
        [CustomValidation(typeof(ActivityLogDateRangeVM), nameof(RequiredDateTime))]
        public DateTime StartDate { get; set; }

        [Required]
        [CustomValidation(typeof(ActivityLogDateRangeVM), nameof(RequiredDateTime))]
        public DateTime EndDate { get; set; }

        public static ValidationResult RequiredDateTime(DateTime value, ValidationContext vc)
        {
            return value > DateTime.MinValue
                ? ValidationResult.Success
                : new ValidationResult($"The {vc.MemberName} field is required.", new[] { vc.MemberName });
        }
    }
}
