using Register.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.Service
{
    public interface IJwtauthManager
    {
        string Authenticate(User user);
    }
}
