using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class EmailQueue
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        //public DateTime? When { get; set; }
        //public bool IsSent { get; set; }
        //public DateTime? SentTime { get; set; }
        //public int Priority { get; set; }

        public Guid EmailProviderId { get; set; }
        public virtual EmailProvider EmailProvider { get; set; }

        public virtual ICollection<EmailAttachment> Attachments { get; set; }

        public virtual ICollection<EmailDate> Dates { get; set; }
    }
}
