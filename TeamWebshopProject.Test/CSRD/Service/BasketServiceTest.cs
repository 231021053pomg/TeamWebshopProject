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
    public class BasketServiceTest
    {
        #region setup
        private readonly BasketService _basketService;
        private readonly Mock<BasketRepository> _mock = new();

        public BasketServiceTest()
        {
            _basketService = new(_mock.Object);
        }
        #endregion

        #region GetAll
        [Fact]
        public async Task GetAll_Success_Test()
        {
            // Arrange
            int expectedCount = 2;
            List<Basket> baskets = new List<Basket> { new Basket { Id = 1 }, new Basket { Id = 2} };
            _mock
                .Setup(x => x.GetAll())
                .ReturnsAsync(baskets);

            // Act
            var result = await _basketService.GetAll();

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
            Basket basket = new Basket { Id = 1 };
            _mock
                .Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(basket);

            // Act
            var result = await _basketService.Get(It.IsAny<int>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(basket.Id, result.Id);
        }
        #endregion

        #region Create
        [Fact]
        public async Task Create_Success_Test()
        {
            // Arrange
            Basket newBasket = new Basket { Id = 1 };

            _mock
                .Setup(x => x.Create(It.IsAny<Basket>()))
                .ReturnsAsync(newBasket);

            // Act
            var result = await _basketService.Create(It.IsAny<Basket>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newBasket.Id, result.Id);
        }
        #endregion

        #region Update
        [Fact]
        public async Task Update_Success_Test()
        {
            // Arrange
            Basket basket = new Basket { Id = 1 };

            _mock
                .Setup(x => x.Create(It.IsAny<Basket>()))
                .ReturnsAsync(basket);

            // Act
            var result = await _basketService.Update(It.IsAny<int>(), It.IsAny<Basket>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(basket.Id, result.Id);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_Success_Test()
        {
            // Arrange
            Basket basket = new Basket { Id = 1 };

            _mock
                .Setup(x => x.Delete(It.IsAny<int>()))
                .ReturnsAsync(basket);

            // Act
            var result = await _basketService.Delete(It.IsAny<int>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(basket.Id, result.Id);
        }
        #endregion
    }
}
