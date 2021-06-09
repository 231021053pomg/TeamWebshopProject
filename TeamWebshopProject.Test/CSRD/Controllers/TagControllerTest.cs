using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Moq;

using TeamWebshopProject.API.CSRD.Controllers;
using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.CSRD.Services.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.Test.CSRD.Controllers
{
    public class TagControllerTest
    {
        private readonly TagController _controller;
        private readonly Mock<ITagService> tagService = new();

        public TagControllerTest()
        {
            _controller = new TagController(tagService.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatus200_WhenDataExists()
        {
            // Arrange
            List<Tag> tags = new List<Tag>();
            tags.Add(new Tag());
            tags.Add(new Tag());

            tagService
                .Setup(s => s.GetAll())
                .ReturnsAsync(tags);

            // Act
            var result = await _controller.GetAll();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatus204_WhenNoDataExists()
        {
            // Arrange
            List<Tag> tags = new List<Tag>();

            tagService
                .Setup(s => s.GetAll())
                .ReturnsAsync(tags);

            // Act
            var result = await _controller.GetAll();
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetAll_ShouldReturnWithStatus500_WhenTagIsNull()
        {
            //Arrange
            List<Tag> tags = null;

            tagService
                .Setup(s => s.GetAll())
                .ReturnsAsync(tags);
            //Act
            var result = await _controller.GetAll();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task Create_ShouldReturnWithStatus400_WhenTagSubmittedIsNull()
        {
            // Arrange
            Tag tags = null;

            tagService
                .Setup(s => s.Create(null))
                .ReturnsAsync(tags);
            // Act
            var response = await _controller.Create(tags);
            // Assert
            var responseStatusCode = (IStatusCodeActionResult)response;
            Assert.Equal(400, responseStatusCode.StatusCode);
        }

        [Fact]
        public async Task Create_ShouldReturnWithStatus200_WhenTagSubmitIsOk()
        {
            // Arrange
            Tag tags = new Tag { Name = "" };
            tagService
                .Setup(s => s.Create(It.IsAny<Tag>()))
                .ReturnsAsync(tags);
            // Act
            var respone = await _controller.Create(tags);
            // Assert
            var responeStatusCode = (IStatusCodeActionResult)respone;
            Assert.Equal(200, responeStatusCode.StatusCode);
        }

        [Fact]
        public async Task GetById_ShoudReturnWithBasket_WhenTagExists()
        {
            // Arrange
            int id = 1;
            string name = "";

            Tag tags = new Tag
            {
                Id = id,
                Name = name

            };

            tagService
                .Setup(s => s.Get(It.IsAny<int>()))
                .ReturnsAsync(tags);
            // Act
            var respone = await _controller.Get(id);
            // Assert
            Assert.NotNull(respone);
        }
    }
}

