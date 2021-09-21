using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailAPI.DTO.EmailDate
{
    public class SaveEmailDateDtoForEmailQueueDto
    { 
        public DateTime? When { get; set; }
        public int Priority { get; set; }
        public bool IsDeleted { get; set; }
    }
}
