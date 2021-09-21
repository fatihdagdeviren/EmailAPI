using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmailAPI.DTO.EmailProvider
{
    public class SaveEmailProviderDto
    {
        [Required]
        public string Host { get; set; }
        [Required]
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? EnableSSL { get; set; }
    }
}
