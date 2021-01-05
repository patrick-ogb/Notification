using AutoMapper;
using Notification.Core.Entities;
using Notification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Services.MappingProfile
{
    public class EmailAlertMappingProfile : Profile
    {
        public EmailAlertMappingProfile()
        {
            CreateMap<EmailAlert, EmailAlertVM>();
            CreateMap<EmailAlertVM, EmailAlert>();

            CreateMap<EmailAlert, EmailAlertCrtVM>();
            CreateMap<EmailAlertCrtVM, EmailAlert>();
        }
    }
}
