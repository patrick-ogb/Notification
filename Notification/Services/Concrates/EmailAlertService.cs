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
    public class EmailAlertService : IEmailAlertService
    {
        private readonly IEmailAlertRepository emailAlertRepository;
        public IMapper Mapper { get; }
        public EmailAlertService(IEmailAlertRepository emailAlertRepository, IMapper mapper)
        {
            this.emailAlertRepository = emailAlertRepository;
            Mapper = mapper;
        }

        EmailAlert emailAlert = new EmailAlert();
        public async Task<int> CreateAsync(EmailAlertCrtVM emailAlertCrtVM)
        {
            var emailAlertEntity = Mapper.Map(emailAlertCrtVM, emailAlert);
            var result = await emailAlertRepository.AddAsync(emailAlertEntity);
            return result;
        }

        public async Task<int> DeleteAsync(int Id)
        {
            var result = await emailAlertRepository.DeleteAsync(Id);
            return result;
        }

        public async Task<List<EmailAlertVM>> FetchAllAsync()
        {
            var notificationTypes = await emailAlertRepository.GetAllAsync();
            var results = Mapper.Map<List<EmailAlertVM>>(notificationTypes);
            return results;
        }

        public async Task<EmailAlertCrtVM> FetchByIdAsync(int Id)
        {
            var notificationType = await emailAlertRepository.GetByIdAsync(Id);
            var result = Mapper.Map<EmailAlertCrtVM>(notificationType);
            return result;
        }

        public async Task<int> UpdateAsync(EmailAlertCrtVM emailAlertCrtVM)
        {
            var emailAlertEntity = Mapper.Map(emailAlertCrtVM, emailAlert);
            var result = await emailAlertRepository.UpdateAsync(emailAlertEntity);
            return result;
        }
    }
}
