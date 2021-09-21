using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class EmailAttachment
    {
        public Guid Id { get; set; }
        public Guid EmailQueueId { get; set; }
        public Guid DocumentId { get; set; }
    }
}
