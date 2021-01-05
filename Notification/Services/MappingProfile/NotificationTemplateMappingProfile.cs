using AutoMapper;
using Notification.Core.Entities;
using Notification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Services.MappingProfile
{
    public class NotificationTemplateMappingProfile : Profile
    {
        public NotificationTemplateMappingProfile()
        {
            CreateMap<NotificationTemplate, NotificationTemplateVM>();
            CreateMap<NotificationTemplateVM, NotificationTemplate>();

            CreateMap<NotificationTemplate, NotificationTemplateCrtVM>();
            CreateMap<NotificationTemplateCrtVM, NotificationTemplate>();
        }
    }
}
