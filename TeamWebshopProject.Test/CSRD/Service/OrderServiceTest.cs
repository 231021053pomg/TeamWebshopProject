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
    public class OrderServiceTest
    {
        #region Setup
        private readonly OrderService _customerService;
        private readonly Mock<IOrderRepository> _mock = new();

        public OrderServiceTest()
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
            List<Order> orders = new List<Order> { new Order { Id = 1 }, new Order { Id = 2 } };
            _mock
                .Setup(x => x.GetAll())
                .ReturnsAsync(orders);

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
            Order order = new Order { Id = 1 };

            _mock
                .Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(order);

            // Act
            var result = await _customerService.Get(It.IsAny<int>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(order.Id, result.Id);
        }
        #endregion

        #region Create
        [Fact]
        public async Task Create_Success_Test()
        {
            // Arrange
            Order newOrder = new Order { Id = 1 };

            _mock
                .Setup(x => x.Create(It.IsAny<Order>()))
                .ReturnsAsync(newOrder);

            // Act
            var result = await _customerService.Create(It.IsAny<Order>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newOrder.Id, result.Id);
        }
        #endregion

        #region Update
        [Fact]
        public async Task Update_Success_Test()
        {
            // Arrange
            Order order = new Order { Id = 1 };

            _mock
                .Setup(x => x.Update(It.IsAny<int>(), It.IsAny<Order>()))
                .ReturnsAsync(order);

            // Act
            var result = await _customerService.Update(It.IsAny<int>(), It.IsAny<Order>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(order.Id, result.Id);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_Success_Test()
        {
            // Arrange
            Order order = new Order { Id = 1 };

            _mock
                .Setup(x => x.Delete(It.IsAny<int>()))
                .ReturnsAsync(order);

            // Act
            var result = await _customerService.Delete(It.IsAny<int>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(order.Id, result.Id);
        }
        #endregion
    }
}
