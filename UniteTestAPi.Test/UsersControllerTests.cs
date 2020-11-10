using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApAnzh.Controllers;
using WebApAnzh.Models;
using Xunit;

namespace UnitTestApp.Tests
{
    public class UsersControlerTests
    {

        UsersController _controller;
        UsersContext db;

        public UsersControlerTests(UsersContext context)
        {
            db = context;
            _controller = new UsersController(db);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }



        [Fact]
        public void Get_IdPassed_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get(3);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Post_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            User testUser = new User()
            {
                Name = "ang",
                Age = 5
            };

            // Act
            var createdResponse = _controller.Post(testUser);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void Remove_IdPassed_ReturnsOkResult()
        {
            // Arrange
            int testId = 6;

            // Act
            var okResponse = _controller.Delete(testId);

            // Assert
            Assert.IsType<OkResult>(okResponse);
        }
    }
}