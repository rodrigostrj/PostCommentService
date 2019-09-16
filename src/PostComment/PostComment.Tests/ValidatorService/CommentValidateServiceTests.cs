using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostComment.Core.Domain;
using PostComment.Core.Service.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PostComment.Core.Interfaces;
using Moq;

namespace PostComment.Tests.ValidatorService
{
    [TestClass]
    public class CommentValidateServiceTests
    {
        private Mock<IPostItemRepository> postItemRepository;
        private IValidateService<Comment> validateService;

        public CommentValidateServiceTests()
        {
            this.postItemRepository = new Mock<IPostItemRepository>();
            this.postItemRepository
                .Setup(x => x.FindById(1))
                .Returns(new PostItem { Id = 1, Text = "Teste 123", UserId = 1 } );
            this.validateService = new CommentValidator(this.postItemRepository.Object);
        }

        [TestMethod]
        public void On_Validate_InValid_Comment_UnexistentPost()
        {
            // Arrange
            var comment = new Comment { PostId = 2, Text = "teste 123 teste" };
            // Act
            var result = this.validateService.Validate(comment);
            // Assert
            Assert.AreEqual(result.Count(), 1);
        }
    }
}
