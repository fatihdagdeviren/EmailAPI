using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Models;
using EmailAPI.DTO.EmailAttachment;
using EmailAPI.DTO.EmailDate;
using EmailAPI.DTO.EmailProvider;
using EmailAPI.DTO.EmailQueue;

namespace EmailAPI.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<EmailProvider, EmailProviderDto>();
            CreateMap<SaveEmailProviderDto, EmailProvider>();
            
            CreateMap<EmailQueue, EmailQueueDto>();
            CreateMap<SaveEmailQueueDto, EmailQueue>();

            CreateMap<EmailAttachment, EmailAttachmentDto>();
            CreateMap<EmailAttachment, GetEmailAttachmentDto>();
            CreateMap<SaveEmailAttachmentDto, EmailAttachment>();
            CreateMap<SaveEmailAttachmentForEmailQueueDto, EmailAttachment>();


            CreateMap<EmailDate, EmailDateDto>();
            CreateMap<SaveEmailDateDto, EmailDate>();
            CreateMap<SaveEmailDateDtoForEmailQueueDto, EmailDate>();
            
        }
    }
}
