using PostComment.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PostComment.Core.Service
{
    public interface IUsersService
    {
        Task CreateUser(User user);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUser(int id);
    }
}
