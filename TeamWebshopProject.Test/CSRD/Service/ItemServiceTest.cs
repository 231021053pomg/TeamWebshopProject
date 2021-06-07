using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWebshopProject.API.CSRD.Repository.Classes;
using TeamWebshopProject.API.CSRD.Services.Classes;
using TeamWebshopProject.API.Models;
using Xunit;

namespace TeamWebshopProject.Test.CSRD.Service
{
    public class ItemServiceTest
    {
        #region Setup
        private readonly ItemService _customerService;
        private readonly Mock<ItemRepository> _mock = new();

        public ItemServiceTest()
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
            List<Item> items = new List<Item> { new Item { Id = 1 }, new Item { Id = 2 } };
            _mock
                .Setup(x => x.GetAll())
                .ReturnsAsync(items);

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
            Item item = new Item { Id = 1 };

            _mock
                .Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(item);

            // Act
            var result = await _customerService.Get(It.IsAny<int>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(item.Id, result.Id);
        }
        #endregion

        #region Create
        [Fact]
        public async Task Create_Success_Test()
        {
            // Arrange
            Item newItem = new Item { Id = 1 };

            _mock
                .Setup(x => x.Create(It.IsAny<Item>()))
                .ReturnsAsync(newItem);

            // Act
            var result = await _customerService.Create(It.IsAny<Item>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newItem.Id, result.Id);
        }
        #endregion

        #region Update
        [Fact]
        public async Task Update_Success_Test()
        {
            // Arrange
            Item item = new Item { Id = 1 };

            _mock
                .Setup(x => x.Create(It.IsAny<Item>()))
                .ReturnsAsync(item);

            // Act
            var result = await _customerService.Update(It.IsAny<int>(), It.IsAny<Item>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(item.Id, result.Id);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_Success_Test()
        {
            // Arrange
            Item item = new Item { Id = 1 };

            _mock
                .Setup(x => x.Delete(It.IsAny<int>()))
                .ReturnsAsync(item);

            // Act
            var result = await _customerService.Delete(It.IsAny<int>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(item.Id, result.Id);
        }
        #endregion
    }
}
