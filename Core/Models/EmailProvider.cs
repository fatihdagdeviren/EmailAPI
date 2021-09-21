using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class EmailProvider
    {
        public Guid Id { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? EnableSSL { get; set; }



    }
}
