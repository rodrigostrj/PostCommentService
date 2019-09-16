using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostComment.Core.Interfaces;
using PostComment.Core.Service;
using PostComment.Core.Service.Validators;
using PostComment.Infrastructure.Data;
using PostComment.Infrastructure.Data.Repository;

namespace PostComment.Api
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["sqlconnection:connectionString"];
            var optionsBuilder = new DbContextOptionsBuilder<PostCommentDBContext>();
            optionsBuilder.UseSqlServer(connectionString);
            var context = new PostCommentDBContext(optionsBuilder.Options);
            services.AddSingleton<IPostItemRepository>(new PostItemRepository(context));
            services.AddSingleton<ICommentRepository>(new CommentRepository(context));
            services.AddSingleton<IUserRepository>(new UserRepository(context));
            context.EnsureSeedDataForContext();
        }

        public static void ConfigureServiceWrapper(this IServiceCollection services)
        {
            services.AddSingleton<IPostItemService, PostItemService>();
            services.AddSingleton<PostValidator, PostValidator>();
            services.AddSingleton<CommentValidator, CommentValidator>();
        }
    }
}
