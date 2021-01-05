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
    public class NotificationTemplateService : INotificationTemplateService
    {
        private readonly INotificationTemplateRepository notificationTemplateRepository;
        public IMapper Mapper { get; }
        public NotificationTemplateService(INotificationTemplateRepository notificationTemplateRepository, IMapper mapper)
        {
            this.notificationTemplateRepository = notificationTemplateRepository;
            Mapper = mapper;
        }

        NotificationTemplate notificationTemplate = new NotificationTemplate();
        public async Task<int> CreateAsync(NotificationTemplateCrtVM notificationTemplateCrtVM)
        {
            int result = 0;
            try
            {
                //var notificationTemplateEntity = Mapper.Map(notificationTemplateCrtVM, notificationTemplate);
                notificationTemplate.Name = notificationTemplateCrtVM.Name;
                notificationTemplate.Description = notificationTemplateCrtVM.Description;
                notificationTemplate.NotificationTypeId = notificationTemplateCrtVM.NotificationTypeId;
                notificationTemplate.NotificationChannelId = notificationTemplateCrtVM.NotificationChannelId;
                result = await notificationTemplateRepository.AddAsync(notificationTemplate);
                return result;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return result;
            }
        }

        public async Task<int> DeleteAsync(int Id)
        {
            var result = await notificationTemplateRepository.DeleteAsync(Id);
            return result;
        }

        public async Task<List<NotificationTemplateVM>> FetchAllAsync()
        {
            var notificationTemplates = await notificationTemplateRepository.GetAllAsync();

            var results = Mapper.Map<List<NotificationTemplateVM>>(notificationTemplates);
            return results;
        }

        public async Task<NotificationTemplateCrtVM> FetchByIdAsync(int Id)
        {
            var notificationTemplate = await notificationTemplateRepository.GetByIdAsync(Id);
            var result = Mapper.Map<NotificationTemplateCrtVM>(notificationTemplate);
            return result;
        }

        public async Task<int> UpdateAsync(NotificationTemplateCrtVM notificationTemplateCrtVM)
        {
            var notificationTemplateEntity = Mapper.Map(notificationTemplateCrtVM, notificationTemplate);
            var result = await notificationTemplateRepository.UpdateAsync(notificationTemplateEntity);
            return result;
        }
    }
}
