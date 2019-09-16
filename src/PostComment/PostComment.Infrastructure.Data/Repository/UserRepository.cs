using PostComment.Core.Domain;
using PostComment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PostComment.Infrastructure.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private PostCommentDBContext postCommentDBContext;

        public UserRepository(PostCommentDBContext postCommentDBContext)
        {
            this.postCommentDBContext = postCommentDBContext;
        }

        public IEnumerable<User> List => throw new NotImplementedException();

        public void Add(User postItem)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User FindById(int id)
        {
            return this.postCommentDBContext
                .Find<User>(id);
        }

        public void Update(User postItem)
        {
            throw new NotImplementedException();
        }
    }
}
