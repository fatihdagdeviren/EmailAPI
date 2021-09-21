using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailAPI.DTO.EmailAttachment;
using EmailAPI.DTO.EmailDate;
using EmailAPI.DTO.EmailProvider;

namespace EmailAPI.DTO.EmailQueue
{
    public class EmailQueueDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public EmailProviderDto EmailProvider { get; set; }
        public  ICollection<GetEmailAttachmentDto> Attachments { get; set; }
        public ICollection<EmailDateDto> Dates { get; set; }
    }
}
