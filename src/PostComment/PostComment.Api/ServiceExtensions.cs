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
            var connectionString = config["mysqlconnection:connectionString"];
            var optionsBuilder = new DbContextOptionsBuilder<PostCommentDBContext>();
            optionsBuilder.UseMySql(connectionString);
            services.AddSingleton<IPostItemRepository>(new PostItemRepository(new PostCommentDBContext(optionsBuilder.Options)));
            services.AddSingleton<ICommentRepository>(new CommentRepository(new PostCommentDBContext(optionsBuilder.Options)));
        }

        public static void ConfigureServiceWrapper(this IServiceCollection services)
        {
            services.AddSingleton<IPostItemService, PostItemService>();
            services.AddSingleton<PostValidator, PostValidator>();
            services.AddSingleton<CommentValidator, CommentValidator>();
        }
    }
}
