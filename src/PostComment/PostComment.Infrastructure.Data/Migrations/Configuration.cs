using PostComment.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Text;

namespace PostComment.Infrastructure.Data.Migrations
{
    internal sealed class Configuration :
        DbMigrationsConfiguration<PostCommentDBContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(PostCommentDBContext context)
        {
            // Users
            var users = new List<User>
            {
                new User { Id = 1, Email = "fulano@gmail.com", UserName="Fulano"},
                new User { Id = 2, Email = "beltrano@gmail.com", UserName="Beltrano"},
            };
            users.ForEach(e => context.Users.AddOrUpdate(p => p, e));

            // Comments
            var postItems = new List<PostItem>
            {
                new PostItem { CreateDate = DateTime.Now, Text = "Post 1 XPTO",  Id = 1},
            };

            postItems.ForEach(e => context.PostItems.AddOrUpdate(p => p, e));


            context.SaveChanges();
        }

    }

}
