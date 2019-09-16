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
    public class PostItemValidateServiceTests
    {
        private Mock<IUserRepository> userRepository;
        private IValidateService<PostItem> validatePostItemService;

        public PostItemValidateServiceTests()
        {
            this.userRepository = new Mock<IUserRepository>();
            this.userRepository
                .Setup(x => x.FindById(1))
                .Returns(new Core.Domain.User { Email = "fulano@gmail.com", Id = 1, UserName = "fulano" });
            this.validatePostItemService = new PostValidator(this.userRepository.Object);
        }

        [TestMethod]
        public void On_Validate_InValid_PostItem()
        {
            // Arrange
            var postItem = new PostItem { };
            // Act
            var result = this.validatePostItemService.Validate(postItem);
            // Assert
            Assert.IsTrue(result.Count() == 3);
            Assert.IsTrue(result.Any(x => x.Message == "Null postItem text"));
        }

        [TestMethod]
        public void On_Validate_Valid_PostItem()
        {
            // Arrange
            var postItem = new PostItem { Text = "Teste XPTO", UserId = 1  };
            // Act
            var result = this.validatePostItemService.Validate(postItem);
            // Assert
            Assert.IsTrue(result.Count() == 0);
        }
    }
}
