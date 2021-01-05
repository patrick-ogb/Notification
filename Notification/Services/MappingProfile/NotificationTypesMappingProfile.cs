using AutoMapper;
using Notification.Core.Entities;
using Notification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Services.MappingProfile
{
    public class NotificationTypesMappingProfile : Profile
    {
        public NotificationTypesMappingProfile()
        {
            CreateMap<NotificationType, NotificationTypeVM>();
            CreateMap<NotificationTypeVM, NotificationType>();

            CreateMap<NotificationTypeCrtVM, NotificationType>();
            CreateMap<NotificationType, NotificationTypeCrtVM>();
        }
    }
}
