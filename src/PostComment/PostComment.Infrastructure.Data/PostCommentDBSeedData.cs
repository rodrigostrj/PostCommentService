using PostComment.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PostComment.Infrastructure.Data
{
    public static class PostCommentDBSeedData
    {
        public static void EnsureSeedDataForContext(this PostCommentDBContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var initialUser = new User { UserName = "Fulano de Tal", Email = "fulano@gmail.com" };

            context.Users.Add(initialUser);
            context.SaveChanges();


        }
    }
}
