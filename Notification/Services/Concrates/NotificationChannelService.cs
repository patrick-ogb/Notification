using AutoMapper;
using Notification.Application.Interfaces;
using Notification.Core.Entities;
using Notification.Models;
using Notification.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Services.Concrates
{
    public class NotificationChannelService : INotificationChannelService
    {
        private readonly INotificationChannelRepository notificationChannelRepository;
        public IMapper Mapper { get; }
        public NotificationChannelService(INotificationChannelRepository notificationChannelRepository,
            IMapper mapper)
        {
            this.notificationChannelRepository = notificationChannelRepository;
            Mapper = mapper;
        }
        NotificationChannel notificationChannel = new NotificationChannel();

        public async Task<int> CreateAsync(NotificationChannelCrtVM notificationChannelCrtVM)
        {
            var notificationChannelEntity = Mapper.Map(notificationChannelCrtVM, notificationChannel);
            var result = await notificationChannelRepository.AddAsync(notificationChannelEntity);
            return result;
        }

        public async Task<int> DeleteAsync(int Id)
        {
            var result = await notificationChannelRepository.DeleteAsync(Id);
            return result;
        }

        public async Task<List<NotificationChannelVM>> FetchAllAsync()
        {
            var notificationChannel = await notificationChannelRepository.GetAllAsync();
            var results = Mapper.Map<List<NotificationChannelVM>>(notificationChannel);
            return results;

        }

        public async Task<NotificationChannelCrtVM> FetchByIdAsync(int Id)
        {
            var notificationChannel = await notificationChannelRepository.GetByIdAsync(Id);
            var result = Mapper.Map<NotificationChannelCrtVM>(notificationChannel);
            return result;
        }

        public async Task<int> UpdateAsync(NotificationChannelCrtVM notificationChannelCrtVM)
        {
            var notificationChannelEntity = Mapper.Map(notificationChannelCrtVM, notificationChannel);
            var result = await notificationChannelRepository.UpdateAsync(notificationChannelEntity);
            return result;
        }
    }
}
