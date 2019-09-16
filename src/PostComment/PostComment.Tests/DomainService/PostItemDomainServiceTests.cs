using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PostComment.Core.Interfaces;
using PostComment.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostComment.Tests.DomainService
{
    [TestClass]
    public class PostItemDomainServiceTests
    {
        private Mock<IPostItemRepository> postItemRepository;
        private Mock<ICommentRepository> commentRepository;
        private Mock<IUserRepository> userRepository;
        private IPostItemService postItemService;

        public PostItemDomainServiceTests()
        {
            this.postItemRepository = new Mock<IPostItemRepository>();
            this.commentRepository = new Mock<ICommentRepository>();
            this.userRepository = new Mock<IUserRepository>();
            this.userRepository
                .Setup(x => x.FindById(1))
                .Returns(new Core.Domain.User { Email = "fulano@gmail.com", Id = 1, UserName = "fulano" });

            this.postItemService = new PostItemService(
                postItemRepository.Object, 
                commentRepository.Object, 
                new Core.Service.Validators.PostValidator(this.userRepository.Object),
                new Core.Service.Validators.CommentValidator(this.postItemRepository.Object));
        }

        [TestMethod]
        public async Task On_Creating_PostItemAsync()
        {
            // Arrange
            var postItem = new Core.Domain.PostItem { Text = "Teste XPTO", UserId = 1 };

            // Act
            var errors = await this.postItemService.CreatePostItem(
                    postItem
                );

            // Assert
            Assert.IsFalse(errors.Any());
        }

        [TestMethod]
        public async Task On_Creating_PostItem_UnexistentUserIdAsync()
        {
            // Arrange
            var postItem = new Core.Domain.PostItem { Text = "Teste XPTO", UserId = 2 };

            // Act
            var errors = await this.postItemService.CreatePostItem(
                    postItem
                );

            // Assert
            Assert.IsTrue(errors.Any());
        }
    }
}
