using Register.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.Service
{
    public class UserRepository : IUserRepository
    {
        public AppDbContext _context;
        public UserRepository(AppDbContext _context)
        {
            this._context = _context;
        }
        public User GetUser(User user)
        {
            return _context.users.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
        }
    }
}
