using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class EmailDate : BaseModel
    {
        public Guid Id { get; set; }
        public Guid EmailQueueId { get; set; }
        public DateTime? When { get; set; }
        public bool IsSent { get; set; }
        public DateTime? SentTime { get; set; }
        public int Priority { get; set; }
    }
}
