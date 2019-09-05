using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PostComment.Core.Domain;

namespace PostComment.Core.Service
{
    public class UsersService : IUsersService
    {
        public Task CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsers()
        {
            return null;
        }

        public Task<User> GetUser(int id)
        {
            return null;
        }
    }
}
