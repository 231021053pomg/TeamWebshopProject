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
    public class BasketItemServiceTest
    {
        #region Setup
        private readonly BasketItemService _basketItemService;
        private readonly Mock<IBasketItemRepository> _mock = new();

        public BasketItemServiceTest()
        {
            _basketItemService = new(_mock.Object);
        }
        #endregion

        #region GetAll
        [Fact]
        public async Task GetAll_Success_Test()
        {
            // Arrange
            int expectedCount = 2;
            List<BasketItem> basketItems = new List<BasketItem> { new BasketItem { Id = 1 }, new BasketItem { Id = 2 } };
            _mock
                .Setup(x => x.GetAll())
                .ReturnsAsync(basketItems);

            // Act
            var result = await _basketItemService.GetAll();

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
            BasketItem basketItem = new BasketItem { Id = 1, Item = new Item { Id = 1 } };

            _mock
                .Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(basketItem);

            // Act
            var result = await _basketItemService.Get(It.IsAny<int>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(basketItem.Id, result.Id);
        }
        #endregion

        #region Create
        [Fact]
        public async Task Create_Success_Test()
        {
            // Arrange
            BasketItem newBasketItem = new BasketItem { Id = 1, Item = new Item { Id = 1 } };

            _mock
                .Setup(x => x.Create(It.IsAny<BasketItem>()))
                .ReturnsAsync(newBasketItem);

            // Act
            var result = await _basketItemService.Create(It.IsAny<BasketItem>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newBasketItem.Id, result.Id);
        }
        #endregion

        #region Update
        [Fact]
        public async Task Update_Success_Test()
        {
            // Arrange
            BasketItem basketItem = new BasketItem { Id = 1, Item = new Item { Id = 1 } };

            _mock
                .Setup(x => x.Update(It.IsAny<int>(), It.IsAny<BasketItem>()))
                .ReturnsAsync(basketItem);

            // Act
            var result = await _basketItemService.Update(It.IsAny<int>(), It.IsAny<BasketItem>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(basketItem.Id, result.Id);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_Success_Test()
        {
            // Arrange
            BasketItem basketItem = new BasketItem { Id = 1, Item = new Item { Id = 1 } };

            _mock
                .Setup(x => x.Delete(It.IsAny<int>()))
                .ReturnsAsync(basketItem);

            // Act
            var result = await _basketItemService.Delete(It.IsAny<int>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(basketItem.Id, result.Id);
        }
        #endregion
    }
}
