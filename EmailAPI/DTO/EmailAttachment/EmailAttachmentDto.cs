using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailAPI.DTO.EmailQueue;

namespace EmailAPI.DTO.EmailAttachment
{
    public class EmailAttachmentDto
    {
        public Guid Id { get; set; }
        public Guid EmailQueueId { get; set; }
        public Guid DocumentId { get; set; }
    }
}
