using AutoMapper;
using Notification.Core.Entities;
using Notification.Models;

namespace Notification.Services.MappingProfile
{
    public class NotificationChannelMappingProfile : Profile
    {
        public NotificationChannelMappingProfile()
        {
            CreateMap<NotificationChannel, NotificationChannelVM>();
            CreateMap<NotificationChannelVM, NotificationChannel>();

            CreateMap<NotificationChannel, NotificationChannelCrtVM>();
            CreateMap<NotificationChannelCrtVM, NotificationChannel>();
        }
    }
}
