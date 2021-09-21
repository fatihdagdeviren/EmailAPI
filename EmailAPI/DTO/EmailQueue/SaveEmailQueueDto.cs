using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailAPI.DTO.EmailAttachment;
using EmailAPI.DTO.EmailDate;

namespace EmailAPI.DTO.EmailQueue
{
    public class SaveEmailQueueDto
    {
        public string Content { get; set; }
        public string Title { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public Guid EmailProviderId { get; set; }
        public ICollection<SaveEmailAttachmentForEmailQueueDto> Attachments { get; set; }
        public ICollection<SaveEmailDateDtoForEmailQueueDto> Dates { get; set; }
    }
}
