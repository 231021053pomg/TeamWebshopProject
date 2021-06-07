using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.CSRD.Services.Classes;
using TeamWebshopProject.API.Models;
using Xunit;

namespace TeamWebshopProject.Test.CSRD.Service
{
    public class TagServiceTest
    {
        #region Setup
        private readonly TagService _customerService;
        private readonly Mock<ITagRepository> _mock = new();

        public TagServiceTest()
        {
            _customerService = new(_mock.Object);
        }
        #endregion

        #region GetAll
        [Fact]
        public async Task GetAll_Success_Test()
        {
            // Arrange
            int expectedCount = 2;
            List<Tag> tags = new List<Tag> { new Tag { Id = 1 }, new Tag { Id = 2 } };
            _mock
                .Setup(x => x.GetAll())
                .ReturnsAsync(tags);

            // Act
            var result = await _customerService.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count());
        }
        #endregion

        #region Get
        [Fact]
        public async Task Get_Success_Test()
        {
            // Arrange
            Tag tag = new Tag { Id = 1 };

            _mock
                .Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(tag);

            // Act
            var result = await _customerService.Get(It.IsAny<int>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(tag.Id, result.Id);
        }
        #endregion

        #region Create
        [Fact]
        public async Task Create_Success_Test()
        {
            // Arrange
            Tag newTag = new Tag { Id = 1 };

            _mock
                .Setup(x => x.Create(It.IsAny<Tag>()))
                .ReturnsAsync(newTag);

            // Act
            var result = await _customerService.Create(It.IsAny<Tag>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newTag.Id, result.Id);
        }
        #endregion

        #region Update
        [Fact]
        public async Task Update_Success_Test()
        {
            // Arrange
            Tag tag = new Tag { Id = 1 };

            _mock
                .Setup(x => x.Update(It.IsAny<int>(), It.IsAny<Tag>()))
                .ReturnsAsync(tag);

            // Act
            var result = await _customerService.Update(It.IsAny<int>(), It.IsAny<Tag>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(tag.Id, result.Id);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_Success_Test()
        {
            // Arrange
            Tag tag = new Tag { Id = 1 };

            _mock
                .Setup(x => x.Delete(It.IsAny<int>()))
                .ReturnsAsync(tag);

            // Act
            var result = await _customerService.Delete(It.IsAny<int>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(tag.Id, result.Id);
        }
        #endregion
    }
}
