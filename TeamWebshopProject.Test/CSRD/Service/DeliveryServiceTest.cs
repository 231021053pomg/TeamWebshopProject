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
    public class DeliveryServiceTest
    {
        #region Setup
        private readonly DeliveryService _deliveryService;
        private readonly Mock<DeliveryRepository> _mock = new();

        public DeliveryServiceTest()
        {
            _deliveryService = new(_mock.Object);
        }
        #endregion

        #region GetAll
        [Fact]
        public async Task GetAll_Success_Test()
        {
            // Arrange
            int expectedCount = 2;
            List<Delivery> deliveries = new List<Delivery> { new Delivery { Id = 1 }, new Delivery { Id = 2 } };
            _mock
                .Setup(x => x.GetAll())
                .ReturnsAsync(deliveries);

            // Act
            var result = await _deliveryService.GetAll();

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
            Delivery delivery = new Delivery { Id = 1 };

            _mock
                .Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(delivery);

            // Act
            var result = await _deliveryService.Get(It.IsAny<int>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(delivery.Id, result.Id);
        }
        #endregion

        #region Create
        [Fact]
        public async Task Create_Success_Test()
        {
            // Arrange
            Delivery newDelivery = new Delivery { Id = 1 };

            _mock
                .Setup(x => x.Create(It.IsAny<Delivery>()))
                .ReturnsAsync(newDelivery);

            // Act
            var result = await _deliveryService.Create(It.IsAny<Delivery>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(newDelivery.Id, result.Id);
        }
        #endregion

        #region Update
        [Fact]
        public async Task Update_Success_Test()
        {
            // Arrange
            Delivery delivery = new Delivery { Id = 1 };

            _mock
                .Setup(x => x.Create(It.IsAny<Delivery>()))
                .ReturnsAsync(delivery
                );

            // Act
            var result = await _deliveryService.Update(It.IsAny<int>(), It.IsAny<Delivery>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(delivery.Id, result.Id);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_Success_Test()
        {
            // Arrange
            Delivery delivery = new Delivery { Id = 1 };

            _mock
                .Setup(x => x.Delete(It.IsAny<int>()))
                .ReturnsAsync(delivery);

            // Act
            var result = await _deliveryService.Delete(It.IsAny<int>());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(delivery.Id, result.Id);
        }
        #endregion
    }
}
