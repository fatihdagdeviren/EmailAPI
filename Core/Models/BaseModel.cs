using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class BaseModel
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletionTime { get; set; }
    }
}
