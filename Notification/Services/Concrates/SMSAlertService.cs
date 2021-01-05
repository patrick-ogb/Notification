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
    public class SMSAlertService : ISMSAlertService
    {
        private readonly ISMSAlertRepository sMSAlertRepository;
        public IMapper Mapper { get; }
        public SMSAlertService(ISMSAlertRepository sMSAlertRepository, IMapper mapper)
        {
            this.sMSAlertRepository = sMSAlertRepository;
            Mapper = mapper;
        }

        SMSAlert sMSAlert = new SMSAlert();
        public async Task<int> CreateAsync(SMSAlertCrtVM sMSAlertCrtVM)
        {
            var sMSAlertEntity = Mapper.Map(sMSAlertCrtVM, sMSAlert);
            var result = await sMSAlertRepository.AddAsync(sMSAlertEntity);
            return result;
        }

        public async Task<int> DeleteAsync(int Id)
        {
            var result = await sMSAlertRepository.DeleteAsync(Id);
            return result;
        }

        public async Task<List<SMSAlertVM>> FetchAllAsync()
        {
            var notificationTypes = await sMSAlertRepository.GetAllAsync();
            var results = Mapper.Map<List<SMSAlertVM>>(notificationTypes);
            return results;
        }

        public async Task<SMSAlertCrtVM> FetchByIdAsync(int Id)
        {
            var notificationType = await sMSAlertRepository.GetByIdAsync(Id);
            var result = Mapper.Map<SMSAlertCrtVM>(notificationType);
            return result;
        }

        public async Task<int> UpdateAsync(SMSAlertCrtVM sMSAlertCrtVM)
        {
            var sMSAlertEntity = Mapper.Map(sMSAlertCrtVM, sMSAlert);
            var result = await sMSAlertRepository.UpdateAsync(sMSAlertEntity);
            return result;
        }
    }
}
