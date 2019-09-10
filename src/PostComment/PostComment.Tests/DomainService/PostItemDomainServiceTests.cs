using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PostComment.Core.Interfaces;
using PostComment.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostComment.Tests.DomainService
{
    [TestClass]
    public class PostItemDomainServiceTests
    {
        private Mock<IPostItemRepository> postItemRepository;
        private Mock<ICommentRepository> commentRepository;
        private IPostItemService postItemService;

        public PostItemDomainServiceTests()
        {
            this.postItemRepository = new Mock<IPostItemRepository>();
            this.commentRepository = new Mock<ICommentRepository>();
            this.postItemService = new PostItemService(
                postItemRepository.Object, 
                commentRepository.Object, 
                new Core.Service.Validators.PostValidator(),
                new Core.Service.Validators.CommentValidator());
        }

        [TestMethod]
        public void On_Creating_PostItem()
        {
            // Arrange
            var postItem = new Core.Domain.PostItem { Text = "Teste XPTO", UserId = 1 };

            // Act
            this.postItemService.CreatePostItem(
                    postItem
                );
        }
    }
}
