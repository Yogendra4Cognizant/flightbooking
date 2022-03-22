using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
