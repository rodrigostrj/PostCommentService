using PostComment.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostComment.Core.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> List { get; }
        void Add(User postItem);
        void Delete(int id);
        void Update(User postItem);
        User FindById(int Id);
    }
}
