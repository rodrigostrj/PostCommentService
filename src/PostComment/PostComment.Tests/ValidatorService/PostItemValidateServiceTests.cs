using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostComment.Core.Domain;
using PostComment.Core.Service.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PostComment.Tests.ValidatorService
{
    [TestClass]
    public class PostItemValidateServiceTests
    {
        private IValidateService<PostItem> validatePostItemService;

        public PostItemValidateServiceTests()
        {
            this.validatePostItemService = new PostValidator();
        }

        [TestMethod]
        public void On_Validate_InValid_PostItem()
        {
            // Arrange
            var postItem = new PostItem { };
            // Act
            var result = this.validatePostItemService.Validate(postItem);
            // Assert
            Assert.IsTrue(result.Count() == 2);
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
