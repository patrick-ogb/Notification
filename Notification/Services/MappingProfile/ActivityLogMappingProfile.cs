using AutoMapper;
using Notification.Core.Entities;
using Notification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Services.MappingProfile
{
    public class ActivityLogMappingProfile : Profile
    {
        public ActivityLogMappingProfile()
        {
            CreateMap<ActivityLogDateRange, ActivityLogDateRangeVM>();
            CreateMap<ActivityLogDateRangeVM, ActivityLogDateRange>();

            CreateMap<ActivityLog, ActivityLogVM>();
            CreateMap<ActivityLogVM, ActivityLog>();
        }
    }
}
