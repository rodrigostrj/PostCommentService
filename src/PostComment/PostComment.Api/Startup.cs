using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.DependencyInjection;
using PostComment.Core.Domain;
using PostComment.Core.Interfaces;
using PostComment.Core.Service;
using PostComment.Core.Service.Validators;
using PostComment.Infrastructure.Data;
using PostComment.Infrastructure.Data.Repository;

namespace PostComment.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {   Version = "V1",
                    Description = "API Test - Post and Comments",
                    Title = "API Test - Post and Comments",
                });
            });

            // Services
            services.AddSingleton<IPostItemService, PostItemService>();

            // Infra
            var options = new DbContextOptionsBuilder<PostCommentDBContext>()
                .UseInMemoryDatabase(databaseName: "postcomment")
                .Options;

            services.AddSingleton<IPostItemRepository>(new PostItemRepository(new PostCommentDBContext(options)));
            services.AddSingleton<ICommentRepository>(new CommentRepository(new PostCommentDBContext(options)));
            services.AddSingleton<PostValidator, PostValidator>();
            services.AddSingleton<CommentValidator, CommentValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
