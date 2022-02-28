using Register.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.Service
{
    public interface IUserRepository
    {
        public User GetUser(User user);

    }
}
