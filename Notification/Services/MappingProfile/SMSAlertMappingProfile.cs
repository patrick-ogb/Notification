using AutoMapper;
using Notification.Core.Entities;
using Notification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Services.MappingProfile
{
    public class SMSAlertMappingProfile : Profile
    {
        public SMSAlertMappingProfile()
        {
            CreateMap<SMSAlert, SMSAlertCrtVM>();
            CreateMap<SMSAlertCrtVM, SMSAlert>();

            CreateMap<SMSAlert, SMSAlertVM>();
            CreateMap<SMSAlertVM, SMSAlert>();
        }
    }
}
