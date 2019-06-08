using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiyasMatrimony.API.Models;

namespace SiyasMatrimony.API.Data
{
    public class AuthRepository 
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        // public Task<User> Login(string userName, string password)
        // {
        //    User user = _context.Users.FirstOrDefault(usr => usr.UserName == userName);

        //    if (user == null)
        //       return null;

        //    return user;
          
        // }

        // public Task<User> Register(User user, string password)
        // {
        //     throw new NotImplementedException();
        // }

        // public async Task<bool> UserExists(string userName)
        // {
        //     System.Linq.Expressions.Expression<Func<User, bool>> predicate = x => x.UserName == userName;
        //     if (_context.Users.Any(predicate))
        //         return false;
        //     return true;
        // }
    }
}
