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
    public class NotificationTypeService : INotificationTypeService
    {
        private readonly INotificationTypeRepository notificationTypeRepository;
        public IMapper Mapper { get; }
        public NotificationTypeService(INotificationTypeRepository notificationTypeRepository, IMapper mapper)
        {
            this.notificationTypeRepository = notificationTypeRepository;
            Mapper = mapper;
        }

        NotificationType notificationType = new NotificationType();

        public async Task<int> CreateAsync(NotificationTypeCrtVM notificationTypeCrtVM)
        {
            var notificationTypeEntity = Mapper.Map(notificationTypeCrtVM, notificationType);
            var result = await notificationTypeRepository.AddAsync(notificationTypeEntity);
            return result;
        }

        public async Task<int> DeleteAsync(int Id)
        {
            var result = await notificationTypeRepository.DeleteAsync(Id);
            return result;
        }

        public async Task<List<NotificationTypeVM>> FetchAllAsync()
        {
           var notificationTypes = await notificationTypeRepository.GetAllAsync();
            var results =  Mapper.Map<List<NotificationTypeVM>>(notificationTypes);
            return results;
        }

        public async Task<NotificationTypeCrtVM> FetchByIdAsync(int Id)
        {
            var notificationType = await notificationTypeRepository.GetByIdAsync(Id);
            var result = Mapper.Map<NotificationTypeCrtVM>(notificationType);
            return result;
        }

        public async Task<int> UpdateAsync(NotificationTypeCrtVM notificationTypeCrtVM)
        {
            var notificationtype = Mapper.Map(notificationTypeCrtVM, notificationType);
            var result = await notificationTypeRepository.UpdateAsync(notificationtype);
            return result;
        }
    }
}
