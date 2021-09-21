using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailAPI.DTO.EmailAttachment
{
    public class GetEmailAttachmentDto
    {
        public Guid Id { get; set; }
        public Guid EmailQueueId { get; set; }
        public Guid DocumentId { get; set; }
    }
}
