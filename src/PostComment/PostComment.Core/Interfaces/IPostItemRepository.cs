using PostComment.Core.Domain;
using PostComment.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PostComment.Core.Interfaces
{
    public interface IPostItemRepository
    {
        IEnumerable<PostItem> List { get; }
        void Add(PostItem postItem);
        void Delete(int id);
        void Update(PostItem postItem);
        PostItem FindById(int Id);
    }
}
